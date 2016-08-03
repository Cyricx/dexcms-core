module.exports = function (appPath) {
    return {
        name: 'GlobalsSharedSettings',
        dest: appPath + '/globals/shared/config/dexcms.globals.shared.settings.json',
        options: {
            startingRoute: '../' + appPath + '/globals/shared/'
        }
    };
};