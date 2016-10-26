define([
    'controlpanel-app'
], function (app) {
    app.controller('rolesListCtrl', [
        '$scope',
        'Roles',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, Roles, $window, dexcmsSettings) {
            $scope.title = "View Roles";

            $scope.table = {
                columns: [
                    { property: 'id', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'userCount', title: 'User Count' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/core/roles/_roles.list.buttons.html'
                    },
                ],
                defaultSort: 'id',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Roles.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Roles'
            };

            Roles.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});