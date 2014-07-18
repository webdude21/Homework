var HighScore;
(function (HighScore) {
    var LocalStorageHandler = (function () {
        function LocalStorageHandler(localStorageName) {
            this.localStorageName = localStorageName;
        }
        LocalStorageHandler.prototype.getLocalStorageData = function () {
            var highScore = localStorage.getItem(this.localStorageName);

            if (!highScore) {
                var highScoreList = [];
                highScore = localStorage.setItem(this.localStorageName, JSON.stringify(highScoreList));
            } else {
                highScore = JSON.parse(highScore);
            }

            return highScore;
        };

        LocalStorageHandler.prototype.savePlayer = function (playerName, playerScore) {
            var highScoreList = this.getLocalStorageData();
            highScoreList.push({
                playerName: playerName,
                playerScore: playerScore
            });
            this.setLocalStorageData(highScoreList);
        };

        LocalStorageHandler.prototype.setLocalStorageData = function (highScoreList) {
            localStorage.setItem(this.localStorageName, JSON.stringify(highScoreList));
        };

        LocalStorageHandler.prototype.getHighScores = function () {
            return this.getLocalStorageData();
        };

        LocalStorageHandler.clearLocalStorage = function () {
            localStorage.clear();
        };
        return LocalStorageHandler;
    })();
    HighScore.LocalStorageHandler = LocalStorageHandler;
})(HighScore || (HighScore = {}));
//# sourceMappingURL=high-score.js.map
