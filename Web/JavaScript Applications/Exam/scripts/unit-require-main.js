(function () {
    requirejs.config({
        paths: {
            'mocha': './libs/mocha',
            'chai': './libs/chai',
            'jquery': 'libs/jquery-2.1.1',
            'sammy': 'libs/sammy',
            'underscore': 'libs/underscore',
            'q': 'libs/q.min',
            'crypto-js': 'libs/sha1',
            'http-requester': 'helpers/http-requester-q',
            'message-box': 'helpers/message-box',
            'data-provider': 'model/data-provider',
            'controller': 'controllers/controller'
        }
    });

    require(['chai', "mocha"], function (chai) {
        mocha.setup('bdd');
        expect = chai.expect;
        require(['tests/UnderscoreModuleTest', 'tests/Messages-Test'], function () {
            mocha.run();
        })
    })
}());