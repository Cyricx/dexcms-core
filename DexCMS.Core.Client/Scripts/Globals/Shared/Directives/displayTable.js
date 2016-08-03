define([
    '../shared',
    'angular'
], function (app, angular) {

    app.directive('dexcmsDisplayTable', [
        'dexCMSGlobalsSharedSettings',
        function (dexcmsSettings) {
            return {
                restrict: 'E',
                templateUrl: dexcmsSettings.startingRoute + '/directives/_displayTable.html',
                scope: {
                    promiseData: '=',
                    columnStructure: '='
                },
                controller: [
                    '$scope',
                    '$compile',
                    'DTOptionsBuilder',
                    'DTColumnBuilder',
                    '$filter',
                    function ($scope, $compile, DTOptionsBuilder, DTColumnBuilder, $filter) {
                        $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                            return $scope.promiseData;
                        }).withBootstrap().withOption('createdRow', createdRow);


                        function createdRow(row, data, dataIndex) {
                            // Recompiling so we can bind Angular directive to the DT
                            $compile(angular.element(row).contents())($scope);
                        }

                        $scope.dtColumns = [];
                        angular.forEach($scope.columnStructure, function (column) {
                            var dtColumn = DTColumnBuilder.newColumn(column.property).withTitle(column.title);
                            if (column.disableSorting) {
                                dtColumn.notSortable();
                            }
                            if (column.renderFunction) {
                                dtColumn.renderWith(column.renderFunction);
                            }
                            if (column.renderAs) {
                                buildRenderAs(dtColumn, column.renderAs);
                            }
                            $scope.dtColumns.push(dtColumn);
                        });

                        function buildRenderAs(dtColumn, renderType) {
                            switch (renderType) {
                                case 'Date':
                                    dtColumn.renderWith(dateHtml);
                                    break;
                                default:
                                    break;
                            }
                        }
                        
                        function dateHtml(data, type, full, meta) {
                            if (data != null) {
                                return $filter('date')(data, "MM/dd/yyyy h:mm a");
                            } else {
                                return null;
                            }
                        }
                    }
                ]
            }
        }
    ]);
});