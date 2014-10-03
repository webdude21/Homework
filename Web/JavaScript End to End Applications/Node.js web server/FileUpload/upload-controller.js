var getGuid = require('./guid');
var sys = require('sys');
var multipart = require("./node_modules/multipart-parser/index");

function parse_multipart(req) {
    var parser = multipart;

    // Make parser use parsed request headers
    parser.headers = req.headers;

    // Add listeners to request, transferring data to parser

    req.addListener("data", function(chunk) {
        parser.write(chunk);
    });

    req.addListener("end", function() {
        parser.close();
    });

    return parser;
}

function uploadFile(req, res, fileSystem) {
    // Request body is binary
    req.setEncoding('binary');

    // Handle request as multipart
    var stream = parse_multipart(req);

    var fileName = null;
    var fileStream = null;

    // Set handler for a request part received
    stream.onPartBegin = function (part) {
        sys.debug("Started part, name = " + part.name + ", filename = " + part.filename);

        // Construct file name
        fileName = "/uploads/" + getGuid();

        // Construct stream used to write to file
        fileStream = fileSystem.createWriteStream(fileName);

        // Add error handler
        fileStream.addListener("error", function (err) {
            sys.debug("Got error while writing to file '" + fileName + "': ", err);
        });

        // Add drain (all queued data written) handler to resume receiving request data
        fileStream.addListener("drain", function () {
            req.resume();
        });
    };

    // Set handler for a request part body chunk received
    stream.onData = function (chunk) {
        // Pause receiving request data (until current chunk is written)
        req.pause();

        // Write chunk to file
        // Note that it is important to write in binary mode
        // Otherwise UTF-8 characters are interpreted
        sys.debug("Writing chunk");
        fileStream.write(chunk, "binary");
    };

    // Set handler for request completed
    stream.onEnd = function () {
        // As this is after request completed, all writes should have been queued by now
        // So following callback will be executed after all the data is written out
        fileStream.addListener("drain", function () {
            // Close file stream
            fileStream.end();
            // Handle request completion, as all chunks were already written
            // upload_complete(res);
            console.log('ready!')
        });
    };
}

module.exports = uploadFile;