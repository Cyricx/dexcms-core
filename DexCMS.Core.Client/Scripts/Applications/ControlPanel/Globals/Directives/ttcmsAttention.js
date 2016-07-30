define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('ttcmsAttention', ['$parse',
            function ($parse) {
                return {
                    restrict: "A",
                    link: function (scope, elem, attr) {
                        var status = $parse(attr.ttcmsAttention)(scope);

                        if (status) {
                            elem.addClass('attention-box');
                            elem.prepend('<div class="attention-icon text-danger" title="' + attr.attentionMessage +
                                    '"><i class="fa fa-exclamation-triangle"></i></div>');
                        } else {
                            elem.removeClass('attention-box');
                            elem.children('.attention-icon').remove();
                        }

                    }
                }
            }
        ]);
    };
});