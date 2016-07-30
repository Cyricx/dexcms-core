define([
    'angular',
    '../shared',
    'moment',
], function (angular, module, moment) {

    module.service('DexCmsDateCleaner', function () {

        var _fixDate = function (date) {
            var fixedDate = _getDatePieces(date);
            var fixedTime = _getTimePieces(date);
            return new Date(fixedDate[0], (fixedDate[1] - 1), fixedDate[2], fixedTime[0], fixedTime[1]);
        };

        var _getDatePieces = function (datetimestring) {
            var datestring = datetimestring.substr(0, datetimestring.indexOf('T'));
            return datestring.split('-');
        };

        var _getTimePieces = function (datestring) {
            var timestring = datestring.substr(datestring.indexOf('T') + 1);
            return timestring.split(':');
        }

        var _correctTimeZone = function (prop) {
            return _fixDate(prop);
        }

        var _preServerProcess = function (prop) {
            var propMoment = moment(prop);
            return propMoment.add(+propMoment.utcOffset(), 'minutes');
        }

        return {
            correctTimeZone: _correctTimeZone,
            preServerProcess: _preServerProcess
        };

    })

});