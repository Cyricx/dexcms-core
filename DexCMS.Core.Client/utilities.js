var vendorFileBuilder = require('./grunt/copy/builder.vendorFiles'),
    viewsBuilder = require('./grunt/copy/builder.views'),
    gruntBuilder = require('./Grunt/index');


module.exports = {
    viewsBuilder: viewsBuilder,
    vendorFileBuilder: vendorFileBuilder,
    gruntBuilder: gruntBuilder
};