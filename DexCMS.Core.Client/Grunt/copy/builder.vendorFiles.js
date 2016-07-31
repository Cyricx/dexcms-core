
var vendorFileBuilder = function (options) {
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

module.exports = vendorFileBuilder;