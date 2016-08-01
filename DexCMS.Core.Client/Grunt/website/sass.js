var sassGrunt = function (grunt, options) {
    var sass = {
        dist: {
            options: {
                style: 'compressed',
                debugInfo: true
            },
            files: [{
                expand: true,
                cwd: 'sass',
                src: ['*.scss'],
                dest: 'content',
                ext: '.css'
            }
            ]
        }
    };

    return sass;
};

module.exports = sassGrunt;