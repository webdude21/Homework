define(['jquery', 'message-box', 'underscore'], function ($, messageBox, _) {

    var SUCCESSFUL_LOG_IN_MESSAGE = "You've logged in successfully!";
    var SUCCESSFUL_LOGOUT_MESSAGE = "You've logged out successfully!";
    var SUCCESSFUL_POST_MESSAGE = "You've successfully posted into the crowd share!";
    var MESSAGE_SELECTOR = '#message-box';
    var FETCH_MESSAGES_FROM_SERVER_ERROR_MESSAGE = "There was an error while " +
        "retrieving the chat messages from the server!";
    var MESSAGE_SEND_ERROR_MESSAGE = 'An error occured while ' +
        'sending the message to the server!';
    var YOU_MUST_LOGIN_TO_SEND_MESSAGES = 'You must be logged in in order to send messages';


    var paging = function (messages){
        var result = [];

    };


    var sortMessages = function (messages) {
        var sortingParams = getSortingParams();
        var result = [];

        var sortByTitle = function (message) {
            return message.title;
        };

        var sortByDate = function (message) {
            return message.postDate;
        };

        if (sortingParams.sortBy == 'title') {
            result = _.chain(messages)
                .sortBy(sortByTitle)
                .value()
        } else {
            result = _.chain(messages)
                .sortBy(sortByDate)
                .value();
        }

        if (sortingParams.sortOrder == 'descending'){
            result = result.reverse()
        }

        return result;

    };

    var getSortingParams = function () {
        return {
            sortBy: $('#sl-sort-by').find('option:selected').val(),
            sortOrder: $('#sl-sort-order').find('option:selected').val()
        };
    };

    var tryToLogin = function () {
        var userData = {
            username: $('#tb-username').val(),
            password: $('#tb-password').val()
        };

        var that = this;
        this.dataProvider.user.login(userData, function () {
            that.loadHomeForm.call(that);
            setTimeout(function () {
                messageBox.success(SUCCESSFUL_LOG_IN_MESSAGE, MESSAGE_SELECTOR);
            }, 100);
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });

    };

    var tryToLogout = function () {
        var that = this;
        this.dataProvider.user.logout(function () {
            that.loadLoginForm.call(that);
            setTimeout(function () {
                messageBox.success(SUCCESSFUL_LOGOUT_MESSAGE, MESSAGE_SELECTOR);
            }, 100)
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });
    };

    var tryToRegister = function () {
        var userData = {
            username: $('#tb-username').val(),
            password: $('#tb-password').val()
        };
        var that = this;
        this.dataProvider.user.register(userData, function () {
            window.location = '#/home';
            setTimeout(function () {
                messageBox.success(SUCCESSFUL_LOGOUT_MESSAGE, MESSAGE_SELECTOR);
            }, 100)
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });
    };

    var tryToPostMessage = function () {
        var userData = {
            title: $('#tb-post-title').val(),
            body: $('#ta-post-body').val()
        };
        this.dataProvider.post.createPost(userData, function () {
            window.location = '#/home';
            setTimeout(function () {
                messageBox.success(SUCCESSFUL_POST_MESSAGE, MESSAGE_SELECTOR);
            }, 100)
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });
    };

    var tryToGetMessages = function () {


        var that = this;
        this.dataProvider.post.getAllPosts(function (data) {
            setTimeout(function () {
                var sortedMessages = sortMessages(data);
                generateMessagesList(sortedMessages);
                var loggedUser = that.dataProvider.getUserName();
                if (loggedUser) {
                    $('#home-title').text('Logged in as ' + that.dataProvider.getUserName());
                } else {
                    $('#home-title').text('You are viewing this as a guest!');
                }

            }, 100);
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });
    };

    var clearMessageBox = function () {
        var $chatContainer = $('#chat-container');
        $chatContainer.empty()
    };

    var tryToGetMessagesFiltered = function () {

        var filter = {
            user: $('#tb-filter-by-username').val(),
            pattern: $('#tb-filter-by-pattern').val()
        };

        if ((!filter.user) && (!filter.pattern)) {
            filter = null;
        }

        var that = this;
        this.dataProvider.post.getFilteredMessages(filter, function (data) {
            setTimeout(function () {
                var sortedMessages = sortMessages(data);
                generateMessagesList(sortedMessages);
                $('#home-title').text('Logged in as ' + that.dataProvider.getUserName());
            }, 100);
        }, function (err) {
            messageBox.error(err.responseJSON.message, MESSAGE_SELECTOR);
        });
    };

    function generateMessagesList(messages) {
        var $chatContainer = $('#chat-container');
        var $list = $('<ul>');
        _.each(messages, function (message) {
            $('<li><span class="message-author">' + message.user.username + ': ' +
                '<span class="message-title">' + message.title + ' - ' +
                '</span><span class="message-text">' + message.body + '</span></li>').appendTo($list)
        });

        $chatContainer.append($list);
        $chatContainer.scrollTop(99999999999);
    }

    function Controller(dataProvider, partialViewSelector) {
        this.dataProvider = dataProvider;
        this.partialViewSelector = partialViewSelector;
    }

    Controller.prototype.loadLoginForm = function () {
        $(this.partialViewSelector).load('views/login.html');

    };

    Controller.prototype.loadHomeForm = function () {
        $(this.partialViewSelector).load('views/home.html');
        tryToGetMessages.call(this);
        var loggedUser = this.dataProvider.getUserName();
        if (loggedUser) {
            $('#home-title').text('Logged in as ' + this.dataProvider.getUserName());
            setTimeout(function () {
                $('#userHomeTemplate').append('<button class="btn btn-default" id="btn-logout">Logout</button>');
            }, 200);
        } else {
            $('#home-title').text('You are viewing this as a guest!');
        }

    };

    Controller.prototype.userNotLoggedIn = function () {
        setTimeout(function () {
            messageBox.error(YOU_MUST_LOGIN_TO_SEND_MESSAGES, MESSAGE_SELECTOR);
        }, 200);
    };


    Controller.prototype.loadRegisterForm = function () {
        $(this.partialViewSelector).load('views/register.html')
    };

    Controller.prototype.loadCreatePostForm = function () {
        $(this.partialViewSelector).load('views/createpost.html')
    };

    Controller.prototype.attachEventHandlers = function () {
        var that = this;

        $(that.partialViewSelector).on('click', '#btn-login', function () {
            tryToLogin.call(that);
            return false;
        });

        $(that.partialViewSelector).on('click', '#btn-logout', function () {
            tryToLogout.call(that);
            return false
        });

        $(that.partialViewSelector).on('click', '#btn-register', function () {
            tryToRegister.call(that);
            return false
        });

        $(that.partialViewSelector).on('click', '#btn-send-post', function () {
            tryToPostMessage.call(that);
            return false
        });

        $(that.partialViewSelector).on('click', '.close', function () {
            $(this).parent().detach();
            return false
        });

        $(that.partialViewSelector).on('click', '#btn-filter', function () {
            tryToGetMessagesFiltered.call(that);
            clearMessageBox();
            return false
        });
    };

    return {
        getController: function (dataProvider, partialViewSelector) {
            return new Controller(dataProvider, partialViewSelector)
        }
    };
});
