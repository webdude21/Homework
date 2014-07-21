var serverUrl = 'http://localhost:40643/api';
var bcPersister = DataPersister.getPersister(serverUrl);
var sessionKey = '';

userName = 'dimop';
password = '1234567';

var user = {
    username: userName,
    password: password
};

var registerUser = {
    username: userName,
    nickname: 'webdude the greatest',
    password: password
};

//bcPersister.user.register(registerUser, function (data) {
//    alert(JSON.stringify(data));
//}, function (err) {
//    alert(JSON.stringify(err));
//});

// bcPersister.user.login(user, saveSessionKey, loginError);

function saveSessionKey(data){
    sessionKey = data.sessionKey;
}

function loginError(data){
    JSON.stringify(data);
}

var controller = controllers.get();
controller.loadUI('#wrapper');