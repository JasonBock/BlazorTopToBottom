import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const dotNetExports = await getAssemblyExports(config.mainAssemblyName);

export function getSequence(start) {
    return dotNetExports.CollatzInterop.Generate(start);
}

export function findLongestSequenceSequentially() {
    return dotNetExports.CollatzInterop.FindLongestSequenceSequentially();
}

export function findLongestSequenceInParallelUsingThreads() {
    return dotNetExports.CollatzInterop.FindLongestSequenceInParallelUsingThreads();
}

export function findLongestSequenceInParallelUsingTasks() {
    return dotNetExports.CollatzInterop.FindLongestSequenceInParallelUsingTasks();
}