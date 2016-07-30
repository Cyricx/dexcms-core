define([
    './controllers/index',
    './directives/index',
    './filters/index'
], function (buildControllers, buildDirectives, buildFilters) {
    //return builder function
    return function (app) {
        buildControllers(app);
        buildDirectives(app);
        buildFilters(app);
    };
});