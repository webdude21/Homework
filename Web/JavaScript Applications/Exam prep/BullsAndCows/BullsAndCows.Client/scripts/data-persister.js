var DataPersister = (function () {

    var MainPersister = (function () {

        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(rootUrl);

            return this;
        }

        return MainPersister;
    }());

    var UserPersister = (function () {

        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl + 'user/';
        }

        UserPersister.prototype.login = function (user, success, error) {
            var url = this.rootUrl + 'login';
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData, success, error);
        };

        UserPersister.prototype.register = function (user, success, error) {

        };

        UserPersister.prototype.logout = function (success, error) {

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
        getPersister: function(url){
            return new MainPersister(url);
        }
    };
}());