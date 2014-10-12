var Contestant = require('mongoose').model('Contestant');

module.exports = {
    addContestant: function (contestant) {
        var newContestant = new Contestant(contestant);
        newContestant.save();
        return newContestant;
    },
    getAll: function (error, success) {
        Contestant.find()
            .populate('pictures')
            .lean()
            .exec(function (err, contestants) {
                if (err) {
                    error();
                } else {
                    if (contestants) {
                        success(contestants);
                    } else {
                        error()
                    }
                }
            });
    },
    getById: function (id, error, success) {
        Contestant.findById(id)
            .populate('pictures')
            .lean()
            .exec(function (err, contestant) {
                if (err) {
                    error();
                } else {
                    if (contestant) {
                        success(contestant);
                    } else {
                        error()
                    }
                }
            });
    }
};