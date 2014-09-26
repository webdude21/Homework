'use strict';

bullsAndCowsApp.controller('LoginController',
    function LoginController($scope, identity, auth, messageBox, $location) {
        $scope.user = {};
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var USER_LOGIN_SUCCESS = "You've successfully logged in!";
        var USER_LOGIN_FAILED = 'Username and/or Password is not valid!';
        var USER_LOGOUT_SUCCESS = 'Successful logout!';

        $scope.identity = identity;

        $scope.login = function(user) {
            auth.login(user).then(function(success) {
                if (success) {
                    messageBox.success(USER_LOGIN_SUCCESS, MESSAGE_BOX_SELECTOR);
                }
                else {
                    messageBox.error(USER_LOGIN_FAILED, MESSAGE_BOX_SELECTOR);
                }
            });
        };

        $scope.logout = function() {
            auth.logout().then(function() {
                messageBox.success(USER_LOGOUT_SUCCESS, MESSAGE_BOX_SELECTOR);
                if ($scope.user) {
                    $scope.user = {};
                }
                $location.path('/');
            })
        };
    });
