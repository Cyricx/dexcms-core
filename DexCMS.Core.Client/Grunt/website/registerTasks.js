var registerTasks = function (grunt, options) {
    //register tasks
    grunt.registerTask('vendorFiles', ['clean:vendorFiles', 'copy:vendorFiles']);
    grunt.registerTask('dexCMSApplications', function () {
        grunt.task.run('clean:dexCMSApplications');
        grunt.task.run('copy:applicationsModules');
        if (options.customModulesPath) {
            grunt.task.run('copy:dexCMSApplicationsCustom');
        }
        grunt.task.run('replace:requireVersions');
        grunt.task.run('json_generator');
    });
    grunt.registerTask('defaultViews', ['clean:defaultViews', 'copy:defaultViews']);
    grunt.registerTask('build', ['vendorFiles', 'dexCMSApplications', 'defaultViews', 'sass']);
    grunt.registerTask('default', ['build']);
};

module.exports = registerTasks;