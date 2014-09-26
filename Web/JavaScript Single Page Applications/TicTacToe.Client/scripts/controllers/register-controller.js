'use strict';

ticTacToeApp.controller('RegisterController', function RegisterController ($scope, $location, auth, notifier) {
    var SUCCESSFUL_REGISTRATION = 'Registration successful!';

    $scope.register = function(user) {
        auth.register(user).then(function() {
            notifier.success(SUCCESSFUL_REGISTRATION);
            $location.path('/');
        });
    }
});