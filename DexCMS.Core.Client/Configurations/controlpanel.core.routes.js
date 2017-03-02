﻿module.exports = function (appPath) {
    return {
        name: 'ApplicationsControlPanelRoutes',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.routes.json',
        options: [
            {
                "name": "roles",
                "module": "core"
            },
            {
                name: "users",
                module: "core"
            },
            {
                "name": "countries",
                "module": "core"
            },
            {
                "name": "states",
                "module": "core"
            },
            {
                "name": "images",
                "module": "core"
            },
            {
                "name": "settingDataTypes",
                "module": "base"
            },
            {
                "name": "settingGroups",
                "module": "base"
            },
            {
                "name": "settings",
                "module": "base"
            }
        ]
    };
};