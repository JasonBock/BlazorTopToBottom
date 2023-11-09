/*
Remember to use:

wasmtime .\BlazingCollatz.ApiApplication.wasm --tcplisten 127.0.0.1:5000 
*/

using Collatz;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args).UseWasiConnectionListener();

var app = builder.Build();

app.MapGet("/collatz/{value}", (BigInteger value) =>
{
	if (value > BigInteger.One)
	{
		var sequence = CollatzSequenceGenerator.Generate<BigInteger>(value);
		return string.Join(", ", sequence);
	}
	else
	{
		return "Must provide a value greater than 1.";
	}
});

app.Start();