function getIndex(req, res, fileSystem) {
    fileSystem.readFile('./index.html', function (err, data) {
        if (err){
            console.log(err);
        }
        res.writeHead(200, {'Content-Type': 'text/html'});
        res.write(data);
        res.end()
    });
}

module.exports = getIndex;