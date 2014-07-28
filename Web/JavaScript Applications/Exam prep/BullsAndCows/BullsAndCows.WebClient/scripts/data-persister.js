var DataPersister = (function () {
    var nickname = localStorage.getItem('nickname');
    var sessionKey = localStorage.getItem('sessionKey');

    function saveUserData(userData) {
        localStorage.setItem('nickname', userData.nickname);
        localStorage.setItem('sessionKey', userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        saveUserData({
            nickname: null,
            sessionKey: null
        });
        localStorage.removeItem('nickname');
        localStorage.removeItem('sessionKey');
    }

    var MainPersister = (function () {

        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(rootUrl);
            this.game = new GamePersister(rootUrl);
            this.guess = new GuessPersister(rootUrl);
            this.messages = new MessegesPersister(rootUrl);

            return this;
        }

        MainPersister.prototype.isUserLoggedIn = function () {
            return !!(nickname && sessionKey);
        };

        MainPersister.prototype.getNickname = function () {
            return nickname;
        };

        return MainPersister;
    }());

    var UserPersister = (function () {

        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl + '/user/';
        }

        UserPersister.prototype.login = function (user, success, error) {
            var url = this.rootUrl + 'login';
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                success(data);
            }, error);
        };

        UserPersister.prototype.register = function (user, success, error) {
            var url = this.rootUrl + 'register';
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData, function (data) {
                saveUserData(data);
                success(data);
            }, error);
        };

        UserPersister.prototype.logout = function (success, error) {
            var url = this.rootUrl + 'logout/' + sessionKey;

            httpRequester.getJSON(url, function (data) {
                success(data);
                clearUserData();
            }, error);
        };

        UserPersister.prototype.scores = function (success, error) {
            var url = this.rootUrl + 'scores/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };

        return UserPersister;
    }());

    var GamePersister = (function () {

        function GamePersister(rootUrl) {
            this.rootUrl = rootUrl + '/game/';
        }

        GamePersister.prototype.createGame = function (createRequest, success, error) {
            var url = this.rootUrl + 'create/' + sessionKey;
            var encryptedRequest = {
                title: createRequest.title,
                number: createRequest.number,
                password: CryptoJS.SHA1(createRequest.password).toString()
            };

            httpRequester.postJSON(url, encryptedRequest, success, error);
        };

        GamePersister.prototype.join = function (joinRequest, success, error) {
            var url = this.rootUrl + 'join/' + sessionKey;
            var encryptedRequest = {
                gameId: joinRequest.gameId,
                number: joinRequest.number,
                password: CryptoJS.SHA1(joinRequest.password).toString()
            };

            httpRequester.postJSON(url, encryptedRequest, success, error);
        };

        GamePersister.prototype.start = function (gameId, success, error) {
            var url = this.rootUrl + gameId + '/start/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };

        GamePersister.prototype.myActive = function (success, error) {
            var url = this.rootUrl + 'my-active/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };

        GamePersister.prototype.state = function (gameId, success, error) {
            var url = this.rootUrl + gameId + '/state/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };

        GamePersister.prototype.open = function (success, error) {
            var url = this.rootUrl + 'open/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };


        return GamePersister;
    }());

    var GuessPersister = (function () {

        function GuessPersister(rootUrl) {
            this.rootUrl = rootUrl + '/guess/';
        }

        GuessPersister.prototype.make = function (gameId, number, success, error) {
            var url = this.rootUrl + 'make/' + sessionKey;
            var guessRequest = {
                gameId: gameId,
                number: number
            };

            httpRequester.postJSON(url, guessRequest, success, error);
        };

        return GuessPersister;
    }());

    var MessegesPersister = (function () {

        function MessegesPersister(rootUrl) {
            this.rootUrl = rootUrl + '/messages/';
        }

        MessegesPersister.prototype.unread = function (success, error) {
            var url = this.rootUrl + 'unread/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };
        MessegesPersister.prototype.all = function () {
            var url = this.rootUrl + 'all/' + sessionKey;
            httpRequester.getJSON(url, success, error);
        };

        return MessegesPersister;
    }());

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    };
}());