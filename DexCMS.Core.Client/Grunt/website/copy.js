var _modulesBuilder = function (options) {
    var copyModules = [];

    var _buildCopyModule = function (module) {
        return {
            expand: true,
            cwd: options.nodelibs + '/dexcms-' + module + '/dexcms.' + module + '.client/scripts/',
            src: ['**'],
            dest: options.applicationsPath
        };
    };

    for (var i = 0; i < options.modules.length; i++) {
        copyModules.push(_buildCopyModule(options.modules[i]));
    }

    return copyModules;
};

var _vendorFileBuilder = function (options) {
    var copyFiles = [];

    //dynamic vendorFiles
    if (options.vendorFiles.content) {
        for (var i = 0; i < options.vendorFiles.content.length; i++) {
            copyFiles.push({
                expand: true,
                cwd: options.bower + '/' + options.vendorFiles.content[i].folder + '/',
                src: options.vendorFiles.content[i].files,
                dest: options.libs + '/' + (options.vendorFiles.content[i].dist || options.vendorFiles.content[i].folder) + '/'
            });
        }
    };

    if (options.vendorFiles.fonts) {
        for (var i = 0; i < options.vendorFiles.fonts.length; i++) {
            var dest = (options.vendorFiles.fonts[i].dist == '') ? '' : (options.vendorFiles[i].dist || options.vendorFiles[i].folder) + '/';

            copyFiles.push({
                expand: true,
                cwd: options.bower + '/' + options.vendorFiles.fonts[i].folder + '/',
                src: options.vendorFiles.fonts[i].files,
                dest: options.fonts + '/' + dest
            });
        }
    };

    return copyFiles;
};

var _viewsBuilder = function (options) {
    var copyDefaultViews = [];

    var _buildViews = function (mod) {
        return [
            {
                expand: true,
                cwd: options.nodelibs + '/' + mod + '/defaultviews/rootviews/',
                src: ['**'],
                dest: 'views/dexcms/'
            },
            {
                expand: true,
                cwd: options.nodelibs + '/' + mod + '/defaultviews/areaviews/',
                src: ['**'],
                dest: 'views/dexcms-areas/'
            }
        ];
    };



    for (var i = 0; i < options.modules.length; i++) {
        var mod = 'dexcms-' + options.modules[i].toLowerCase() + '/dexcms.' + options.modules[i].toLowerCase() + '.mvc';
        copyDefaultViews.push.apply(copyDefaultViews, _buildViews(mod));
    }

    return copyDefaultViews;
};

var copyGrunt = function (grunt, options) {

    var copy = {
        vendorFiles: {
            files: _vendorFileBuilder(options)
        },
        defaultViews: {
            files: _viewsBuilder(options)
        },
        applicationsModules: {
            files: _modulesBuilder(options)
        }
    };

    if (options.customModulesPath) {
        copy.dexCMSApplicationsCustom = {
            expand: true,
            cwd: options.customModulesPath,
            src: ['**'],
            dest: options.applicationsPath
        }
    }

    return copy;

};

module.exports = copyGrunt;