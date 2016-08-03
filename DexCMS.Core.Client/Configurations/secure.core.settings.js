module.exports = function (appPath) {
    return {
        name: 'ApplicationsSecureSettings',
        dest: appPath + '/applications/secure/config/dexcms.secure.settings.json',
        options: {
            startingRoute: '../' + appPath + '/applications/secure/'
        }
    };
};