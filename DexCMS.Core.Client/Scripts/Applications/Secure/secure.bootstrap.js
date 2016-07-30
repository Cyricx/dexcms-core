define([
    'require',
    'angular',
    'secure-app',
], function (require, angular) {
    'use strict';
    require(['secure-app'], function () {
        angular.bootstrap(document, ['dexCMSSecureApp']);
    });
});