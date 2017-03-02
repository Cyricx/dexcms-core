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
            },
            {
                "title": "Settings",
                "icon": "fa-cogs",
                "subLinks": [
                    {
                        "title": "Countries",
                        href: overrides.countries || "countries"
                    },
                    {
                        "title": "Images",
                        href: overrides.images || "images"
                    },
                    {
                        "title": "States",
                        href: overrides.states || "states"
                    },
                    {
                        "title": "Settings",
                        href: overrides.settings || "settings"
                    },
                    {
                        "title": "Setting DataTypes",
                        href: overrides.settingdatatypes || "settingdatatypes"
                    },
                    {
                        "title": "Setting Groups",
                        href: overrides.settinggroups || "settinggroups"
                    }
                ]
            }
        ]
    };
};