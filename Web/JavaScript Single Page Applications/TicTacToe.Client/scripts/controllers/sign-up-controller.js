'use strict';

ticTacToeApp.controller('SignUpController', function SignUpController ($scope, $location, auth, messageBox) {
    var MESSAGE_BOX_SELECTOR = '#message-box';

    $scope.signup = function(user) {
        auth.signup(user).then(function() {
            messageBox.success('Registration successful!', MESSAGE_BOX_SELECTOR);
            $location.path('/');
        })
    }
});