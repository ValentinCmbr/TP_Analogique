const fsp = require('fs').promises;
const findFilesWithExtensionRecursively = require('./utils.js');

const CORRECT_DLL_DIR = 'C:\\Program Files (x86)\\Measurement Computing\\DAQ';
const DLL_NAME = 'MccDaq.dll';
const CORRECT_DLL_PATH = `${CORRECT_DLL_DIR}\\${DLL_NAME}`;

async function setup() {
    // Create the path to the dll
    await fsp.mkdir(CORRECT_DLL_DIR, { recursive: true });
    // // Copy the dll to the correct path
    await fsp.copyFile(`./ci/${DLL_NAME}`, CORRECT_DLL_PATH);

    // Replace the dll path for all .csproj
    await Promise.all(
        findFilesWithExtensionRecursively('..', '.csproj')
            .map(replaceDllPath)
    );
}

async function replaceDllPath(path) {
    const data = await fsp.readFile(path, 'utf8');
    // Change the dll from the simulator one to the real one
    var result = data.replace(/<HintPath>.*<\/HintPath>/g, `<HintPath>${CORRECT_DLL_PATH}</HintPath>`);
    // Write the changes
    await fsp.writeFile(path, result, 'utf8');
}

setup();