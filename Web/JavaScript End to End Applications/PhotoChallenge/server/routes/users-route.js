var auth = require('../config/auth');
var controllers = require('../controllers');

module.exports = function (app) {
    app.route('/register')
        .get(controllers.users.getRegister)
        .post(controllers.users.postRegister);

    app.route('/login')
        .get(controllers.users.getLogin)
        .post(auth.login, controllers.users.postLogin);

    app.route('/logout')
        .get(auth.logout, controllers.users.logout);
};