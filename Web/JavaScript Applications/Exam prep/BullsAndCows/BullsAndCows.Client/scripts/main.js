var serverUrl = 'http://localhost:40643/';
var bcPersister = DataPersister.getPersister(serverUrl);

var user = {
    username: 'Joro',
    password: 'Joro'
};

bcPersister.user.login(user, function(data){
    alert(JSON.stringify(data));
}, function() {
    alert('Error');
});