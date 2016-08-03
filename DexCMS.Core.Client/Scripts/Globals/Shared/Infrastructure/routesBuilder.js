define([
    'angular'
], function (angular) {
    var routesBuilder = function (routeGroups, appName) {
        var builder = this;
        builder.routeGroups = routeGroups;
        builder.appName = appName;

        builder.buildResolver = function (moduleFolder) {
            return {
                load: ['$q', '$ocLazyLoad', function ($q, $ocLazyLoad) {
                    var deferred = $q.defer();
                    require([moduleFolder + '/index'], function () {
                        $ocLazyLoad.inject(builder.appName);
                        deferred.resolve();
                    })
                    return deferred.promise;
                }]
            };
        };

        builder.setupRouteGroup = function (routeGroup) {
            var defaultRoutes = [
                { viewType: 'list', path: '' },
                { viewType: 'editor', path: '/new' },
                { viewType: 'editor', path: '/:id' }
            ];
            routeGroup.routes = routeGroup.routes || defaultRoutes;
            routeGroup.loweredName = routeGroup.name.toLowerCase();
            routeGroup.moduleFolder = 'modules/' + routeGroup.module + '/' + routeGroup.name + '/';
            routeGroup.moduleFolderPath = builder.buildCmsModulePath(routeGroup);

            return routeGroup;
        };

        builder.buildTemplateUrl = function (route, routeGroup, startingRoute) {
            return startingRoute + routeGroup.moduleFolder + '/' + routeGroup.loweredName + '.' +
                    route.viewType + '.html';
        };

        builder.buildControllerName = function (route, routeGroup) {
            var controllerType = route.viewType.substr(0, 1).toUpperCase() + route.viewType.substr(1);
            return routeGroup.name + controllerType + 'Ctrl';
        };

        builder.buildCmsModulePath = function (routeGroup) {
            return 'modules/' + routeGroup.module + '/' + routeGroup.loweredName;
        };

        builder.setRoute = function ($stateProvider, route, routeGroup, startingRoute) {
            var fullPath = routeGroup.loweredName + route.path;

            $stateProvider.state(fullPath, {
                url: '/' + fullPath,
                templateUrl: builder.buildTemplateUrl(route, routeGroup, startingRoute),
                controller: builder.buildControllerName(route, routeGroup),
                resolve: builder.buildResolver(routeGroup.moduleFolderPath)
            });
        };

        builder.processRoutes = function ($stateProvider, routeGroups, startingRoute) {
            angular.forEach(routeGroups, function (routeGroup) {
                routeGroup = builder.setupRouteGroup(routeGroup);

                angular.forEach(routeGroup.routes, function (route) {
                    builder.setRoute($stateProvider, route, routeGroup, startingRoute);
                });
            });
        };

        builder.constructRoutes = function ($stateProvider, startingRoute) {
            //dashboard route
            $stateProvider
                .state('dashboard', {
                    url: '/',
                    templateUrl: '../' + startingRoute + 'dashboard/dashboard.view.html',
                    controller: 'dashboardCtrl',
                    resolve: builder.buildResolver('dashboard')
                });
            //process cms routes
            builder.processRoutes($stateProvider, builder.routeGroups, startingRoute);
        };

        return builder;
    };

    return routesBuilder;
});