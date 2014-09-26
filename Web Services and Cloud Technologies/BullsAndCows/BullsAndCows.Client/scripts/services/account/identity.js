'use strict';

bullsAndCowsApp.factory('identity', function($window, UsersResource, appName, $cookieStore) {
    var user;

    if ($window.bootstrappedUserObject) {
        user = new UsersResource();
        angular.extend(user, $window.bootstrappedUserObject);
    }

    return {
        currentUser: user,
        isAuthenticated: function() {
            return !!this.currentUser;
        }
    }
});