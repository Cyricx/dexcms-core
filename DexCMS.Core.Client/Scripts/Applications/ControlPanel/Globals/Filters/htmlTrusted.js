define([
], function () {
    //Automatically marks html to be trusted by the sanitizer when you use this filter with ng-bind-html
    //Example:
    //<div ng-bind-html="someobject.htmlproperty | html_trusted"></div>
    return function (app) {
        app.filter('html_trusted', ['$sce', function ($sce) {
            return function (text) {
                return $sce.trustAsHtml(text);
            };
        }]);
    };
})