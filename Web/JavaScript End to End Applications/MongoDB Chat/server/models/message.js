var mongoose = require('mongoose');

var messageSchema = mongoose.Schema({
    from: {
        type: mongoose.Schema.ObjectId,
        ref: 'User',
        required: true
    },
    to: {
        type: mongoose.Schema.ObjectId,
        ref: 'User',
        required: true
    },
    text: {
        type: String,
        required: true
    }
});

var Message = mongoose.model('Message', messageSchema);

module.exports.seedInitialMessages = function () {
    Message.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find messages: ' + err);
            return;
        }

        if (collection.length === 0) {
            var User = mongoose.model('User');
            User.find({}).exec(function (err, userCollection) {
                if (err) {
                    console.log('Cannot find users: ' + err);
                }

                var firstUser = userCollection[0];
                var secondUser = userCollection[1];

                Message.create({from: firstUser, to: secondUser, text: "Testis Testis"});
                Message.create({from: secondUser, to: firstUser, text: "Testis Testis"});
                console.log('Messages added to database...');
            });
        }
    });
};
