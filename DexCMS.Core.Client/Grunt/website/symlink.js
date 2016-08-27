﻿var symlinkGrunt = function (grunt, options) {
    var symlink = {
        options: {
            overwrite: true
        }
    };
    
    if (options.symlinks) {
        for (var i = 0; i < options.symlinks.length; i++) {
            var link = options.symlinks[i];
            symlink[link.module + 'Scripts'] = {
                src: link.src + 'dexcms.' + link.module + '.client/scripts/',
                dest: options.nodelibs + '/dexcms-' + link.module + '/dexcms.' + link.module + '.client/scripts/'
            };
        }
    }

    return symlink;
};

module.exports = symlinkGrunt;