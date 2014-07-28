var httpRequester = (function () {

    var requestTimeout = 5000; // milliseconds

    function getJSON(url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            timeout: requestTimeout,
            contentType: "application/json",
            success: success,
            error: error
        });
    }

    function postJSON(url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            timeout: requestTimeout,
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    }

    function deleteRequest(url, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            timeout: requestTimeout,
            success: success,
            error: error,
            data: {_method: 'DELETE'}
        });
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        deleteRequest: deleteRequest
    };
}());