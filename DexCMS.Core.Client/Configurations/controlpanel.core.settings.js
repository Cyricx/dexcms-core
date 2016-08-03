module.exports = function (appPath) {
    return {
        name: 'ApplicationsControlPanelSettings',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.settings.json',
        options: {
            startingRoute: '../' + appPath + '/applications/controlpanel/'
        }
    };
};