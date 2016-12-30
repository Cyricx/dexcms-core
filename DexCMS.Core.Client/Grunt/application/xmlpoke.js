var xmlpokeGrunt = function (grunt, options) {
    var files = {};
    files[options.debugXml.projectFile] = options.debugXml.projectFile;

    var xmlpoke = {
        debugReferences: {
            options: {
                namespaces: {
                    'w': 'http://schemas.microsoft.com/developer/msbuild/2003'
                },
                replacements: [{
                    xpath: '/w:Project/w:ItemGroup/w:Reference/w:HintPath',
                    value: function (node) {
                        var nodeValue = node.childNodes['0'].data;

                        var regex = /node_modules\\dexcms-([\w]*)\\dist\\([\w\.]*)\.dll/gi;

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
        },
        prodReferences: {
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
                            return 'node_modules\\dexcms-' + match[1] + '\\dist\\' + match[2] + '.dll';
                        } else {
                            return nodeValue;
                        }

                    }
                }],
            },
            files: files
        }
    }

    return xmlpoke;
};

module.exports = xmlpokeGrunt;