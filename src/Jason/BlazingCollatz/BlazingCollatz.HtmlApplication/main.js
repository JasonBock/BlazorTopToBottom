import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const dotNetExports = await getAssemblyExports(config.mainAssemblyName);
//const sequence = exports.CollatzInterop.Generate("400");
//console.log(sequence.join(", "));

export function getSequence(start) {
    return dotNetExports.CollatzInterop.Generate(start);
}