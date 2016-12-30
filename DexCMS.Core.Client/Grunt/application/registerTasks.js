var registerTasks = function (grunt, options) {
    //register tasks
    grunt.registerTask('default', ['clean', 'copy']);
};

module.exports = registerTasks;