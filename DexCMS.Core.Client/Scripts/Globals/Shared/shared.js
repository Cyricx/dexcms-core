define([
    'angular',
    './shared.settings'
], function (angular, settings) {
    var globalSharedApp = angular.module('dexCMSGlobalsShared', []);

    globalSharedApp.constant('dexCMSGlobalsSharedSettings', settings);

    return globalSharedApp;
})