﻿define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('dexcmsHtmlEditor', function () {

            return {
                restrict: "EA",
                template: "<textarea class='form-control' ui-tinymce='tinymceOptions' ng-model='value'></textarea>",
                require: 'ngModel',
                scope: {
                    value: '=ngModel'
                },
                controller: ['$scope', 'dexCMSControlPanelSettings', function ($scope, dexcmsSettings) {
                    $scope.tinymceOptions = {
                        plugins: ['table code anchor autolink lists preview link paste image'],
                        toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
                        content_css: (dexcmsSettings.baseUrl ? dexcmsSettings.baseUrl + 'content/editor.css' : ''),
                        convert_urls: 0,
                        image_dimensions: false,
                        extended_valid_elements: "script[language|type|src]"
                    };

                }]
            }
        });
    };
});