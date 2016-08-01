define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('dexcmsHorizontalNav', [
            'dexCMSControlPanelSettings',
            function (dexcmsSettings) {
                return {
                    restrict: "E",
                    scope: {
                        "navigation": "="
                    },
                    templateUrl: dexcmsSettings.startingRoute + '/globals/directives/_dexcmsHorizontalNav.html',
                    link: function (scope, elem, attr) {

                    }
                }
            }
        ]);
    };
});