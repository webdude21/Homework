require('../models/user');
require('../models/message');
var mongoose = require('mongoose');
var User = mongoose.model('User');
var Message = mongoose.model('Message');

module.exports = {
    registerUser: function (user) {
        User.create(user);
    },
    sendMessage: function (message) {
        var from;
        var to;
        User.find({user: message.from}).exec(function (err, result) {
            if (err) {
                console.log('Cannot find the user');
            }
            from = result[0];
            User.find({user: message.to}).exec(function (err, result) {
                if (err) {
                    console.log('Cannot find the user');
                }
                to = result[0];
                Message.create({
                    from: from,
                    to: to,
                    text: message.text
                });
            });
        });
    },
    getMessages: function (users, callback) {
        var from;
        var to;
        User
            .findOne({user: users.with})
            .exec(function (err, result) {
                if (err) {
                    console.log('Cannot find the user');
                }
                from = result;
                User
                    .findOne({user: users.and})
                    .exec(function (err, result) {
                        if (err) {
                            console.log('Cannot find the user');
                        }
                        to = result;
                        Message
                            .find({from: from, to: to })
                            .exec(function (err, result) {
                                if (err) {
                                    console.log('Cannot messages between the two users');
                                    return;
                                }

                                callback(result);
                            });
                    });
            });
    }
};