module.exports = function (appPath) {
    return {
        name: 'GlobalsSharedSettings',
        dest: appPath + '/globals/shared/config/dexcms.secure.settings.json',
        options: {
            startingRoute: '../scripts/' + appPath + '/globals/shared/'
        }
    };
};