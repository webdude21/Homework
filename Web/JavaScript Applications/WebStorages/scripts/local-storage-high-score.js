var HighScore;
(function (HighScore) {
    var LocalStorage = (function () {
        function LocalStorage() {
        }
        LocalStorage.prototype.savePlayer = function (playerName, playerScore) {
            localStorage.setItem(playerName, playerScore);
        };

        LocalStorage.prototype.displayHighScore = function () {
            for (var i = 0; i < arguments.length; i++) {
                var obj = arguments[i];
            }
        };

        LocalStorage.prototype.clearLocalStorage = function () {
            localStorage.clear();
        };
        return LocalStorage;
    })();
    HighScore.LocalStorage = LocalStorage;
})(HighScore || (HighScore = {}));
//# sourceMappingURL=local-storage-high-score.js.map
