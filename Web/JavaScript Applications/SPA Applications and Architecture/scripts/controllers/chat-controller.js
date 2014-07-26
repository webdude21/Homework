'use strict';

crowdChat.controller('ChatController',
    function ChatController($scope, dataProvider) {
        $scope.message = {};
        $scope.messages = {};

        var INTERVAL_FOR_MESSAGE_RETRIEVAL = 10000;
        var FETCH_MESSAGES_FROM_SERVER_ERROR_MESSAGE = "There was an error while " +
            "retrieving the chat messages from the server!";
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var MESSAGE_SEND_ERROR_MESSAGE = 'An error occured while ' +
            'sending the message to the server!';
        var MESSAGE_SEND_SUCCESS_MESSAGE = 'Message was successfully sent to the server!';
        var $chatContainer = $('#chat-container');

        $scope.sendNewMessage = function (message, newMessage) {
            if (newMessage.$valid) {
                console.log(message);
                dataProvider.sendNewPost(message, function () {
                    success(MESSAGE_SEND_SUCCESS_MESSAGE, MESSAGE_BOX_SELECTOR);
                    $scope.getMessages();
                    $scope.reset();
                }, function () {
                    error(MESSAGE_SEND_ERROR_MESSAGE, MESSAGE_BOX_SELECTOR)
                });
            }
        };

        function generateMessagesList(messages){
            var $list = $('<ul>');
            messages.forEach(function (message){
                $('<li><span class="message-author">' + message.by + ': ' +
                    '</span><span class="message-text">' + message.text + '</span></li>').appendTo($list)
            });

            $chatContainer.append($list);
            $chatContainer.scrollTop(99999999999);
        }

        $scope.getMessages = function () {
            dataProvider.retrieveAllPosts(function (messages) {
                $chatContainer.empty();
                generateMessagesList(messages);
            }, function () {
                error(FETCH_MESSAGES_FROM_SERVER_ERROR_MESSAGE, MESSAGE_BOX_SELECTOR)
            });
        };


        function messageBox(message, container, type) {
            var boxType = type || 'success';
            var html = '<div class="alert alert-dismissable alert-' + boxType + '">' +
                '<button type="button" class="close" data-dismiss="alert">×</button>' +
                '<strong>' + message + '</strong></div>';
            $(container).append($(html));
        }

        function success(message, container) {
            messageBox(message, container);
        }

        function error(message, container) {
            messageBox(message, container, 'danger');
        }

        $scope.reset = function () {
            $scope.message.text = '';
            $scope.newMessage.$setPristine();
            $scope.$apply();
        };

        $scope.getMessages();
        setInterval($scope.getMessages, INTERVAL_FOR_MESSAGE_RETRIEVAL);
    });