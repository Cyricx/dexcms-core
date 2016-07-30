define([
    'controlpanel-app'
], function (app) {
    app.controller('dashboardCtrl', [
        '$scope',
        function ($scope) {
            $scope.title = "Dashboard";
        }
    ]);
});