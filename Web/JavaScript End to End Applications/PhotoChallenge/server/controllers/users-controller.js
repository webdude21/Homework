var encryption = require('../utilities/encryption');
var User = require('mongoose').model('User');
var fileUpload = require('../utilities/file-upload');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    postRegister: function (req, res, next) {
        var newUserData = req.body;

        User.findOne({username: newUserData.username})
            .where('email')
            .equals(newUserData.email)
            .exec(function (err, user) {
            if (user) {
                req.session.errorMessage = "This username/email address is taken, please try another one!";
                res.redirect('/register');
            } else if (newUserData.password != newUserData.confirmPassword) {
                req.session.errorMessage = 'Passwords do not match!';
                res.redirect('/register');
            } else {
                newUserData.salt = encryption.generateSalt();
                newUserData.hashPass = encryption.generateHashedText(newUserData.salt, newUserData.password);
                User.create(newUserData, function (err, user) {
                    if (err) {
                        req.session.errorMessage = err.message;
                        res.redirect('/register');
                        return;
                    }

                    fileUpload.createDir(user.username);

                    req.logIn(user, function (err) {
                        if (err) {
                            res.status(400);
                            return res.send({reason: err.toString()}); // create error page
                        }

                        res.redirect('/');
                    });
                });
            }
        });
    },
    getLogin: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    postLogin: function (req, res, next) {
        if (req.user) {
            res.redirect('/');
        }
        else {
            res.redirect('/login');
        }
    },
    logout: function (req, res, next) {
        res.redirect('/');
    }
};