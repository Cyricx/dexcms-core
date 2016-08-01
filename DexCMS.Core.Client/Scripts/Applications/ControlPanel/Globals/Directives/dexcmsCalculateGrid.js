define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('dexcmsCalculateGrid', function () {

            return {
                restrict: "A",
                scope: {
                    "collection": "=",
                    "minColSize": "@"
                },
                link: function (scope, elem, attr) {
                    var minColSize = scope.minColSize || 3;

                    elem.removeClass(function (index, css) {
                        return (css.match(/(^|\s)col-\S+/g) || []).join(' ');
                    });

                    var columnWidth = 1;

                    if (scope.collection.length < 12) {
                        columnWidth = Math.floor(12 / scope.collection.length);
                    }
                    if (columnWidth < minColSize) {
                        columnWidth = minColSize;
                    }
                    elem.addClass("col-xs-" + (columnWidth * 2) + " col-md-" + columnWidth);
                }
            }
        });
    };
});