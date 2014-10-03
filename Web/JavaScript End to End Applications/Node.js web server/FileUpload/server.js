var http = require('http');
var port = 3000;
var fileSystem = require('fs');
var url = require("url");
var sys = require("sys");

var getIndex = require('./index-controller');
var uploadFile = require('./upload-controller');

function upload_complete(res) {
    sys.debug("Request complete");
    // Render response
    res.writeHead(200, {'Content-Type': 'text/plain'});
    res.write("Thanks for playing!");
    res.end();

    sys.puts("\n=> Done");
}

http.createServer(function (req, res) {
    switch (url.parse(req.url).pathname) {
        case '/':
            getIndex(req, res, fileSystem);
            break;
        case '/upload':
            uploadFile(req, res, fileSystem);
            break;
    }
}).listen(port);

console.log('Server running at http://127.0.0.1:' + port + '/');