var copyGrunt = function (grunt, options) {
    var copy = {};

    options.projects.forEach(function (project) {
        var projectId = project === 'Domain' ? options.root : options.root + '.' + project;

        copy[project] = {
            expand: true,
            cwd: projectId + '/bin/Release/',
            src: [projectId + '.dll'],
            dest: options.distributionFolder + '/'
        };
    });

    return copy;
};

module.exports = copyGrunt;