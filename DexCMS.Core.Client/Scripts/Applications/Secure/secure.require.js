var libs = '../../../../libs/';
require.config({
    urlArgs: "v=0.0.0",
    waitSeconds: 120,
    paths: {
        'secure-app': './secure',
        'secure-settings': './secure.settings',
        'dexcms-globals-shared': '../../globals/shared/index',
        'dexcms-globals-base': '../../globals/base/index',
        'dexcms-globals-tickets': '../../globals/tickets/index',
        'dexcms-routes-builder': '../../globals/shared/infrastructure/routesBuilder',
        'angular': libs + 'angular/angular.min',
        'angular-animate': libs + 'angular-animate/angular-animate.min',
        'angular-sanitize': libs + 'angular-sanitize/angular-sanitize.min',
        'angular-ui-router': libs + 'angular-ui-router/angular-ui-router.min',
        'angular-resource': libs + 'angular-resource/angular-resource.min',
        'bootstrap': libs + 'bootstrap/bootstrap.min',
        'jquery': libs + 'jquery/jquery.min',
        'moment': libs + 'moment/moment.min',
        'ngStorage': libs + 'ngstorage/ngStorage.min',
        'ngtoast': libs + 'ngtoast/ngtoast.min',
        'oclazyload': libs + 'oclazyload/ocLazyLoad.require.min',
        'tg-angular-validator': libs + 'tg-angular-validator/angular-validator.min',
        'underscore': libs + 'underscore/underscore-min',
        'json': libs + 'requirejs-plugins/json',
        'text': libs + 'text/text',
        'ui-bootstrap': libs + 'angular-bootstrap/ui-bootstrap.min',
        'ui-bootstrap-tpls': libs + 'angular-bootstrap/ui-bootstrap-tpls.min',
        'ui-bootstrap-datetimepicker': libs + 'angular-ui-bootstrap-datetimepicker/datetimepicker',
    },
    shim: {
        'angular': {
            exports: 'angular',
            deps: ['jquery']
        },
        'ngStorage': {
            deps: ['angular']
        },
        'angular-animate': {
            deps: ['angular']
        },
        'angular-resource': {
            deps: ['angular']
        },
        'angular-sanitize': {
            deps: ['angular']
        },
        'angular-ui-router': {
            deps: ['angular']
        },
        'jquery': {
            exports: '$'
        },
        'ngtoast': {
            deps: ['angular']
        },
        'oclazyload': {
            deps: ['angular']
        },
        'shared.directives': {
            deps: ['shared.services']
        },
        'tg-angular-validator': {
            deps: ['angular']
        },
        'underscore': {
            exports: "_"
        },
        'ui-bootstrap': {
            deps: ['jquery', 'bootstrap', 'angular']
        },
        'ui-bootstrap-tpls': {
            deps: ['angular', 'ui-bootstrap']
        },
        'ui-bootstrap-datetimepicker': {
            deps: ['ui-bootstrap', 'angular']
        },
    },
    deps: ['./secure.bootstrap']
});