var cpSettings = require('./controlpanel.core.settings'),
    secureSettings = require('./secure.core.settings');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};

    var settings = [];
    settings.push(cpSettings(appPath));
    settings.push(secureSettings(appPath));
    return settings;
};