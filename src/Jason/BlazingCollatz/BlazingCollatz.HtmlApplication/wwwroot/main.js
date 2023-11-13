// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './_framework/dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

await dotnet.run();

export function getSequence(start) {
    return exports.CollatzInterop.Generate(start);
}

export function findLongestSequenceSequentially() {
    return exports.CollatzInterop.FindLongestSequenceSequentially();
}

export function findLongestSequenceInParallelUsingTasks() {
    return exports.CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync();
}