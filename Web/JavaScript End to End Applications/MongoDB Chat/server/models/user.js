var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    user: { type: String, require: '{PATH} is required', unique: true },
    pass: { type: String, require: '{PATH} is required' }
});

var User = mongoose.model('User', userSchema);

module.exports.seedInitialUsers = function () {
    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {
            User.create({user: 'testis', pass: 'testis'});
            User.create({user: 'testis2', pass: 'testis2'});
            console.log('Users added to database...');
        }
    });
};