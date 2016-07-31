


var modulesBuilder = function (options) {
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

module.exports = modulesBuilder;