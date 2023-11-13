## .NET WebAssembly Node Application

## Build

You can build the app from Visual Studio or from the command-line:

```
dotnet build -c Debug/Release
```

After building the app, the result is in the `bin/$(Configuration)/net8.0/browser-wasm/AppBundle` directory.

## Run

You can run the app from Visual Studio or the command-line:

```
dotnet run -c Debug/Release
```

Or directly start node from the AppBundle directory:

```
node bin/$(Configuration)/net8.0/browser-wasm/AppBundle/main.mjs
```

Or run it in [WasmTime](https://github.com/bytecodealliance/wasmtime) (you'll need to navigate to the directory that contains the `.wasm` file, it should be `bin\$(Configuration)\net8.0\browser-wasm\AppBundle\managed`, though I did not have success running it):

```
wasmtime bin/$(Configuration)/net8.0/browser-wasm/AppBundle/managed/BlazingCollatz.ConsoleApplication.wasm
```