var fileSystem = require('fs');
var UPLOAD_DIR = __dirname + '/../../uploads/';

module.exports = {
    createDir: function (path, dirName) {
        dirName = dirName || '';
        fileSystem.mkdirSync(UPLOAD_DIR + path + dirName)
    },
    createUserFolder: function (user) {
        this.createDir(user.username);
    },
    saveFile: function (file, fileName, path) {
        if (!fileSystem.existsSync(UPLOAD_DIR + path)) {
            this.createDir(path)
        }

        file.pipe(fileSystem.createWriteStream(UPLOAD_DIR + path + fileName));
    }
};