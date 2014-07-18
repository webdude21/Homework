module HighScore {
    export class LocalStorage {
        constructor() {

        }

        public savePlayer(playerName:string, playerScore:string) {
            localStorage.setItem(playerName, playerScore);
        }

        public displayHighScore(){
            for (var i = 0; i < arguments.length; i++) {
                var obj = arguments[i];
            }
        }

        public clearLocalStorage(){
            localStorage.clear();
        }
    }
}