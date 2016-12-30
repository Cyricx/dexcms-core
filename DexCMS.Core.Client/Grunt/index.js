var website = {
    loadTasks: require('./website/loadTasks'),
    registerTasks: require('./website/registerTasks'),
    replaceGrunt: require('./website/replace'),
    sassGrunt: require('./website/sass'),
    symlinkGrunt: require('./website/symlink'),
    uglifyGrunt: require('./website/uglify'),
    watchGrunt: require('./website/watch'),
    copyGrunt: require('./website/copy'),
    cleanGrunt: require('./website/clean'),
    jsonGrunt: require('./website/jsonGenerator'),
    xmlpokeGrunt: require('./website/xmlpoke')
};
var application = {
    copyGrunt: require('./application/copy'),
    cleanGrunt: require('./application/clean'),
    loadTasks: require('./application/loadTasks'),
    registerTasks: require('./application/registerTasks'),
    xmlpokeGrunt: require('./application/xmlpoke')
};

var gruntWebSiteBuilder = function (grunt, options) {
    var gruntOptions = {
        clean: website.cleanGrunt(grunt, options),
        copy: website.copyGrunt(grunt, options),
        json_generator: website.jsonGrunt(grunt, options),
        pkg: grunt.file.readJSON('package.json'),
        replace: website.replaceGrunt(grunt, options),
        sass: website.sassGrunt(grunt, options),
        symlink: website.symlinkGrunt(grunt, options),
        uglify: website.uglifyGrunt(grunt, options),
        watch: website.watchGrunt(grunt, options),
        xmlpoke: website.xmlpokeGrunt(grunt, options)
    };
    
    return gruntOptions;
};

var gruntApplicationBuilder = function (grunt, options) {
    var gruntOptions = {
        pkg: grunt.file.readJSON('package.json'),
        clean: application.cleanGrunt(grunt, options),
        copy: application.copyGrunt(grunt, options),
        xmlpoke: application.xmlpokeGrunt(grunt, options)
    };
    
    return gruntOptions;
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
        projectFile: 'DexCMS.ExampleSite.csproj',
        regexDebug: /\.\.\\\.\.\\dexcms\.([\w]*)\\([\w\.]*)\\bin\\release\\([\w\.]*)\.dll/gi
    });

    return options;
};

var loadDefaultApplicationOptions = function (options) {
    options = options || {};
    options = _addDefaultProperty(options, 'projects', ['Domain', 'Mvc', 'WebApi']);
    options = _addDefaultProperty(options, 'distributionFolder', 'dist');
    options = _addDefaultObject(options, 'debugXml', {
        startPath: '..\\..\\dexcms.',
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
        application: function (grunt, options) {
            options = loadDefaultApplicationOptions(options);
            return {
                builder: function () {
                    return gruntApplicationBuilder(grunt, options)
                },
                loadTasks: function () {
                    return application.loadTasks(grunt, options)
                },
                registerTasks: function () {
                    return application.registerTasks(grunt, options)
                }
            }
        }
    };
})();