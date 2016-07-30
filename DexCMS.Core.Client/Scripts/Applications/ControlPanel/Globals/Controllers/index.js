define([
    './layout.controller'
], function (LayoutCtrl) {
    //return builder function
    return function (app) {
        //build controllers
        LayoutCtrl(app);
    };
});