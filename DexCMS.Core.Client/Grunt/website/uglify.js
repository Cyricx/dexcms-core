var uglifyGrunt = function (grunt, options) {
    var uglify = {
        dexCMSApplications: {
            files: [
                {
                    expand: true,
                    cwd: options.applicationsPath,
                    src: ['**/*.js'],
                    dest: options.applicationsPath
                }
            ]
        }
    };

    return uglify;
};

module.exports = uglifyGrunt;