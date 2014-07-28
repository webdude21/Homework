'use strict';

bullsAndCows.controller('LoginController',
    function LoginController($scope, $location, dataProvider, messageBox) {
        if (dataProvider.isUserLoggedIn()) {
            $location.path("/home");
            return;
        }

        var MESSAGE_BOX_SELECTOR = '#message-box';
        var LOGIN_SUCCESS_MESSAGE = 'You have successfully logged in';
        $scope.userData = {};

        $scope.sendUserData = function (userData, userLoginForm) {
            if (userLoginForm.$valid) {
                dataProvider.user.login(userData, function () {
                    messageBox.success(LOGIN_SUCCESS_MESSAGE, MESSAGE_BOX_SELECTOR);
                }, function (err) {
                    messageBox.error(err.responseJSON.Message, MESSAGE_BOX_SELECTOR)
                });
            }
        };
    });