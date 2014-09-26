'use strict';

bullsAndCowsApp.controller('SignUpController', function SignUpController ($scope, $location, auth, messageBox) {
    var MESSAGE_BOX_SELECTOR = '#message-box';
    var SUCCESSFUL_REGISTRATION = 'Registration successful!';

    $scope.signup = function(user) {
        auth.signup(user).then(function() {
            messageBox.success(SUCCESSFUL_REGISTRATION, MESSAGE_BOX_SELECTOR);
            $location.path('/');
        });
    }
});