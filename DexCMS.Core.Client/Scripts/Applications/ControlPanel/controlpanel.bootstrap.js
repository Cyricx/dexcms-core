define([
    'require',
    'angular',
    'controlpanel-app',
], function (require, angular) {
    'use strict';
    require(['controlpanel-app'], function () {
        angular.bootstrap(document, ['dexCMSControlPanelApp']);
    });
});