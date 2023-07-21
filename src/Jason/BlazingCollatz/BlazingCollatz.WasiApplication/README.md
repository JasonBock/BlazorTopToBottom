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

Or run it in [WasmTime](https://github.com/bytecodealliance/wasmtime) (you'll need to navigate to the directory that contains the `.wasm` file, it should be `bin\$(Configuration)\net7.0`):

```
wasmtime .\BlazingCollatz.WasiApplication.wasm --tcplisten 127.0.0.1:5000 
```

To call it, issue a `GET` request like this: `http://localhost:5000/collatz/556`.