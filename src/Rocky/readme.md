# Blazor Examples

Blazor examples from VS Live 2024.

## Blazor State

Example showing how various ways of maintaining "global" state in server-side Blazor results in different behaviors.

https://github.com/rockfordlhotka/Blazor8State - [Blog post](https://blog.lhotka.net/2023/11/28/Per-User-Blazor-8-State)

## Blazor MAUI Hybrid

Open-source project that shows how to use Blazor components in a real Blazor MAUI hybrid app.

https://github.com/missingchildrenmn/KidsIdKit

## DeviceAPIAccess

Example showing how to implement per-platform behavior in a MAUI Hybrid app.

Look for the `IGetText` interface and per-platform `GetText` implementation classes.

## Blazor Authentication

Example showing how to authenticate a user using `HttpContext`, and also how to flow the user identity from the Blazor server to a WebAssembly page in the browser.

https://github.com/rockfordlhotka/BlazorDive/tree/main/BlazorAuthentication

## PageLifecycle

Example showing how the lifecycle events are raised in any Blazor component or page.

## RenderModes

Example showing how to detect the current render mode for any Blazor component.

[Blog post](https://blog.lhotka.net/2024/03/30/Blazor-8-Render-Mode-Detection)

## DataAccess

Example showing the basic structure necessary to abstract data access behind a data access interface (`IDataAccess`) so a Blazor component can access data when running in any render mode (server-static, server-interactive, wasm-interactive). The idea is to implement the "real" data access code on the server to talk to the database, and to also provide a RESTful service interface so WebAssembly pages can access the same data via `HttpClient`.

## Other Blazor Examples

https://github.com/rockfordlhotka/blazordive
