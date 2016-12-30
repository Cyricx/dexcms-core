var loadTasks = function (grunt, options) {
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-xmlpoke');
};

module.exports = loadTasks;