define([
    'angular',
    'secure-settings',
    'json!config/dexcms.secure.routes.json',
    'dexcms-routes-builder',
    './globals/index',
    'ngStorage',
    'angular-animate',
    'angular-resource',
    'angular-sanitize',
    'angular-ui-router',
    'tg-angular-validator',
    'ngtoast',
    'oclazyload',
    'ui-bootstrap',
    'ui-bootstrap-tpls',
    'ui-bootstrap-datetimepicker',
    'dexcms-globals-shared',
    'dexcms-globals-base',
    'dexcms-globals-tickets'
], function (angular, settings, routeGroups, RoutesBuilder, globalsBuilder) {
    'use strict';

    var _appName = 'dexCMSSecureApp';
    var _routesBuilder = new RoutesBuilder(routeGroups, _appName);

    var secureApp = angular.module(_appName, [
        'ngStorage',
        'ngResource',
        'ngAnimate',
        'ngSanitize',
        'ui.router',
        'ui.bootstrap',
        'ui.bootstrap.datetimepicker',
        'angularValidator',
        'ngToast',
        'oc.lazyLoad',
        'dexCMSGlobalsShared',
        'dexCMSGlobalsBase',
        'dexCMSGlobalsTickets'
    ]);

    //Load setting constants
    secureApp.constant('dexCMSSecureSettings', settings);

    //Execute Global Builders
    globalsBuilder(secureApp);

    secureApp.config([
    '$ocLazyLoadProvider',
      '$stateProvider',
       '$urlRouterProvider',
       '$locationProvider',
        function ($ocLazyLoadProvider, $stateProvider, $urlRouterProvider, $locationProvider) {
            $locationProvider.html5Mode(true);

            $ocLazyLoadProvider.config({
                loadedModules: [],
                jsLoader: require
            });
            $urlRouterProvider.otherwise('/');

            _routesBuilder.constructRoutes($stateProvider, settings.startingRoute);
        }
    ]);


    return secureApp;
});