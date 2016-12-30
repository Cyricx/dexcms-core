module.exports = function (grunt, options) {
    var jsonItems = [];
    if (options.customJsonPath) {
        jsonItems = jsonItems.concat(
            require('../../../../../' + options.customJsonPath)(options.applicationsPath));
    }

    for (var i = 0; i < options.modules.length; i++) {
        var moduleName = options.modules[i];
        var moduleOverrides = options.jsonOverrides ? options.jsonOverrides[moduleName] : null;
        jsonItems = jsonItems.concat(
            require('../../../../dexcms-' + moduleName + '/dexcms.' + moduleName + '.client/Configurations/index')(options.applicationsPath, moduleOverrides)
        );
    }

    var jsonGenerator = {};
    
    for (var i = 0; i < jsonItems.length; i++) {
        var existingItem = jsonGenerator[jsonItems[i].name];
        if (!existingItem) {
            if (jsonItems[i].name.indexOf('Settings') !== -1 && !Array.isArray(jsonItems[i].options)) {
                Object.assign(jsonItems[i].options, jsonItems[i].options, options.defaultSettings);
            }
            jsonGenerator[jsonItems[i].name] = {
                dest: jsonItems[i].dest,
                options: jsonItems[i].options
            }
        } else {
            if (Array.isArray(existingItem.options)) {
                existingItem.options = existingItem.options.concat(jsonItems[i].options);
            } else {
                Object.assign(existingItem.options, existingItem.options, jsonItems[i].options);
            }
        }
    }

    return jsonGenerator;
};