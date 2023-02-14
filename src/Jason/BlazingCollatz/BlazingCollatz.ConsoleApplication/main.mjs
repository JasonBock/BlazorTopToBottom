import { dotnet } from './dotnet.js'
import * as rl from 'node:readline/promises';
import { stdin as input, stdout as output } from 'node:process';

const readline = rl.createInterface({ input, output });

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

const value = await readline.question('Please enter your starting value.');
console.log(exports.CollatzInterop.Generate(value).join(', '));
readline.close();

await dotnet.run();