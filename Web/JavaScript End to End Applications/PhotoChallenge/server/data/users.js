var User = require('mongoose').model('User');
var fileUpload = require('../utilities/file-upload');

module.exports = {
    findOrCreate: function (userData, resolve) {
        User.findOne({username: userData.username, email: userData.email})
            .exec(function (err, user) {
                if (err) {
                    resolve(err, false);
                }

                if (user) {
                    resolve(null, user);
                } else {
                    var newUser = new User(userData);
                    newUser.save(function () {
                        fileUpload.createUserFolder(newUser);
                        resolve(null, newUser);
                    });
                }
            });
    },
    getCount: function (error, success) {
        User.find()
            .count(function (err, userCount) {
                if (err) {
                    error(err);
                } else {
                    success(userCount)
                }
            })
    },
    getUser: function (username, error, success) {
        User.findOne({username: username})
            .exec(function (err, user) {
                if (err) {
                    error(err);
                }

                success(user);
            });
    },
    addUser: function (user, error, success) {
        User.create(user, function (err, user) {
            if (err) {
                error(err);
            } else {
                success(user)
            }
        })
    }
};