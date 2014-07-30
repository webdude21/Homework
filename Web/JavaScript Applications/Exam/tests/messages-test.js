define(['messages'], function (Messages) {
    var correctUrl = 'http://crowd-chat.herokuapp.com/posts';
    var inccorectUrl = 'http://crowd-chat.herokuapp.com/postsqweqweqweqwe';
    describe("Message function", function () {
        it("GetMessage work correct", function (done) {
            var expected = 2;
            Messages.getAllMessages(correctUrl)
            .then(function (data) {
                returnedStatus = (data.xhr.status / 100) | 0;
                expect(expected).to.deep.equal(returnedStatus);
                done();
            }).done(null, done);
        });
        it("GetMessage work incorrect url", function (done) {
            var expected = 4;
            Messages.getAllMessages(inccorectUrl)
            .then(function (data) {
                returnedStatus = (data.xhr.status/ 100) | 0;
                expect(expected).to.deep.equal(returnedStatus);
                done();
            }, function (err) {
                returnedStatus = (err.status / 100) | 0;
                expect(expected).to.deep.equal(returnedStatus);
                done();
            }).done(null, done);
        });
        it("Test valid message sending", function (done) {
            var expectedData = true;
            var expectedTextStatus = 'success';
            var expectedStatus = 2;
            Messages.sendMessage("Pesho", "Pesho")
                .then(function (result) {
                    expect(result.data).to.be.equal(expectedData);
                    expect(result.textStatus).to.be.deep.equal(expectedTextStatus);
                    var returnedStatus = (result.xhr.status / 100) | 0;
                    expect(returnedStatus).to.deep.equal(expectedStatus);
                    done();
                }).done(null, done);
        })
    });
});