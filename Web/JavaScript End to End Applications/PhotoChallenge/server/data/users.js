var User = require('mongoose').model('User');

module.exports = {
    getCount: function (error, success) {
        User.find().count(function (err, userCount) {
            if (err) {
                error(err);
            } else {
                success(userCount)
            }
        })
    }
};