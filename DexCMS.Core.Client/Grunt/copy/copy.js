var _vendorFileBuilder = require('./builder.vendorFiles.js'),
    _viewsBuilder = require('./builder.views.js'),
    _modulesBuidler = require('./builder.modules.js');


var copyGrunt = function (grunt, options) {
    var copy = {
        vendorFiles: {
            files: _vendorFileBuilder(options)
        },
        defaultViews: {
            files: _viewsBuilder(options)
        },
        applicationsModules: {
            files: _modulesBuidler(options)
        }
    };

    return copy;

};

module.exports = copyGrunt;