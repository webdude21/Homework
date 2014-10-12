var auth = require('../config/auth');
var controllers = require('../controllers');

module.exports = function (app) {
    app.route('/files/:url')
        .get(controllers.files.download)
};