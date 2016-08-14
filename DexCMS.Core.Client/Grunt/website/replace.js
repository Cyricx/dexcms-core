var replaceGrunt = function (grunt, options) {
    
    return {
        requireVersions: {
            src: [options.applicationsPath + '/**/*.require.js'],
            overwrite: true,
            replacements: [{
                    from: /urlArgs: "v=([0-9.])*",/g,
                    to: 'urlArgs: "v=' + options.versionSuffix + '",'
                }]
        }
    };
};

module.exports = replaceGrunt;