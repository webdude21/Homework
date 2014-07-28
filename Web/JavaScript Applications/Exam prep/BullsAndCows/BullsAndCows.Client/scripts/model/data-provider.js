'use strict';

var dataProvider  = (function(){
    var ROOT_URL = 'http://localhost:40643/api';
    var APPLICATION_NAME = 'BullsAndCows';
    var sessionData = {};

    function saveSession(data) {
        localStorage.setItem(APPLICATION_NAME, data);
        sessionData = data;
    }

    function clearSessionData() {
        localStorage.removeItem(APPLICATION_NAME);
        sessionData = {};
    }

    var DataProvider = (function (rootUrl, appName) {
        function DataProvider(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserService(rootUrl);

            return this;
        }

        DataProvider.prototype.isUserLoggedIn = function () {
            return !!(sessionData.nickname && sessionData.sessionKey);
        };

        DataProvider.prototype.getNickname = function () {
            return sessionData.nickname;
        };

        return DataProvider
    }());

    var UserService = (function () {

        function UserService(rootUrl) {
            this.rootUrl = rootUrl + '/user/'
        }

        UserService.prototype.login = function (userData, success, error) {
            var url = this.rootUrl + 'login';
            var encryptedUserData = {
                username: userData.username,
                authCode: CryptoJS.SHA1(userData.username +
                    userData.password).toString()
            };

            httpRequester.postJSON(url, encryptedUserData, function (data) {
                saveSession(data);
                success(data)
            }, function (err) {
                error(err);
            });
        };

        UserService.prototype.register = function (userData, success, error) {
            var url = this.rootUrl + 'register';
            var encryptedUserData = {
                username: userData.username,
                nickname: userData.nickname,
                authCode: CryptoJS.SHA1(userData.username +
                    userData.password).toString()
            };

            httpRequester.postJSON(url, encryptedUserData)
                .done(function (data) {
                    saveSession(data);
                    success(data);
                })
                .fail(function (err) {
                    error(err);
                });
        };

        UserService.prototype.logout = function (success, error) {
            var url = this.rootUrl + 'logout/' + sessionData.sessionKey;
            httpRequester.getJSON(url)
                .done(function () {
                    clearSessionData();
                    success();
                })
                .fail(function (err) {
                    error(err);
                });
        };

        return UserService
    }());

    return new DataProvider(ROOT_URL, APPLICATION_NAME);
}());