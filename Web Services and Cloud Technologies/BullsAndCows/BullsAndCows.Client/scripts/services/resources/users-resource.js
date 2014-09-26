'use strict';

bullsAndCowsApp.factory('UsersResource', function($resource, baseUrl) {
    var usersApi = baseUrl + '/api/account';

    return {
        register: $resource(usersApi + '/register'),
        login: $resource(baseUrl + '/token'),
        logout: $resource(usersApi + '/logout')
    };
});