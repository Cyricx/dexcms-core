﻿(function ($) {
    $.fn.dexCMSSideMenu = function (options) {
    var settings = $.extend({
        // These are the defaults.
        trigger: "#nav-toggle",
    }, options);

    var $sidemenu = $(this);
    $sidemenu.find('.submenu > ul').hide();
    $sidemenu.find('.submenu > a').click(function (e) {
        e.preventDefault();
        var $link = $(this);
        var $parent = $link.parent();
        if ($parent.hasClass('open')) {
            $parent.removeClass('open').children('ul').slideUp();
        } else {
            $parent.addClass('open').children('ul').slideDown();
        }
    });
    $(settings.trigger).click(function () {
        if ($sidemenu.width() > 0) {
            $sidemenu.animate({ width: '0' },
                500, function () { $(this).removeClass('menu-show'); });
        }
        else {
            var docHeight = $(document).height();
            $sidemenu.addClass('menu-show').animate({ width: '75%' },
                500, function () { }).css('min-height', docHeight + 'px');
        }
    });
    return this;
}
})(jQuery);