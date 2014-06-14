window.onload = function generateColorPicker(){
    $('<input type="color">')
        .appendTo('body')
        .on('change', function (event){
        $('body').css('backgroundColor', $(event.target).val());
    })
};