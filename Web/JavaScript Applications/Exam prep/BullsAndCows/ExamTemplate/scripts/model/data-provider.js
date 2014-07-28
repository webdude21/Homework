'use strict';
define(['http-requester', 'crypto-js'], function (httpRequester) {
    var sessionData = {};
    var appName;

    function saveSession(data) {
        sessionData = data;
        localStorage.setItem(appName, JSON.stringify(sessionData));
    }

    function clearSessionData() {
        localStorage.removeItem(appName);
        sessionData = {};
    }

    function loadSessionData() {
        var storage = localStorage.getItem(appName);
        if (storage) {
            sessionData = JSON.parse(storage);
        }
    }

    var DataProvider = (function () {
        function DataProvider(rootUrl, applicationName) {
            this.rootUrl = rootUrl;
            appName = applicationName;
            this.user = new UserService(rootUrl);
            loadSessionData();

            return this;
        }

        DataProvider.prototype.isUserLoggedIn = function () {
            return !!(sessionData && sessionData.nickname && sessionData.sessionKey);
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

            httpRequester.postJSON(url, encryptedUserData)
                .then(function (data) {
                    saveSession(data);
                    success(data)
                }, function (err) {
                    error(err)
                })
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
                .then(function (data) {
                    saveSession(data);
                    success(data)
                }, function (err) {
                    error(err)
                })
        };

        UserService.prototype.logout = function (success, error) {
            var url = this.rootUrl + 'logout/' + sessionData.sessionKey;
            httpRequester.getJSON(url)
                .then(function () {
                    clearSessionData();
                    success();
                }, function (err) {
                    error(err);
                });
        };

        return UserService
    }());

    return {
        getDataProvider: function (rootUrl, applicationName) {
            return new DataProvider(rootUrl, applicationName);
        }
    }
});