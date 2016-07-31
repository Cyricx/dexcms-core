
var viewsBuilder = function (options) {
    var copyDefaultViews = [];

    var _buildViews = function (mod) {
        return [
            {
                expand: true,
                cwd: options.nodelibs + '/' + mod + '/defaultviews/rootviews/',
                src: ['**'],
                dest: 'views/dexcms/'
            },
            {
                expand: true,
                cwd: options.nodelibs + '/' + mod + '/defaultviews/areaviews/',
                src: ['**'],
                dest: 'views/dexcms-areas/'
            }
        ];
    };



    for (var i = 0; i < options.modules.length; i++) {
        var mod = 'dexcms-' + options.modules[i].toLowerCase() + '/dexcms.' + options.modules[i].toLowerCase() + '.mvc';
        copyDefaultViews.push.apply(copyDefaultViews, _buildViews(mod));
    }

    return copyDefaultViews;
};

module.exports = viewsBuilder;