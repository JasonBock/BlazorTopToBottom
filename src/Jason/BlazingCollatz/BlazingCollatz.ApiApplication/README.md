# .NET API Application

## Build

You can build the app from Visual Studio or from the command-line:

## Run

You can run the app from Visual Studio or the command-line:

```
dotnet run -c Debug/Release
```

Or run it in [WasmTime](https://github.com/bytecodealliance/wasmtime) (you'll need to navigate to the directory that contains the `.wasm` file, it should be `bin\$(Configuration)\net8.0`):

```
wasmtime .\BlazingCollatz.ApiApplication.wasm -S tcplisten=127.0.0.1:5000 
```

To call it, issue a `GET` request like this: `http://localhost:8080/collatz/556` (for .NET server) or `http://localhost:5000/collatz/556` (for wasmtime).
