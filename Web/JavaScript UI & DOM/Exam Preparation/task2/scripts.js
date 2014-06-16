$.fn.tabs = function () {
    var $this = $(this);
    $this.addClass('tabs-container');
    var $tabItems = $this.find('.tab-item');
    $tabItems.find('.tab-item-content').hide();

    $tabItems.find('.tab-item-title').on('click', function () {
        var $currentItem = this.parent();
        $tabItems.find('.tab-item-content').hide();
        $tabItems.removeClass('current');
        $currentItem.addClass('current');
        $currentItem.find('.tab-item-content').show();
        $currentItem.text();
    });
    $($tabItems[0])
        .addClass('current')
        .find('.tab-item-content').show();
};