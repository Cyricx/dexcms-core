(function ($) {
    $.fn.dexCMSHighlightNav = function (options) {
        var settings = $.extend({
            cssClass: "active",
        }, options);
        var $nav = $(this);
        var locationUrl = location.href.toLowerCase();
        var hashUrl = locationUrl.indexOf('#');
        if (hashUrl > -1) {
            locationUrl = locationUrl.substring(0, hashUrl);
        }
        $nav.find("li a").each(function () {
            if (locationUrl === this.href.toLowerCase()) {
                $nav.find('li.' + settings.cssClass).removeClass(settings.cssClass);
                var $parentLI = $(this).parent();
                if ($parentLI.parents('li').length > 0) {
                    $parentLI.parents('li').addClass(settings.cssClass);
                }

                $parentLI.addClass(settings.cssClass);

                return false;
            }
        });
        return this;
    }
})(jQuery);