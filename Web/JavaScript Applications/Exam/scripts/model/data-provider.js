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
            this.post = new PostService(rootUrl);
            loadSessionData();

            return this;
        }

        DataProvider.prototype.isUserLoggedIn = function () {
            return !!(sessionData && sessionData.username && sessionData.sessionKey);
        };

        DataProvider.prototype.getUserName = function () {
            return sessionData.username;
        };

        return DataProvider
    }());

    var PostService = (function () {

        function PostService(rootUrl) {
            this.rootUrl = rootUrl + 'post'
        }

        PostService.prototype.getAllPosts = function (success, error) {
            var url = this.rootUrl;
            httpRequester.getJSON(url)
                .then(function (data) {
                    success(data)
                }, function (err) {
                    error(err)
                })
        };

        PostService.prototype.getFilteredMessages = function (userData, success, error) {
            var url = this.rootUrl;
            var queryString = '';

            if (userData) {
                if (userData.pattern) {
                    queryString += '?pattern=' + userData.pattern;
                    if (userData.user) {
                        queryString += '&user=' + userData.user;
                    }
                } else {
                    if (userData.user) {
                        queryString += '?user=' + userData.user;
                    }
                }

                url += queryString;
            }

            httpRequester.getJSON(url)
                .then(function (data) {
                    success(data)
                }, function (err) {
                    error(err)
                })
        };

        PostService.prototype.createPost = function (userData, success, error) {
            var url = this.rootUrl;
            var headersKey = 'X-SessionKey';
            var headersValue = sessionData.sessionKey;
            httpRequester.postJSONWithCustomHeaders(url, userData, headersKey, headersValue)
                .then(function (data) {
                    success(data)
                }, function (err) {
                    error(err)
                })
        };

        return PostService
    }());

    var UserService = (function () {

        function postJSONToURL(userData, url, success, error) {
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
        }

        function UserService(rootUrl) {
            this.rootUrl = rootUrl
        }

        UserService.prototype.login = function (userData, success, error) {
            var url = this.rootUrl + 'auth';
            postJSONToURL(userData, url, success, error);
        };


        UserService.prototype.register = function (userData, success, error) {
            var url = this.rootUrl + 'user';
            postJSONToURL(userData, url, success, error);
        };

        UserService.prototype.logout = function (success, error) {
            var url = this.rootUrl + 'user';
            var headersKey = 'X-SessionKey';
            var headersValue = sessionData.sessionKey;

            httpRequester.putJSONWithCustomHeaders(url, headersKey, headersValue)
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