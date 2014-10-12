var User = require('mongoose').model('User');

module.exports = {
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
    addUser: function (error, success) {
        User.find()
            .count(function (err, userCount) {
                if (err) {
                    error(err);
                } else {
                    success(userCount)
                }
            })
    }
};