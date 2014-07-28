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

        function tryToCreateGame(context, selector) {
            var requestData = {
                title: $('#tb-create-game-title').val(),
                number: parseInt($('#tb-secret-number').val()),
                password: $('#tb-game-password').val()
            };

            context.persister.game.createGame(requestData, function () {
                alert('Game Created');
            }, displayErrorMessage);
        }

        function tryToJoinGame(context, selector) {
            var requestData = {
                gameId: $('#tb-join-game-id').val(),
                number: parseInt($('#tb-secret-number').val()),
                password: $('#tb-game-password').val()
            };

            context.persister.game.loadJoinGameUI(requestData, function () {
                alert('Game Joined');
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
            var $userRelatedStuff = $('<form />').addClass('ui-form')
                .append($('<label for="lb-login-username">' +
                    this.persister.getNickname() + '</label>'))
                .append($('<button id="btn-logout"/>').text('Logout'))
                .append($('<button id="btn-highscores"/>').text('Show high scores'))
                .append($('<button id="btn-open-creation-form"/>').text('Create Game'))
                .append($('<button id="btn-join-form"/>').text('Join Game'));
            $(selector).append($userRelatedStuff);

        };

        Controller.prototype.createGameFormUI = function (selector) {
            clearContent(selector);
            var $gameRelatedStuff = $('<form />').addClass('ui-form')
                .append($('<label for="tb-create-game-title">Game Title: </label>'))
                .append($('<input type="text" id="tb-create-game-title" />'))
                .append($('<label for="tb-secret-number">Number: </label>'))
                .append($('<input type="number" id="tb-secret-number" pattern="/d{4}" />'))
                .append($('<label for="tb-game-password">Game Password (optional):</label>'))
                .append($('<input type="password" id="tb-game-password" />'))
                .append($('<button id="btn-create-game"/>').text('Create Game'))
                .append($('<button id="btn-cancel"/>').text('Cancel'));
            $(selector).append($gameRelatedStuff);
        };

        Controller.prototype.loadJoinGameUI = function (selector) {
            clearContent(selector);
            var $gameRelatedStuff = $('<form />').addClass('ui-form')
                .append($('<label for="tb-join-game-id">Game ID: </label>'))
                .append($('<input type="text" id="tb-join-game-id" />'))
                .append($('<label for="tb-secret-number">Number: </label>'))
                .append($('<input type="number" id="tb-secret-number" pattern="/d{4}" />'))
                .append($('<label for="tb-game-password">Game Password (optional):</label>'))
                .append($('<input type="password" id="tb-game-password" />'))
                .append($('<button id="btn-join-game"/>').text('Join Game'))
                .append($('<button id="btn-cancel"/>').text('Cancel'));
            $(selector).append($gameRelatedStuff);
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
                .after($('<button id="btn-register"/>').text('Register'));
        };

        Controller.prototype.printHighScores = function (data, selector) {
            var $highScoreList = $('<ul id="high-scores">');
            data.forEach(function (item, index) {
                $highScoreList.append($('<li><p class="p-score-item">' + (index + 1) + '. ' +
                    item.nickname + ' - ' + item.score + '</p></li>'));
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

            $(selector).on('click', '#btn-open-creation-form', function () {
                that.createGameFormUI(selector);
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

            $(selector).on('click', '#btn-create-game', function () {
                tryToCreateGame(that, selector);
                return false;
            });

            $(selector).on('click', '#btn-join-game', function () {
                tryToJoinGame(that, selector);
                return false;
            });


            $(selector).on('click', '#btn-join-form', function () {
                that.loadJoinGameUI(selector);
                return false;
            });
        };

        return Controller;
    }());

    return {
        get: function () {
            return new Controller();
        }
    };
}());