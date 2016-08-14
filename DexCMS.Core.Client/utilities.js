var GruntBuilder = require('./Grunt/index');

var Helpers = function (options) {
    
    var helper = this;
    helper.options = options;

    var _prependZero = function (value) {
        return (value > 9 ? value : '0' + value).toString();
    };

    helper.getDateString = function () {
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
    
    return helper;
};

module.exports = function (options) {
    var utility = this;
    utility.options = options || {};

    utility.gruntBuilder = gruntBuilder(options);
    utility.helpers = helpers(options)
};