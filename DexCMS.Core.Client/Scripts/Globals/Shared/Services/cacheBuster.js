define([
    'angular',
    '../shared',
], function (angular, module) {

    module.provider('DexCMSCacheBuster', [
        'dexCMSGlobalsSharedSettings',
        function (globalSettings) {

        this.matchlist = [/.*partial.*/, /.*view.*/];

        this.$get = ['$q', function ($q) {
            var matchlist = this.matchlist;

            return {
                'request': function (config) {
                    var busted = false;

                    for (var i = 0; i < matchlist.length; i++) {
                        if (config.url.match(matchlist[i])) {
                            busted = true; break;
                        }
                    }
                    if (busted) {
                        config.url = config.url.replace(/[?|&]v=([\d\.]+)/, '');
                        config.url += config.url.indexOf('?') === -1 ? '?' : '&'
                        config.url += 'v=' + globalSettings.cacheBuster;
                    }

                    return config || $q.when(config);
                }
            }
        }];
        }
    ]);
});