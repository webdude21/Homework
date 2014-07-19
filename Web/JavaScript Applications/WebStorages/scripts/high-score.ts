module HighScore {
    export class LocalStorageHandler {
        constructor(private localStorageName:string) {
        }

        public getLocalStorageData() {
            var highScore = localStorage.getItem(this.localStorageName);

            if (highScore) {
                highScore = JSON.parse(highScore);
            } else {
                highScore = [];
                localStorage.setItem(this.localStorageName, JSON.stringify(highScore));
            }

            return highScore;
        }

        public savePlayer(playerName:string, playerScore:string) {
            var highScoreList = this.getLocalStorageData();
            highScoreList.push({
                playerName: playerName,
                playerScore: playerScore
            });
            this.setLocalStorageData(highScoreList);
        }

        private setLocalStorageData(highScoreList) {
            localStorage.setItem(this.localStorageName, JSON.stringify(highScoreList));
        }

        public getHighScores() {
            return this.getLocalStorageData();
        }

        public static clearLocalStorage() {
            localStorage.clear();
        }
    }
}