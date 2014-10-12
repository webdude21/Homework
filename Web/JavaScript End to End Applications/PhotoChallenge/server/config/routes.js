var routes = require('../routes');

module.exports = function (app) {
    routes.usersRoute(app);
    routes.contestantsRoute(app);
    routes.filesRoute(app);
    routes.defaultRoute(app);
};
