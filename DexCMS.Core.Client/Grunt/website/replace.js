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
    if (options.cacheBustConfigs) {
        gruntReplace.cacheBust = {
            src: options.cacheBustConfigs,
            overwrite: true,
            replacements: [
                {
                    from: /\add key="Version" value="([0-9.]*)"/g,
                    to: 'add key="Version" value="' + options.versionSuffix + '"'
                }
            ]
        };
    }
    
    return gruntReplace;
};

module.exports = replaceGrunt;