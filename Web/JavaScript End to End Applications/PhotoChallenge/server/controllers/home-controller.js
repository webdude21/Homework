var data = require('../data');

module.exports = {
    getStatistics: function (req, res, next) {
        var contestantCount = 0;
        var usersCount = 0;

        var getFromDb = function () {
            data.contestants.getCount(function (err) {
                req.session.errorMessage = err;
                res.redirect('/not-found');
            }, function (contestants) {
                contestantCount = contestants;
                getUserCount();
            });
        };

        var getUserCount = function () {
            data.users.getCount(function (err) {
                req.session.errorMessage = err;
                res.redirect('/not-found')
            }, function (userCount) {
                usersCount = userCount;
                renderResult()
            })
        };

        var renderResult = function () {
            res.render('index', {
                contestantsCount: contestantCount,
                usersCount: usersCount,
                currentUser: req.user
            });
        };

        getFromDb();
    }
};