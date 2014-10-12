var encryption = require('../utilities/encryption');
var fileUpload = require('../utilities/file-upload');

var data = require('../data');

var CONTROLLER_NAME = 'contestants';
var URL_DELIMITER = '___';
var SALT = "FOSTATAKOVRI";
var FS_DELIMITER = '/';
var PAGE_SIZE = 3;

function getDate() {
    var delimiter = '-';
    var today = new Date();
    var day = today.getDate();
    var month = today.getMonth() + 1;

    var year = today.getFullYear();
    if (day < 10) {
        day = '0' + day
    }
    if (month < 10) {
        month = '0' + month
    }
    return day + delimiter + month + delimiter + year;
}

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    getCount: function (req, res, next) {
        data.contestants.getById(req.params.id
            , function (err) {
                res.redirect('/not-found');
            }, function (contestant) {
                res.render(CONTROLLER_NAME + '/contestant', contestant);
            })
    },
    getAll: function (req, res, next) {
        var queryObject = req.query;

        if (!queryObject.pager) {
            queryObject.pager = {
                currentPage: +queryObject.page || 1
            };
        }

        if (!queryObject.sort) {
            queryObject.sort = {
                columnName: "registerDate",
                order: "desc"
            }
        }

        data.contestants.getQuery(function (err) {
            res.redirect('/not-found');
        }, function (contestants) {
            res.render(CONTROLLER_NAME + '/all', contestants);
        }, queryObject, PAGE_SIZE);
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