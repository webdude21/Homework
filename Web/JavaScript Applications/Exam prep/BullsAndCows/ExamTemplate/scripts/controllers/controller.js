define(['jquery', 'message-box'], function ($, messageBox) {

    var SUCCESSFUL_LOG_IN_MESSAGE = "You've logged in successfully!";
    var SUCCESSFUL_LOGOUT_MESSAGE = "You've logged out successfully!";
    var MESSAGE_SELECTOR = '#message-box';

    tryToLogin = function () {
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
            messageBox.error(err.responseJSON.Message, MESSAGE_SELECTOR);
        });

    };

    tryToLogout = function () {
        var that = this;
        this.dataProvider.user.logout(function () {
            that.loadLoginForm.call(that);
            setTimeout(function () {
                messageBox.success(SUCCESSFUL_LOGOUT_MESSAGE, MESSAGE_SELECTOR);
            }, 100)
        }, function (err) {
            messageBox.error(err.responseJSON.Message, MESSAGE_SELECTOR);
        });
    };

    function Controller(dataProvider, partialViewSelector) {
        this.dataProvider = dataProvider;
        this.partialViewSelector = partialViewSelector;
    }

    Controller.prototype.loadLoginForm = function () {
        $(this.partialViewSelector).load('views/login.html');

    };

    Controller.prototype.loadHomeForm = function () {
        $(this.partialViewSelector).load('views/home.html')
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
    };

    return {
        getController: function (dataProvider, partialViewSelector) {
            return new Controller(dataProvider, partialViewSelector)
        }
    };
});
