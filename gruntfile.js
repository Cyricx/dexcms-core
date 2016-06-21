/// <binding BeforeBuild='clean' AfterBuild='copy' />
module.exports = function (grunt) {
    //Configuration setup
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        copy: {
            main: {
                expand: true,
                cwd: 'DexCMS.Core.Infrastructure/bin/Release/',
                src: ['DexCMS.Core.Infrastructure.dll'],
                dest: 'dist/'
            },
            mvc: {
                expand: true,
                cwd: 'DexCMS.Core.Mvc/bin/Release/',
                src: ['DexCMS.Core.Mvc.dll'],
                dest: 'dist/'
            },
            webapi: {
                expand: true,
                cwd: 'DexCMS.Core.WebApi/bin/Release/',
                src: ['DexCMS.Core.WebApi.dll'],
                dest: 'dist/'
            }
        },
        clean: {
            build: ["dist"]
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['clean', 'copy']);
};
