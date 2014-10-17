var encryption = require('../utilities/encryption');

var data = require('../data');

var URL_DELIMITER = '___';
var SALT = "FOSTATAKOVRI";
var FS_DELIMITER = '/';

module.exports = {
    download: function (req, res, next) {
        var url = req.params.url;
        var decryptedUrl = encryption.decrypt(url, SALT);
        var parts = decryptedUrl.split(URL_DELIMITER);
        var path = parts.join(FS_DELIMITER);
        res.download(__dirname + '/../../uploads/' + path   );
    }
};