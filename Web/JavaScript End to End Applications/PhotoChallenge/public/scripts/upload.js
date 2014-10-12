$(document).ready(function () {
    var $form = $('#sign-up-form');
    var $buttonPanel = $('#button-panel');

    $buttonPanel.find('#add-file').on('click', function () {
        var count = $form.children($('.upload-picture'));
        var html = $('<div class="form-group"><label for="file-' + count +
            '" class="col-md-2 control-label"' +
            '>Picture</label><div class="col-md-10"><input id="file-' + count +
            '" type="file" name="file_' + count + '" class="form-control upload-picture"></div></div>');

        $buttonPanel.before(html);
        return false;
    })
});