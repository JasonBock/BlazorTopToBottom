﻿using Microsoft.AspNetCore.Components;

namespace DataAccess
{
    public class RenderModeProvider(ActiveCircuitState activeCircuitState)
    {
        public RenderMode GetRenderMode(ComponentBase page)
        {
            RenderMode result = RenderMode.ServerStatic;
            var isBrowser = OperatingSystem.IsBrowser();
            if (isBrowser)
                result = RenderMode.WebAssemblyInteractive;
            else if (activeCircuitState.CircuitExists)
                result = RenderMode.ServerInteractive;
            else if (page.GetType().GetCustomAttributes(typeof(StreamRenderingAttribute), true).Length > 0)
                result = RenderMode.ServerStaticStreaming;
            return result;
        }

        public bool IsInteractive(RenderMode renderMode)
        {
            return renderMode == RenderMode.WebAssemblyInteractive || renderMode == RenderMode.ServerInteractive;
        }
    }
}
