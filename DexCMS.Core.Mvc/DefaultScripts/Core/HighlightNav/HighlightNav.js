(function ($) {
    $.fn.dexCMSHighlightNav = function (options) {
    var settings = $.extend({
        cssClass: "active",
    }, options);
    var $nav = $(this);
    $nav.find("li a").each(function () {
        if (location.href.toLowerCase() === this.href.toLowerCase())
        {
            $nav.find('li.' + settings.cssClass).removeClass(settings.cssClass);
            var $parentLI = $(this).parent();
            if ($parentLI.parents('li').length > 0)
            {
                $parentLI.parents('li').addClass(settings.cssClass);
            }
            else
            {
                $parentLI.addClass(settings.cssClass);
            }
            return false;
        }
    });
    return this;
}
})(jQuery);