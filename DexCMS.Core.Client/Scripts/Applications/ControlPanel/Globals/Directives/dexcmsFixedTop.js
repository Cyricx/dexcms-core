define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('dexcmsFixedTop', function () {

            return {
                restrict: "EA",
                link: function (scope, elem, attr) {

                    scope.$watch('__height', function (newHeight, oldHeight) {
                        elem.children('div:nth-child(2)').css({ marginTop: newHeight + 20 });

                    })

                    scope.$watch(function () {
                        scope.__height = elem.children('div:first-child').height();
                    })
                }
            }
        });
    };
});