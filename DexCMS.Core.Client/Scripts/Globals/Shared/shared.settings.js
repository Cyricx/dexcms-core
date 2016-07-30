define([
    'json!./config/dexcms.globals.shared.settings.json'
], function (settings) {
    settings = settings || {};

    settings.startingRoute = settings.startingRoute || '../../../scripts/dexcmsapps/globals/shared/';

    return settings;

});