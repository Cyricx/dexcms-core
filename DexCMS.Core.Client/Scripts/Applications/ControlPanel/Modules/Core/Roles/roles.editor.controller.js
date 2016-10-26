define([
    'controlpanel-app'
], function (app) {
    app.controller('rolesEditorCtrl', [
        '$scope',
        'Roles',
        '$stateParams',
        '$state',
        function ($scope, Roles, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Role";

            $scope.currentItem = {};

            if (id != null) {
                Roles.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.id) {
                    Roles.updateItem(item.id, item).then(function (response) {
                        $state.go('roles');
                    });
                } else {
                    Roles.createItem(item).then(function (response) {
                        $state.go('roles');
                    });
                }
            }
        }
    ]);
});