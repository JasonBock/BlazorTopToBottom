# .NET WASI Application

## Build

You can build the app from Visual Studio or from the command-line:

```
dotnet build -c Debug/Release
```

## Run

You can run the app from Visual Studio or the command-line:

```
dotnet run -c Debug/Release
```

Or run it in [WasmTime](https://github.com/bytecodealliance/wasmtime) (you'll need to navigate to the directory that contains the `.wasm` file, it should be `bin\$(Configuration)\net8.0`):

```
wasmtime --dir=. .\BlazingCollatz.WasiApplication.wasm
```

If you remove `--dir=.`, you won't be able to open the file in the code.
