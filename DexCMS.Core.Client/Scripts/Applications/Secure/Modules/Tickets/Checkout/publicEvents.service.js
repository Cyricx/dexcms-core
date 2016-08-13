﻿define([
   'secure-app'
], function (app) {
    app.service('PublicEvents', [
        '$resource',
        '$http',
        function ($resource, $http) {
            var baseUrl = '../api/publicEvents';

            return {
                //Get All 
                getList: function () {
                    return $resource(baseUrl).query().$promise;
                }
            };
        }
    ]);
});