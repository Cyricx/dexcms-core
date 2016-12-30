var cleanGrunt = function (grunt, options) {
    var clean = {
            build: [options.distributionFolder]
    };

    return clean;
};

module.exports = cleanGrunt;