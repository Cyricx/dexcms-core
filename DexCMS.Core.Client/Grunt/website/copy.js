var _constructCopy = function (directory, source, destination, shouldExpand) {
    shouldExpand = shouldExpand || true;
    return {
        expand: shouldExpand,
        cwd: directory,
        src: source,
        dest: destination
    };
}

var _buildClient = function (options) {
    var copyModules = [];
    var directory;

    options.modules.forEach(function (mod) {
        directory = options.nodelibs + '/dexcms-' + mod + '/dexcms.' + mod + '.client/scripts/';
        copyModules.push(_constructCopy(directory, ['**'], options.applicationsPath));
    });

    return copyModules;
};

var _buildVendor = function (options) {
    var copyFiles = [];
    var directory, destination;

    if (options.vendorFiles.content) {
        options.vendorFiles.content.forEach(function (vendorFile) {
            directory = options.bower + '/' + vendorFile.folder + '/';
            destination = options.libs + '/' + (vendorFile.dist || vendorFile.folder) + '/';

            copyFiles.push(_constructCopy(directory, vendorFile.files, destination));
        });
    };

    if (options.vendorFiles.fonts) {
        options.vendorFiles.fonts.forEach(function (vendorFont) {
            var vendorFolder = (vendorFont.dist == '') ? '' : (options.vendorFiles[i].dist || options.vendorFiles[i].folder) + '/';
            destination = options.fonts + '/' + vendorFolder;
            directory = options.bower + '/' + vendorFont.folder + '/';
            
            copyFiles.push(_constructCopy(directory, vendorFont.files, destination));
        });
    };

    return copyFiles;
};

var _buildMvc = function (options) {
    var copyFiles = [];
    var baseDirectory, modulePath;

    options.modules.forEach(function (module) {
        modulePath = options.nodelibs + '/dexcms-' + module.toLowerCase() + '/dexcms.' + module.toLowerCase() + '.mvc';
        
        copyFiles.push(_constructCopy(modulePath + '/views/rootviews/', ['**'], 'views/dexcms/'));
        copyFiles.push(_constructCopy(modulePath + '/areas/areaviews/', ['**'], 'areas/'));
        copyFiles.push(_constructCopy(modulePath + '/scripts/', ['**'], 'scripts/DexCMS/'));
        copyFiles.push(_constructCopy(modulePath + '/content/', ['**'], 'content/'));
    });

    return copyFiles;
};

var copyGrunt = function (grunt, options) {
    
    var copy = {
        vendorFiles: {
            files: _buildVendor(options)
        },
        defaultViews: {
            files: _buildMvc(options)
        },
        applicationsModules: {
            files: _buildClient(options)
        }
    };

    if (options.customModulesPath) {
        copy.dexCMSApplicationsCustom = _constructCopy(options.customModulesPath, ['**'], options.applicationsPath);
    }

    return copy;
};

module.exports = copyGrunt;