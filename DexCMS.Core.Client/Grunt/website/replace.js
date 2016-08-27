var replaceGrunt = function (grunt, options) {
    
    var gruntReplace = {
        requireVersions: {
            src: [options.applicationsPath + '/**/*.require.js'],
            overwrite: true,
            replacements: [{
                    from: /urlArgs: "v=([0-9.]*)*",/g,
                    to: 'urlArgs: "v=' + options.versionSuffix + '",'
                }]
        }
    };
    if (options.cacheBustFiles) {
        gruntReplace.cacheBust = {
            src: options.cacheBustFiles,
            overwrite: true,
            replacements: [
                {
                    from: /\?v=([0-9.]*)"/g,
                    to: '?v=' + options.versionSuffix + '"'
                }
            ]
        };
    }
    
    return gruntReplace;
};

module.exports = replaceGrunt;