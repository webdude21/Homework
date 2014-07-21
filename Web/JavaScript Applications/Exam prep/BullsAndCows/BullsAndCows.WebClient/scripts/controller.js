var controllers = (function () {

    var serverUrl = 'http://localhost:40643/api';

    var Controller = (function () {
        function Controller() {
            this.persister = DataPersister.getPersister(serverUrl);
        }

        Controller.prototype.loadUI = function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            } else {
                this.loadLoginFormUI(selector);
            }
        };

        Controller.prototype.loadGameUI = function (){
            return false;
        };

        Controller.prototype.loadLoginFormUI = function (){
            return false;
        };

        return Controller
    }());

    return {
        get: function () {
            return new Controller();
        }
    }

}());