var symlinkGrunt = function (grunt, options) {
    var symlink = {
        options: {
            overwrite: true
        }
    };
    
    if (options.symlinks) {
        for (var i = 0; i < options.symlinks.length; i++) {
            var link = options.symlinks[i];
            symlink[link.module] = {
                src: link.src,
                dest: options.nodelibs + '/dexcms-' + link.module + '/'
            };
        }
    }

    return symlink;
};

module.exports = symlinkGrunt;