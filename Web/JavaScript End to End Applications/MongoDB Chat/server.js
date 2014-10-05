var express = require('express');

var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./server/config/config')[env];

require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);

app.listen(config.port);
console.log("Server running on port: " + config.port);

var chatDb = require('./server/data/chat-db');

//inserts a new user records into the DB
chatDb.registerUser({user: 'DonchoMinkov', pass: '123456q'});
chatDb.registerUser({user: 'NikolayKostov', pass: '123456q'});

//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov'
}, function(messages){
    console.log(messages)
});
