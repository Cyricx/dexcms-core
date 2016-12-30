var cleanGrunt = function (grunt, options) {
    var clean = {
        vendorFiles: [options.libs, options.fonts],
        dexCMSApplications: options.applicationsPath,
        defaultViews: 'Views/DexCMS',
    };

    return clean;
};

module.exports = cleanGrunt;