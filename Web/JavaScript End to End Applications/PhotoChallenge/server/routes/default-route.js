var controllers = require('../controllers');

module.exports = function(app){
    app.get(app.get('/', controllers.home.getStatistics));

    app.get('*', function (req, res) {
            res.render('not-found', {currentUser: req.user});
    });
};