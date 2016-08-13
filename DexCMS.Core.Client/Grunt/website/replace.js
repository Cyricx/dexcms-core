var replaceGrunt = function (grunt, options) {
    
    var _prependZero = function (value) {
        return (value > 9 ? value : '0' + value).toString();
    };
    
    var getDateString = function () {
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
    
    return {
        requireVersions: {
            src: [options.applicationsPath + '/**/*.require.js'],
            overwrite: true,
            replacements: [{
                    from: /urlArgs: "v=([0-9.])*",/g,
                    to: 'urlArgs: "v=' + getDateString() + '",'
                }]
        }
    };
};

module.exports = replaceGrunt;