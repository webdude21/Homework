define(function () {
    require.config({
        paths: {
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

    require(['jquery', 'sammy', 'controller', 'data-provider'],
        function ($, Sammy, controller, dataProvider) {
            var ROOT_URL = 'http://jsapps.bgcoder.com/';
            var APPLICATION_NAME = 'CrowdShare';
            var partialViewSelector = '#partial-html-container';

            var appDataProvider = dataProvider.getDataProvider(ROOT_URL, APPLICATION_NAME);
            var appController = controller.getController(appDataProvider, partialViewSelector);
            appController.attachEventHandlers();

            var myApp = Sammy(partialViewSelector, function () {
                this.get("#/login", function () {
                    if (appDataProvider.isUserLoggedIn()) {
                        window.location = '#/home';
                        return;
                    }
                    appController.loadLoginForm();
                });

                this.get("#/home", function () {
                    appController.loadHomeForm();
                });

                this.get("#/register", function () {
                    appController.loadRegisterForm();
                });

                this.get("#/createpost", function () {
                    if (!appDataProvider.isUserLoggedIn()) {
                        window.location = '#/login';
                        controller.userNotLoggedIn();
                        return;
                    }
                    appController.loadCreatePostForm();
                });
            });

            myApp.run('#/home');
        });
});