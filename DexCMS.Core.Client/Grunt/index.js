var website = {
    loadTasks: require('./website/loadTasks'),
    registerTasks: require('./website/registerTasks'),
    replaceGrunt: require('./website/replace'),
    sassGrunt: require('./website/sass'),
    symlinkGrunt: require('./website/symlink'),
    uglifyGrunt: require('./website/uglify'),
    watchGrunt: require('./website/watch')
};
var shared = {
    copyGrunt: require('./shared/copy'),
    cleanGrunt: require('./shared/clean'),
    jsonGrunt: require('./shared/jsonGenerator'),
    xmlpokeGrunt: require('./shared/xmlpoke')
};

var gruntWebSiteBuilder = function (grunt, options) {
    var gruntOptions = {
        clean: shared.cleanGrunt(grunt, options),
        copy: shared.copyGrunt(grunt, options),
        json_generator: shared.jsonGrunt(grunt, options),
        pkg: grunt.file.readJSON('package.json'),
        replace: website.replaceGrunt(grunt, options),
        sass: website.sassGrunt(grunt, options),
        symlink: website.symlinkGrunt(grunt, options),
        uglify: website.uglifyGrunt(grunt, options),
        watch: website.watchGrunt(grunt, options),
        xmlpoke: shared.xmlpokeGrunt(grunt, options)
    };
    
    return gruntOptions;
};

var gruntAppBuilder = function (grunt, options) {
    var defaultGrunt = {
        clean: shared.cleanGrunt(grunt, options),
        copy: shared.copyGrunt(grunt, options),
        json_generator: shared.jsonGrunt(grunt, options),
        xmlpoke: shared.xmlpokeGrunt(grunt, options)
    };
    
    return defaultGrunt;
};

var _addDefaultProperty = function (object, property, value) {
    object[property] = object[property] || value;
    return object;
};

var _addDefaultObject = function (object, property, value) {
    object[property] = object[property] || value;
    for (prop in value) {
        console.log(prop);
        console.log(value[prop]);
        object[property] = _addDefaultProperty(object[property], prop, value[prop]);
    }
    return object;
};

var loadDefaultWebOptions = function (options) {
    options = options || {};

    options = _addDefaultProperty(options, 'applicationsPath', 'Scripts/DexCMSApps');
    options = _addDefaultProperty(options, 'bower', 'bower_components');
    options = _addDefaultProperty(options, 'customJsonPath', 'customconfig/index');
    options = _addDefaultProperty(options, 'customModulesPath', 'customclient/');
    options = _addDefaultProperty(options, 'fonts', 'fonts');
    options = _addDefaultProperty(options, 'libs', 'libs');
    options = _addDefaultProperty(options, 'nodelibs', 'node_modules');
    options = _addDefaultObject(options, 'debugXml', {
        startPath: '..\\..\\dexcms.',
        projectFile: 'DexCMS.ExampleSiteabc.csproj',
        regexDebug: /\.\.\\\.\.\\dexcms\.([\w]*)\\([\w\.]*)\\bin\\release\\([\w\.]*)\.dll/gi
    });

    return options;
};

module.exports = (function () {
    return {
        website: function (grunt, options) {
            options = loadDefaultWebOptions(options);
            return {
                builder: function () {
                    return gruntWebSiteBuilder(grunt, options)
                },
                loadTasks: function () {
                    return website.loadTasks(grunt, options)
                },
                registerTasks: function () {
                    return website.registerTasks(grunt, options)
                }
            }
        },
        application: gruntAppBuilder
    };
})();