module.exports = function (appPath, overrides) {
    return {
        name: 'ApplicationsControlPanelNavigation',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.navigation.json',
        options: [
            {
                "title": "Users",
                "icon": "fa-users",
                "subLinks": [
                    {
                        title: "Roles",
                        href: overrides.roles || "roles"
                    },
                    {
                        title: "Users",
                        href: overrides.users ||"users"
                    }
                ]
            }
        ]
    };
};