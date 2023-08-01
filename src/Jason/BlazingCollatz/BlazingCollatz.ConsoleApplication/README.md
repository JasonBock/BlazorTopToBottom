# .NET Console Application

## Build

You can build the app from Visual Studio or from the command-line:

```
dotnet build -c Debug/Release
```

After building the app, the result is in the `bin/$(Configuration)/net7.0/browser-wasm/AppBundle` directory.

## Run

You can run the app from Visual Studio or the command-line:

```
dotnet run -c Debug/Release
```

Or run it in [WasmTime](https://github.com/bytecodealliance/wasmtime) (you'll need to navigate to the directory that contains the `.wasm` file, it should be `bin\$(Configuration)\net7.0\browser-wasm\AppBundle`):

```
wasmtime BlazingCollatz.ConsoleApplication.wasm
```
