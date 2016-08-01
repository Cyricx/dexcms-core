var watchGrunt = function (grunt, options) {
    var watch = {
        sass: {
            files: ['sass/**/*.scss'],
            tasks: ['sass']
        }
    };

    return watch;
};

module.exports = watchGrunt;