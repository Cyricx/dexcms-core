var copyGrunt = require('./copy/copy');

var gruntBuilder = function (grunt, options) {
    var defaultGrunt = {
        copy: copyGrunt(grunt, options)
    };



    return defaultGrunt;
};

module.exports = gruntBuilder;