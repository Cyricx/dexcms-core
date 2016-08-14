var libs = '../../../../libs/';
require.config({
    urlArgs: "v=0.0.0",
    waitSeconds: 120,
    paths: {
        'controlpanel-app': './controlpanel',
        'controlpanel-settings': './controlpanel.settings',
        'dexcms-globals-shared': '../../globals/shared/index',
        'dexcms-routes-builder': '../../globals/shared/infrastructure/routesBuilder',
        'angular': libs + 'angular/angular.min',
        'angular-drag-and-drop-lists': libs + 'angular-drag-and-drop-lists/angular-drag-and-drop-lists.min',
        'angular-sanitize': libs + 'angular-sanitize/angular-sanitize.min',
        'angular-smart-table': libs + 'angular-smart-table/smart-table.min',
        'angular-ui-router': libs + 'angular-ui-router/angular-ui-router.min',
        'angular-resource': libs + 'angular-resource/angular-resource.min',
        'jquery': libs + 'jquery/jquery.min',
        'json': libs + 'requirejs-plugins/json',
        'bootstrap': libs + 'bootstrap/bootstrap.min',
        'moment': libs + 'moment/moment.min',
        'ng-file-upload': libs + 'ng-file-upload/ng-file-upload.min',
        'ng-file-upload-shim': libs + 'ng-file-upload/ng-file-upload-shim.min',
        'ngtoast': libs + 'ngtoast/ngtoast.min',
        "ng-csv": libs + 'ng-csv/ng-csv.min',
        'oclazyload': libs + 'oclazyload/ocLazyLoad.require.min',
        'tg-angular-validator': libs + 'tg-angular-validator/angular-validator.min',
        'text': libs + 'text/text',
        'tinymce': libs + 'tinymce/tinymce.min',
        'ui-bootstrap': libs + 'angular-bootstrap/ui-bootstrap.min',
        'ui-bootstrap-tpls': libs + 'angular-bootstrap/ui-bootstrap-tpls.min',
        'ui-bootstrap-datetimepicker': libs + 'angular-ui-bootstrap-datetimepicker/datetimepicker',
        'ui-tinymce': libs + 'angular-ui-tinymce/tinymce',
        'underscore': libs + 'underscore/underscore-min'
    },
    shim: {
        'angular': {
            exports: 'angular',
            deps: ['jquery']
        },
        'angular-drag-and-drop-lists': {
            deps: ['angular']
        },
        'angular-resource': {
            deps: ['angular']
        },
        'angular-route': {
            deps: ['angular']
        },
        'angular-sanitize': {
            deps: ['angular']
        },
        'angular-smart-table': {
            deps: ['angular']
        },
        'angular-ui-router': {
            deps: ['angular']
        },
        'bootstrap': {
            deps: ['jquery']
        },
        'jquery': {
            exports: '$'
        },
        'ng-file-upload': {
            deps: ['ng-file-upload-shim']
        },
        'ng-file-upload-shim': {
            deps: ['angular']
        },
        'ngtoast': {
            deps: ['angular']
        },
        'ng-csv': {
            deps: ['angular', 'angular-sanitize']
        },
        'oclazyload': {
            deps: ['angular']
        },
        'tg-angular-validator': {
            deps: ['angular']
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
        'ui-tinymce': {
            deps: ['angular', 'tinymce']
        },
        'underscore': {
            exports: "_"
        }
    },
    deps: ['./controlpanel.bootstrap']
});