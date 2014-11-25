var cloudinary = require('cloudinary');
var fs = require('fs');
cloudinary.config(process.env.CLOUDINARY_URL);

var data = require('../data');

var CONTROLLER_NAME = 'contestants';
var INVALID_IMAGE_ERROR = 'Моля уверете се, че сте избрали валидно ' +
    'изображение от следните формати (gif, jpg, jpeg, tiff, png)!';
var PAGE_SIZE = 10;

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    vote: function (req, res, next) {
        data.contestants.getById(req.params.id
            , function (err) {
                res.redirect('/not-found');
            }, function (contestant) {
                if (contestant.votes.indexOf(req.user._id) > -1) {
                    req.session.errorMessage = 'Вече сте гласували за този участник!';
                } else {
                    contestant.votes.push(req.user);
                    contestant.save();
                }
                res.redirect('/contestants/' + contestant.id);
            });
    },
    getById: function (req, res, next) {
        data.contestants.getById(req.params.id
            , function (err) {
                res.redirect('/not-found');
            }, function (contestant) {
                res.render(CONTROLLER_NAME + '/contestant', contestant);
            });
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
            req.session.errorMessage = err;
            res.redirect('/not-found');
        }, function (contestants) {
            res.render(CONTROLLER_NAME + '/all', contestants);
        }, queryObject, PAGE_SIZE);
    },
    postRegister: function (req, res, next) {
        var newContestant = {};
        var permittedFormats = ['gif', 'jpg', 'jpeg', 'tiff', 'png'];
        var savedContestant;

        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename, encoding, mimetype) {
            if (filename && filename.indexOf('.') && permittedFormats.indexOf(filename.split('.')[1]) > -1) {
                var stream = cloudinary.uploader.upload_stream(function (result) {
                    savedContestant.pictures.push({
                        url: result.secure_url,
                        fileName: filename
                    });
                    savedContestant.save();
                });

                file.on('data', stream.write)
                    .on('end', stream.end);
            }
        });

        req.busboy.on('field', function (fieldname, val) {
            newContestant[fieldname] = val;
        });

        req.busboy.on('finish', function () {
            savedContestant = data.contestants.addContestant(newContestant);
            res.redirect(savedContestant._id);
        })
    }
};
