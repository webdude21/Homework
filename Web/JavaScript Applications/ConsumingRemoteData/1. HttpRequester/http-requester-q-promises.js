var HttpRequester = (function () {

    var promiseAjaxRequest = function (url, type, data) {
        var defferedAjax = Q.defer();

        if (data) {
            data = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: "application/json",
            success: function (responseData) {
                defferedAjax.resolve(responseData);
            },
            error: function (errorData) {
                defferedAjax.reject(errorData);
            }
        });

        return defferedAjax.promise;
    };

    var promiseAjaxRequestGet = function (url) {
        return promiseAjaxRequest(url, "get");
    };

    var promiseAjaxRequestPost = function (url, data) {
        return promiseAjaxRequest(url, "post", data);
    };

    return {
        getJson: promiseAjaxRequestGet,
        postJson: promiseAjaxRequestPost
    }
}());