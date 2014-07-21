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

            return this;
        }

        MainPersister.prototype.isUserLoggedIn = function () {
            debugger;
            return !!(nickname && sessionKey);
        };

        MainPersister.prototype.getNickname = function (){
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

            httpRequester.postJSON(url, userData, function(data){
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

        };

        return UserPersister;
    }());

    var GamePersister = (function () {

        function GamePersister(parameters) {

        }

        GamePersister.prototype.createGame = function () {

        };

        GamePersister.prototype.join = function () {

        };

        GamePersister.prototype.start = function () {

        };

        GamePersister.prototype.myActive = function () {

        };


        return GamePersister;
    }());

    var GuessPersister = (function () {

        function GuessPersister() {

        }

        GuessPersister.prototype.make = function () {

        };

        return GuessPersister;
    }());

    var MessegesPersister = (function () {

        function MessegesPersister() {

        }

        MessegesPersister.prototype.unread = function () {

        };
        MessegesPersister.prototype.all = function () {

        };

        return MessegesPersister;
    }());

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    };
}());