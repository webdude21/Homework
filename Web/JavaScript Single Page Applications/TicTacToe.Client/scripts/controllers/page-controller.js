'use strict';

ticTacToeApp.controller('PageController',
    function PageController($scope, author, authorLink) {
        $scope.author = author;
        $scope.authorLink = authorLink;
    }
);