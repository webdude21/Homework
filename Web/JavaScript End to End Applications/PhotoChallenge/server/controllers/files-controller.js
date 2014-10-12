var encryption = require('../utilities/encryption');
var fileUpload = require('../utilities/file-upload');

var data = require('../data');

var CONTROLLER_NAME = 'files';
var URL_DELIMITER = '___';
var SALT = "FOSTATAKOVRI";
var FS_DELIMITER = '/';

module.exports = {
    download: function (req, res, next) {
        var url = req.params.url;
        var decryptedUrl = encryption.decrypt(url, SALT);
        var parts = decryptedUrl.split(URL_DELIMITER);
        var path = parts.join(FS_DELIMITER);
        res.download(__dirname + '/../../uploads/' + path   );
    },
    getCount: function (req, res, next) {
        data.contestants.getById(req.params.id
            , function (err) {
                res.redirect('/not-found');
            }, function (contestant) {
                res.render(CONTROLLER_NAME + '/contestant', contestant);
            })
    },
    postRegister: function (req, res, next) {
        var newContestant = {};
        var uploadedFiles = [];

        var username = req.user.username;
        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {
            var fileNameHashed = encryption.generateHashedText(encryption.generateSalt(), filename);
            var currentDate = getDate();
            var url = username + URL_DELIMITER + currentDate +
                URL_DELIMITER + fileNameHashed;
            var encryptedUrl = encryption.encrypt(url, SALT);
            var filePath = username + FS_DELIMITER + currentDate + FS_DELIMITER;
            console.log(fileNameHashed);
            fileUpload.saveFile(file, fileNameHashed, filePath);

            uploadedFiles.push({
                url: encryptedUrl,
                fileName: filename });
        });

        req.busboy.on('field', function (fieldname, val) {
            newContestant[fieldname] = val;
        });

        req.busboy.on('finish', function () {
            newContestant.pictures = data.files.addFiles(uploadedFiles);
            var savedContestant = data.contestants.addContestant(newContestant);
            res.redirect(savedContestant._id);
        })
    }
};