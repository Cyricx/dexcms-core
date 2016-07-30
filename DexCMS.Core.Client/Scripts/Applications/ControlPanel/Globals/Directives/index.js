define([
    './ttcmsAttention',
    './ttcmsCalculateGrid',
    './ttcmsFixedTop',
    './ttcmsHorizontalNav',
    './ttcmsHtmlEditor'
], function (ttcmsAttention, ttcmsCalculateGrid, ttcmsFixedTop, ttcmsHorizontalNav, ttcmsHtmlEditor) {
    return function (app) {
        ttcmsAttention(app);
        ttcmsCalculateGrid(app);
        ttcmsFixedTop(app);
        ttcmsHorizontalNav(app);
        ttcmsHtmlEditor(app);
    };
});