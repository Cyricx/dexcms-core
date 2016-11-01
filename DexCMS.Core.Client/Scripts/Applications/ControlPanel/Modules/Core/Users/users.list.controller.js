define([
    'controlpanel-app',
], function (app) {
    app.controller('usersListCtrl', [
        '$scope',
        'Users',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, Users, $window, dexcmsSettings) {
            $scope.title = "View Users";

            $scope.table = {
                columns: [
                    { property: 'id', title: 'ID' },
                    { property: 'firstName', title: 'First' },
                    { property: 'lastName', title: 'Last' },
                    { property: 'preferredName', title: 'Preferred' },
                    { property: 'email', title: 'Email' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/core/users/_users.list.buttons.html'
                    },
                ],
                defaultSort: 'id',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Users.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Users'
            };

            Users.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});