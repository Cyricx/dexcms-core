define([
    'controlpanel-app',
    '../roles/roles.service'
], function (app) {
    app.controller('usersEditorCtrl', [
        '$scope',
        'Users',
        '$stateParams',
        '$state',
        'Roles',
        function ($scope, Users, $stateParams, $state, Roles) {
            
            var id = $stateParams.id || null;
            
            Roles.getList().then(function (data) {
                $scope.roles = data;
            });
            
            $scope.title = (id == null ? "Add " : "Edit ") + "User";
            
            $scope.currentItem = {};
            
            if (id != null) {
                Users.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                    angular.forEach($scope.roles, function (role) {
                        role.isSelected = false;
                        angular.forEach($scope.currentItem.roles, function (userRole) {
                            if (userRole.id === role.id) {
                                role.isSelected = true;
                            }
                        });
                    });
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
            };
            
            $scope.changeRole = function (item, role) {
                if (role.isSelected) {
                    for (var i = 0; i < item.roles.length; i++) {
                        if (item.roles[i].id === role.id) {
                            item.roles.splice(i, 1);
                            role.isSelected = false;
                            return;
                        }
                    }
                } else {
                    role.isSelected = true;
                    item.roles.push(role);
                }
            };
        }
    ]);
});