var controllers = (function () {

    var serverUrl = 'http://localhost:40643/api';

    var Controller = (function () {

        function displayErrorMessage(errorData) {
            alert(errorData.responseJSON.Message);
        }

        function clearContent(selector) {
            $(selector).html('');
        }

        function tryToLogIn(context, selector) {
            var userData = {
                username: $('#tb-login-username').val(),
                password: $('#tb-login-password').val()
            };

            context.persister.user.login(userData, function () {
                alert('logged in');
                context.loadGameUI(selector);
            }, displayErrorMessage);
        }

        function tryToRegister(context, selector) {
            var userData = {
                username: $('#tb-login-username').val(),
                nickname: $('#tb-login-nickname').val(),
                password: $('#tb-login-password').val()
            };

            context.persister.user.register(userData, function () {
                alert('registered');
                context.loadGameUI(selector);
            }, displayErrorMessage);
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

            this.attachUIEventHandlers(selector);
        };

        Controller.prototype.loadGameUI = function (selector) {
            clearContent(selector);
            var $gameUI = $('<form />')
                .append($('<label for="tb-login-username">' + this.persister.getNickname() + ' </label>'))
                .append($('<button id="btn-logout"/>').text('Logout'))
                .append($('<button id="btn-highscores"/>').text('highscore'));
            $(selector).append($gameUI);
        };

        Controller.prototype.loadLoginFormUI = function (selector) {
            clearContent(selector);
            var $loginForm = $('<form />')
                .append($('<label for="tb-login-username">Login: </label>'))
                .append($('<input type="text" id="tb-login-username" />'))
                .append($('<label for="tb-login-password">Password: </label>'))
                .append($('<input type="password" id="tb-login-password" />'))
                .append($('<button id="btn-login"/>').text('Login'))
                .append($('<button id="btn-registration"/>').text('Registration'));
            $(selector).append($loginForm);
        };

        Controller.prototype.loadRegisterFormUI = function () {
            $('#tb-login-username')
                .after($('<input type="text" id="tb-login-nickname" />'))
                .after($('<label for="tb-login-nickname">Nickname: </label>'));
            $('#btn-registration').detach();
            $('#btn-login')
                .after($('<button id="btn-register"/>').text('Register'))
        };

        Controller.prototype.printHighScores = function (data, selector) {
            var $highScoreList = $('<ul>');
            data.forEach(function (item) {
                $highScoreList.append($('<li><p>' + item.nickname +
                    ' - ' + item.score + '</p></li>'));
            });

            $(selector).append($highScoreList);
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
                }, displayErrorMessage);

                return false;
            });

            $(selector).on('click', '#btn-highscores', function () {
                that.persister.user.scores(function (data) {
                    that.printHighScores(data, selector);
                }, displayErrorMessage);

                return false;
            });

            $(selector).on('click', '#btn-registration', function () {
                that.loadRegisterFormUI();
                return false;
            });

            $(selector).on('click', '#btn-register', function () {
                tryToRegister(that, selector);
                return false;
            });
        };

        return Controller
    }());

    return {
        get: function () {
            return new Controller();
        }
    }
}());