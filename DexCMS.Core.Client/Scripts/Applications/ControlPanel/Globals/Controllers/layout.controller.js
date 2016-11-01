define([
    'json!../../config/dexcms.controlpanel.navigation.json',
    'underscore'
], function (navigationItems, _) {
    
    navigationItems = _.sortBy(navigationItems, 'title');

    return function (app) {
        app.controller('layoutCtrl', [
            '$scope',
            '$rootScope',
            function ($scope, $rootScope) {
                $scope.nonDefaultMenu = false;

                $scope.getMenuState = function () {
                    var menuClass = $scope.nonDefaultMenu ? 'non-default-menu' : '';
                    if ($scope.openWide) {
                        menuClass += ' force-open';
                    }
                    return menuClass;
                };
                $rootScope.cpUser = cpUser;

                $scope.showUserInfo = false;

                $rootScope.screens = navigationItems;
                $scope.openWide = false;
                $scope.changeAccordion = function (screen) {
                    if (screen.open) {
                        $scope.openWide = false;
                    } else {
                        $scope.openWide = true;
                    }

                }

            }
        ]);
    };
});