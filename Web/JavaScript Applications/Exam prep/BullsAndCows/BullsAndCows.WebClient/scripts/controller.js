var controllers = (function () {

    var serverUrl = 'http://localhost:40643/api';

    var Controller = (function () {

        function clearContent (selector){
            $(selector).html('');
        }

        function tryToLogIn(context, selector) {
            var userData = {
                username: $('#tb-login-username').val(),
                password: $('#tb-login-password').val()
            };

            context.persister.user.login(userData, function () {
                alert('logged in');
                context.loadUI(selector)
            }, function (err) {
                alert(JSON.stringify(err));
            });
        }

        function Controller() {
            this.persister = DataPersister.getPersister(serverUrl);
        }

        Controller.prototype.loadUI = function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            } else {
                this.loadLoginFormUI(selector);
            }
        };

        Controller.prototype.loadGameUI = function (selector) {
            clearContent(selector);
            var $gameUI = $('<form />')
                .append($('<label for="tb-login-username">' + this.persister.getNickname() +  ' </label>'))
                .append($('<button id="btn-logout"/>').text('Logout'));
            $(selector).append($gameUI);
            this.attachUIEventHandlers(selector);
        };

        Controller.prototype.loadLoginFormUI = function (selector) {
            clearContent(selector);
            var $loginForm = $('<form />')
                .append($('<label for="tb-login-username">Login: </label>'))
                .append($('<input type="text" id="tb-login-username" />'))
                .append($('<label for="tb-login-password">Password: </label>'))
                .append($('<input type="password" id="tb-login-password" />'))
                .append($('<button id="btn-login"/>').text('Login'));
            $(selector).append($loginForm);
            this.attachUIEventHandlers(selector);
        };

        Controller.prototype.attachUIEventHandlers = function (selector) {
            var that = this;
            $(selector).on('click', '#btn-login', function () {
                tryToLogIn(that, selector);
                return false;
            });

            $(selector).on('click', '#btn-logout', function () {
                that.persister.user.logout(function () {
                    alert('Logged out!');
                    that.loadLoginFormUI(selector);
                }, function (data) {
                    alert(JSON.stringify(data));
                });

                return false;
            })
        };

        return Controller
    }());

    return {
        get: function () {
            return new Controller();
        }
    }
}());