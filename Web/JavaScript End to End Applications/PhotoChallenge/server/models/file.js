var mongoose = require('mongoose');
var fileSchema = mongoose.Schema({
    url: { type: String, require: '{PATH} is required', unique: true },
    uploadDate: { type: Date, default: Date.now },
    fileName: String,
    isPrivate: Boolean
});

var File = mongoose.model('File', fileSchema);