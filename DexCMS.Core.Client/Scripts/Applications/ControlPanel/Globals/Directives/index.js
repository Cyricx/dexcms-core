define([
    './dexcmsAttention',
    './dexcmsCalculateGrid',
    './dexcmsFixedTop',
    './dexcmsHorizontalNav',
    './dexcmsHtmlEditor'
], function (dexcmsAttention, dexcmsCalculateGrid, dexcmsFixedTop, dexcmsHorizontalNav, dexcmsHtmlEditor) {
    return function (app) {
        dexcmsAttention(app);
        dexcmsCalculateGrid(app);
        dexcmsFixedTop(app);
        dexcmsHorizontalNav(app);
        dexcmsHtmlEditor(app);
    };
});