define([
    '../shared',
    'angular'
], function (app, angular) {
    app.directive('dexDataTable', [
        'dexCMSGlobalsSharedSettings',
        function (dexcmsSettings) {
            return {
                restrict: 'E',
                replace: true,
                scope: {
                    table: '='
                },
                templateUrl: dexcmsSettings.startingRoute + 'directives/_dataTable.html',
                controller: [
                    '$scope',
                    function ($scope) {
                        $scope.pagingTemplate = dexcmsSettings.startingRoute + 'directives/_dataTable.pagination.html';
                        $scope.itemsByPage = 10;

                        var _headers = [];
                        var _builtHeaders = false;

                        $scope.getValue = function (property, item) {
                            if (property.indexOf('.') > 0) {
                                var value = item;
                                var props = property.split('.');
                                angular.forEach(props, function (prop) {
                                    value = value[prop];
                                });
                                return value;
                            } else {
                                return item[property];
                            }
                        };
                        $scope.getFileName = function (isFiltered) {
                            var filename = isFiltered ? 'Filtered-Data.csv' : 'Full-Data.csv';
                            if ($scope.table.filePrefix) {
                                filename = $scope.table.filePrefix + '-' + filename;
                            }
                            return filename;
                        };
                        $scope.isDefaultSortColumn = function (col, table) {
                            return !col.disableSorting && col.property == table.defaultSort;
                        };
                        $scope.isDescending = function (col, table) {
                            if ($scope.isDefaultSortColumn(col, table)) {
                                return table.defaultSortDescending;
                            }
                        };
                        $scope.getHeaders = function (data) {
                            if (data && !_builtHeaders) {
                                if (data.length > 0) {
                                    angular.forEach(data[0], function (prop, key) {
                                        if (key != '$$hashKey') {
                                            _headers.push(key);
                                        }
                                    });
                                    _builtHeaders = true;
                                }
                                return _headers;
                            } else {
                                return _headers;
                            }
                        };

                        $scope.processData = function (collection) {
                            var processedData = [];
                            angular.forEach(collection, function (item) {

                                processedData.push(_processObject(item));
                            });
                            return processedData;
                        };

                        var _processObject = function (item) {
                            var processedItem = {};

                            angular.forEach(item, function (prop, key) {
                                if (prop && typeof (prop) === 'object') {
                                    var value = '';
                                    if (angular.isArray(prop)) {
                                        angular.forEach(prop, function (innerItem) {
                                            value += _stringObject(innerItem);
                                        });
                                    } else if (angular.isDate(prop)) {
                                        value = prop.toString();
                                    } else {
                                        value = _stringObject(prop);
                                    }
                                    processedItem[key] = value;
                                } else {
                                    processedItem[key] = prop;
                                }
                            });
                            return processedItem;
                        };

                        var _stringObject = function (item) {
                            var obj = [];
                            angular.forEach(item, function (prop, key) {
                                if (key != '$$hashKey') {
                                    if (prop && typeof (prop) === 'object') {
                                        var value = '';
                                        if (angular.isArray(prop)) {
                                            angular.forEach(prop, function (innerItem) {
                                                obj.push(_stringObject(innerItem));
                                            });
                                        } else if (angular.isDate(prop)) {
                                            obj.push(prop.toString());
                                        } else {
                                            obj.push(_stringObject(prop));
                                        }
                                    } else {
                                        obj.push(prop);
                                    }
                                }
                            });
                            return obj.join();
                        };
                    }
                ],
            }
        }
    ]);
});