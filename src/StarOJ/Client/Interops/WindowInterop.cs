using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarOJ.Client.Interops
{
    public static class WindowInterop
    {
        public static ValueTask SetTitle(IJSRuntime runtime, string title)
        {
            return runtime.InvokeVoidAsync("starojInteropSetTitle", title);
        }

        public static ValueTask ScrollTo(IJSRuntime runtime, string title)
        {
            return runtime.InvokeVoidAsync("starojInteropScrollTo", title);
        }

        public static ValueTask CopyItem(IJSRuntime runtime, ElementReference element)
        {
            return runtime.InvokeVoidAsync("starojInteropCopyItem", element);
        }
    }
}
