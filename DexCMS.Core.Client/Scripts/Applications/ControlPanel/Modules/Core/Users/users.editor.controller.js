define([
    'controlpanel-app'
], function (app) {
    app.controller('usersEditorCtrl', [
        '$scope',
        'Users',
        '$stateParams',
        '$state',
        function ($scope, Users, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "User";

            $scope.currentItem = {};

            if (id != null) {
                Users.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.id) {
                    Users.updateItem(item.id, item).then(function (response) {
                        $state.go('users');
                    });
                } else {
                    Users.createItem(item).then(function (response) {
                        $state.go('users');
                    });
                }
            }
        }
    ]);
});