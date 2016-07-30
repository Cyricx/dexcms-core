define([
    './htmlTrusted'
], function (htmlTrusted) {
    return function (app) {
        htmlTrusted(app);
    };
});