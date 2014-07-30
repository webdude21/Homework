define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'sammy': 'libs/sammy',
            'bootstrap': 'libs/bootstrap',
            'handlebars': 'libs/handlebars-v1.3.0',
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
            var partialViewSelector = '#wrapper';

            var appDataProvider = dataProvider.getDataProvider(ROOT_URL, APPLICATION_NAME);
            var appController = controller.getController(appDataProvider, partialViewSelector);
            appController.attachEventHandlers();

            var bullsAndCowsApp = Sammy(partialViewSelector, function () {
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

            bullsAndCowsApp.run('#/home');
        });
});