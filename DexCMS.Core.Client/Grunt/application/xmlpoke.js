var xmlpokeGrunt = function (grunt, options) {
    var xmlpoke = {};
    if (!options.disableDebugXml) {
        
        options.projects.forEach(function (project) {
            var projectId = project === 'Domain' ? options.root : options.root + '.' + project;
            var files = {};
            files[projectId + '/' + projectId + '.csproj'] = projectId + '/' + projectId + '.csproj';
            xmlpoke[project + 'Debug'] = {
                options: {
                    namespaces: {
                        'w': 'http://schemas.microsoft.com/developer/msbuild/2003'
                    },
                    replacements: [{
                            xpath: '/w:Project/w:ItemGroup/w:Reference/w:HintPath',
                            value: function (node) {
                                var nodeValue = node.childNodes['0'].data;
                                
                                var regex = /\.\.\\node_modules\\dexcms-([\w]*)\\dist\\([\w\.]*)\.dll/gi;
                                
                                var match = regex.exec(nodeValue);
                                if (match) {
                                    return options.debugXml.startPath + match[1] + '\\' + match[2] + '\\bin\\release\\' + match[2] + '.dll';

                                } else {
                                    return nodeValue;
                                }

                            }
                        }],
                },
                files: files
            };
            xmlpoke[project + 'Production'] = {
                options: {
                    namespaces: {
                        'w': 'http://schemas.microsoft.com/developer/msbuild/2003'
                    },
                    replacements: [{
                            xpath: '/w:Project/w:ItemGroup/w:Reference/w:HintPath',
                            value: function (node) {
                                var nodeValue = node.childNodes['0'].data;
                                
                                var match = options.debugXml.regexDebug.exec(nodeValue);
                                if (match) {
                                    return '..\\node_modules\\dexcms-' + match[1] + '\\dist\\' + match[2] + '.dll';
                                } else {
                                    return nodeValue;
                                }
                            }
                        }],
                },
                files: files
            }
        });
    }
    return xmlpoke;
};

module.exports = xmlpokeGrunt;