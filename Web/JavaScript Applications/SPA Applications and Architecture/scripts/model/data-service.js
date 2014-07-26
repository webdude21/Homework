'use strict';
crowdChat.factory('dataProvider', function () {
    var POSTS_URL = 'http://crowd-chat.herokuapp.com/posts';

    function retrieveAllPosts(success, error){
        httpRequester.getJSON(POSTS_URL, success, error);
    }

    function sendNewPost(message, success, error){
        httpRequester.postJSON(POSTS_URL, message, success, error);
    }

    return {
        retrieveAllPosts: retrieveAllPosts,
        sendNewPost: sendNewPost
    }
});