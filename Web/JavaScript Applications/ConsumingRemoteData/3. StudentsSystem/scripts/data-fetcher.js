var DataFetcher = (function () {

    var DataFetcher = (function () {

        function DataFetcher(rootUrl) {
            this.rootUrl = rootUrl;
        }

        DataFetcher.prototype.getAllStudents = function (success, error) {
            httpRequester.getJSON(this.rootUrl, success, error);
        };

        DataFetcher.prototype.postStudent = function (student, success, error) {
            httpRequester.postJSON(this.rootUrl, student, success, error);
        };

        DataFetcher.prototype.deleteStudent = function (studentId, success, error) {
            var url = this.rootUrl + '/' + studentId;
            httpRequester.detelteRequest(url, success, error);
        };

        return DataFetcher;
    }());

    return {
        getFetcher: function (url) {
            return new DataFetcher(url);
        }
    };
}());