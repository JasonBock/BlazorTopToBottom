# BlazingCollatz

Here are the details on the solutions and projects that exist within this directory.

## `BlazingCollatz` Solution

### `BlazingCollatz.WebComponents`

This contains the Razor components used in both the WebAssembly and server-side hosts.

### `BlazingCollatz.WebComponents.Tests`

Contains tests for `BlazingCollatz.WebComponents`, using [bUnit](https://bunit.dev/).

### `BlazingCollatz.ServerSideHost`

A server-side host for the `BlazingCollatz.WebComponents` code.

### `BlazingCollatz.WebAssemblyHost`

A WebAssembly host for the `BlazingCollatz.WebComponents` code.

### `BlazingCollatz.WebTests`

Playwright tests that test the `BlazingCollatz.WebAssemblyHost` application when it's running.

### `BlazingCollatz.HtmlApplication`

A pure HTML application that calls .NET code.

### `BlazingCollatz.ConsoleApplication`

A node.js application that calls .NET code.

### `BlazingCollatz.WasiApplication`

A console application where, on build, a .wasm file is created that can be run with `wasmtime`.

### `BlazingCollatz.WasmApplication`

A console application that generates WASM code on the fly and executes it.

### `BlazingCollatz.ApiApplication`

An ASP.NET minimal API application that compiles to .wasm and can be run with `wasmtime`.

## `BlazingCollatz.AvaloniaApplication` Solution

### `BlazingCollatz.AvaloniaApplication`

Contains the basic XAML controls for an Avalonia application.

### `BlazingCollatz.AvaloniaApplication.Browser`

A browser application that runs the `BlazingCollatz.AvaloniaApplication` code.

### `BlazingCollatz.AvaloniaApplication.Desktop`

A desktop application that runs the `BlazingCollatz.AvaloniaApplication` code.