define([
    'angular',
    'controlpanel-settings',
    'json!config/dexcms.controlpanel.routes.json',
    'dexcms-routes-builder',
    //global builders
    './globals/index',
    'angular-resource',
    'angular-sanitize',
    'angular-ui-router',
    'tg-angular-validator',
    'ngtoast',
    'ui-bootstrap',
    'ui-bootstrap-tpls',
    'ui-bootstrap-datetimepicker',
    'ui-tinymce',
    'angular-drag-and-drop-lists',
    'ng-file-upload',
    'oclazyload',
    'dexcms-globals-shared',
], function (angular, settings, routeGroups, RoutesBuilder, globalsBuilder) {
    'use strict';
    var _appName = 'dexCMSControlPanelApp';
    var _routesBuilder = new RoutesBuilder(routeGroups, _appName);

    var cpApp = angular.module(_appName, [
        'ngResource',
        'ui.bootstrap',
        'ui.bootstrap.datetimepicker',
        'ui.tinymce',
        'ngFileUpload',
        'dndLists',
        'ui.router',
        'oc.lazyLoad',
        'ngSanitize',
        'angularValidator',
        'ngToast',
        'dexCMSGlobalsShared',
    ]);

    //Load setting constants
    cpApp.constant('dexCMSControlPanelSettings', settings);

    //Execute Global Builders
    globalsBuilder(cpApp);

    cpApp.config([
        '$ocLazyLoadProvider',
        '$stateProvider',
        '$urlRouterProvider',
        '$locationProvider',
        '$httpProvider',
        '$qProvider',
        function ($ocLazyLoadProvider, $stateProvider, $urlRouterProvider, $locationProvider, $httpProvider, $qProvider) {
            $locationProvider.html5Mode(true);
            $qProvider.errorOnUnhandledRejections(false);

            $ocLazyLoadProvider.config({
                loadedModules: [],
                jsLoader: require
            });
            $urlRouterProvider.otherwise('/');

            _routesBuilder.constructRoutes($stateProvider, settings.startingRoute);

            return $httpProvider.interceptors.push('DexCMSCacheBuster');
        }
    ]);

    return cpApp;
});