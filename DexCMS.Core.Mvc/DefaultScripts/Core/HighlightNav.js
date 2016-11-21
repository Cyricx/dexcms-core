(function ($) {
//creating a jQuery function called highlightNav
    $.fn.highlightNav = function (options) {

    //allowing plugin users to specify a different cssClass
    var settings = $.extend({
        // These are the defaults.
        cssClass: "active",
    }, options);
    var path = location.href.toLowerCase();
    //console.log('Current path is ' + path);
    var $nav = $(this);

    $nav.find("li a").each(function () {

        var hrefTest = this.href.toLowerCase();
        //console.log('testing.. ' + hrefTest);

        if (path === hrefTest)
        {
            //found hrefTest in the path
            //console.log('found a match');
            //make sure no LI's have the class on them yet
            $nav.find('li.' + settings.cssClass).removeClass(settings.cssClass);

            //get the parent LI
            var $parentLI = $(this).parent();
            
            //if it is a nested LI, add the class to its parent
            if ($parentLI.parents('li').length > 0)
            {
                //console.log('match was a nested li, add class to outer parent li');
                $parentLI.parents('li').addClass(settings.cssClass);
            }
            else
            {
                //console.log('match was an outer li, class added to it');
                $parentLI.addClass(settings.cssClass);
            }

            //break out of the loop
            return false;
        }
    });//end foreach li
    return this;//don't break the chain, return the nav object
}
})(jQuery);