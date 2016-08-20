define([
    'json!config/dexcms.controlpanel.settings.json'
], function (settings) {
    settings = settings || {};
    //Build base url
    var locationPath = location.href.toLowerCase();

    if (locationPath.indexOf(settings.productionUrl) >= 0) {
        settings.baseUrl = settings.productionUrl;
    } else if (locationPath.indexOf(settings.developmentUrl) >= 0) {
        settings.baseUrl = settings.developmentUrl;
    } else {
        settings.baseUrl = settings.localUrl;
    }

    settings.startingRoute = settings.startingRoute || '../scripts/dexcmsapps/applications/controlpanel/';

    return settings;
});