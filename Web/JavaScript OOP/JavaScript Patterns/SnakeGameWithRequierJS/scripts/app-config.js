(function(){
    require.config({
        paths:{
            'extensions': 'extension-methods',
            'startGame' : 'snake-main',
            'gameObject': 'game-object'
        }
    });

    require(['startGame'], function (startGame){
        document.getElementById('btn-start').addEventListener('click', startGame);
    });
}());