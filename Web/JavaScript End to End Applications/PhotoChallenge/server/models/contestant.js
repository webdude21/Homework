var mongoose = require('mongoose');

var contestantSchema = mongoose.Schema({
    fullName: { type: String, require: '{PATH} is required' },
    age: { type: Number, require: '{PATH} is required', min: 0 },
    registerDate: { type: Date, default: Date.now },
    votes: [
        {
            type: mongoose.Schema.ObjectId,
            ref: 'User',
            unique: true
        }
    ],
    registrant: {
        type: mongoose.Schema.ObjectId,
        ref: 'User'
    },
    comment: String,
    pictures: [
        {
            type: mongoose.Schema.ObjectId,
            ref: "File"
        }
    ]
});

var Contestant = mongoose.model('Contestant', contestantSchema);