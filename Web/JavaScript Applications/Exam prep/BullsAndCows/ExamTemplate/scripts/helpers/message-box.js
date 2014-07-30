'use strict';
define(['jquery'], function($) {
    function messageBox(message, container, type) {
        var boxType = type || 'success';
        var html = '<div class="alert alert-dismissable alert-' + boxType + '">' +
            '<button type="button" class="close" data-dismiss="alert">×</button>' +
            '<strong>' + message + '</strong></div>';
        $(container).append($(html));
    }

    function success(message, container) {
        messageBox(message, container);
    }

    function error(message, container) {
        messageBox(message, container, 'danger');
    }

    return {
        success: success,
        error: error
    }
});