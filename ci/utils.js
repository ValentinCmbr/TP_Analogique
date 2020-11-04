const fs = require('fs'),
    path = require('path');

/**
 * Find all files recursively in specific folder with specific extension, e.g:
 * findFilesInDir('./project/src', '.html') ==> ['./project/src/a.html','./project/src/build/index.html']
 * @param  {String} startPath    Path relative to this file or other file which requires this files
 * @param  {String} extension       Extension name, e.g: '.html'
 * @return {Array}               Result files with path string in an array
 */
function findFilesWithExtensionRecursively(startPath, extension) {
    var results = [];

    if (!fs.existsSync(startPath)) {
        console.log("no dir ", startPath);
        return;
    }

    var files = fs.readdirSync(startPath);
    for (var i = 0; i < files.length; i++) {
        var filename = path.join(startPath, files[i]);
        var stat = fs.lstatSync(filename);
        if (stat.isDirectory()) {
            results = results.concat(findFilesWithExtensionRecursively(filename, extension)); //recurse
        }
        else if (filename.endsWith(extension)) {
            console.log('-- found: ', filename);
            results.push(filename);
        }
    }
    return results;
}

module.exports = findFilesWithExtensionRecursively;