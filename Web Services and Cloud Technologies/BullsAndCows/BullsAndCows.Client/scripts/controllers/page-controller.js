'use strict';

bullsAndCowsApp.controller('PageController',
    function PageController($scope, author, authorLink, auth) {
        $scope.author = author;
        $scope.authorLink = authorLink;

        auth.isAuthenticated();
    }
);