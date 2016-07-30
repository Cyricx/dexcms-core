define([
    'angular',
], function (angular) {
    return function (module) {
        module.directive('ttcmsHorizontalNav', [
            'dexCMSControlPanelSettings',
            function (ttcmsSettings) {
                return {
                    restrict: "E",
                    scope: {
                        "navigation": "="
                    },
                    templateUrl: ttcmsSettings.startingRoute + '/globals/directives/_ttcmsHorizontalNav.html',
                    link: function (scope, elem, attr) {

                    }
                }
            }
        ]);
    };
});