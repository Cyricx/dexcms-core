var GruntBuilder = require('./Grunt/index');

var helpers = {};

    var _prependZero = function (value) {
        return (value > 9 ? value : '0' + value).toString();
    };

    helpers.getDateString = function () {
        var d = new Date();
        var dateParts = [];
        dateParts.push(d.getFullYear());
        dateParts.push(_prependZero((1 + d.getMonth())));
        dateParts.push(_prependZero((1 + d.getDate())));
        dateParts.push(_prependZero((1 + d.getHours())));
        dateParts.push(_prependZero((1 + d.getMinutes())));
        dateParts.push(_prependZero((1 + d.getSeconds())));
        return dateParts.join('.');
    };

module.exports = function (options) {
    var utility = this;
    utility.options = options || {};

    utility.gruntBuilder = gruntBuilder(options);
    utility.helpers = helpers
};