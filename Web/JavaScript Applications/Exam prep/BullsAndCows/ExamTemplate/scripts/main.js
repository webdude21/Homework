define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'sammy': 'libs/sammy',
            'bootstrap': 'libs/bootstrap',
            'mustache': 'libs/mustache',
            'underscore': 'libs/underscore',
            'q': 'libs/q.min',
            'crypto-js': 'libs/sha1',
            'http-requester': 'helpers/http-requester-q',
            'message-box': 'helpers/message-box',
            'data-provider': 'model/data-provider',
            'controller': 'controllers/controller',
            'app-data': 'model/app-data'
        }
    });

    require(['jquery', 'sammy', 'controller', 'data-provider', 'bootstrap'],
        function ($, Sammy, controller, dataProvider) {
            var ROOT_URL = 'http://localhost:40643/api';
            var APPLICATION_NAME = 'BullsAndCows';
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
                    if (!appDataProvider.isUserLoggedIn()) {
                        window.location = '#/login';
                        return;
                    }

                    appController.loadHomeForm();
                });
            });

            myApp.run('#/home');
        });
});