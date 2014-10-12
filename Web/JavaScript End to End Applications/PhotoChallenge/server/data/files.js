var File = require('mongoose').model('File');

module.exports = {
    addFiles: function (files) {
        var addedFiles = [];

        for (var i = 0; i < files.length; i++) {
            addedFiles.push(new File(files[i]));
        }

        addedFiles.forEach(function (file){
            file.save();
        });

        return addedFiles;
    }
};