var cpNavigation = require('./controlpanel.core.navigation'),
    cpRoutes = require('./controlpanel.core.routes'),
    cpSettings = require('./controlpanel.core.settings'),
    globalSettings = require('./globals.core.settings'),
    secureSettings = require('./secure.core.settings');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    settings.push(cpSettings(appPath));
    settings.push(globalSettings(appPath));
    settings.push(secureSettings(appPath));
    return settings;
};