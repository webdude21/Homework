'use strict';

ticTacToeApp.factory('identity', function($window, UsersResource) {
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