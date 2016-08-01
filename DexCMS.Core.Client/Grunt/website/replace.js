var replaceGrunt = function (grunt, options) {
    var replace = {
        //used to suppress warnings in ui-bootstrap
        vendorFiles: {
            options: {
                usePrefix: false,
                patterns: [
                    {
                        match: 'SuppressWarning",!1',
                        replacement: 'SuppressWarning",1'
                    }
                ]
            },
            files: [
                {
                    expand: true,
                    flatten: true,
                    src: [options.libs + '/angular-bootstrap/ui-bootstrap-tpls.min.js'],
                    dest: options.libs + '/angular-bootstrap'
                }
            ]
        }
    };

    return replace;
};

module.exports = replaceGrunt;