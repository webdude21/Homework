$('#test').on('click', test);

function test() {
    var msgBox = $('#message-box').messageBox();
    msgBox.success('Success!');
    setTimeout(function () {
        msgBox.error('Error!');
    }, 5000);
}

$.fn.messageBox = function messageBox() {
    var $that = this;
    var fadeInterval = 1000;
    return {
        displayMessage: function (message, type) {
            $that.each(function () {
                if (type === 'success') {
                    var backgroundColor = 'green';
                }
                $that.css('background-color', backgroundColor || 'red');
                $that.animate({ 'opacity': 1 }, fadeInterval);
                $(this).text(message);
                setInterval(function () {
                    $that.animate({ 'opacity': 0 }, fadeInterval);
                }, 3000);
            });
            return $that;
        },
        success: function (message) {
            this.displayMessage(message, 'success');
        },
        error: function (message) {
            this.displayMessage(message);
        }
    }
};