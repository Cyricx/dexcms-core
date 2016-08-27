var website = {
    copyGrunt: require('./website/copy'),
    jsonGrunt: require('./website/jsonGenerator'),
    cleanGrunt: require('./website/clean'),
    replaceGrunt: require('./website/replace'),
    sassGrunt: require('./website/sass'),
    watchGrunt: require('./website/watch'),
    loadTasks: require('./website/loadTasks'),
    registerTasks: require('./website/registerTasks'),
    uglifyGrunt: require('./website/uglify')
};

var gruntWebSiteBuilder = function (grunt, options) {
    var gruntOptions = {
        copy: website.copyGrunt(grunt, options),
        json_generator: website.jsonGrunt(grunt, options),
        pkg: grunt.file.readJSON('package.json'),
        clean: website.cleanGrunt(grunt, options),
        replace: website.replaceGrunt(grunt, options),
        sass: website.sassGrunt(grunt, options),
        uglify: website.uglifyGrunt(grunt, options),
        watch: website.watchGrunt(grunt, options)
    };
    
    return gruntOptions;
};

var gruntAppBuilder = function (grunt, options) {
    var defaultGrunt = {
        copy: copyGrunt(grunt, options),
        json_generator: jsonGrunt(grunt, options),

    };
    
    return defaultGrunt;
};

module.exports = (function () {
    return {
        website: function (grunt, options) {
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