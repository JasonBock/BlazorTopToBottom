namespace RenderModes
{
    public enum RenderMode
    {
        Unknown,
        ServerStatic,
        ServerStaticStreaming,
        ServerInteractive,
        WebAssemblyInteractive
    }

    //[Flags]
    //public enum RenderModeFlags
    //{
    //    Unknown = 0,
    //    Server = 1,
    //    WebAssembly = 2,
    //    Streaming = 4,
    //    Interactive = 8
    //}

    //public static class RenderModeFlagsExtensions
    //{
    //    public static bool IsServer(this RenderModeFlags mode)
    //    {
    //        return (mode & RenderModeFlags.Server) > 0;
    //    }

    //    public static bool IsWebAssembly(this RenderModeFlags mode)
    //    {
    //        return (mode & RenderModeFlags.WebAssembly) > 0;
    //    }

    //    public static bool IsInteractive(this RenderModeFlags mode)
    //    {
    //        return (mode & RenderModeFlags.Interactive) > 0;
    //    }

    //    public static bool IsStreaming(this RenderModeFlags mode)
    //    {
    //        return (mode & RenderModeFlags.Streaming) > 0;
    //    }
    //}
}
