using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace StarOJ.Client.Interops
{
    public static class LoadingInfoInterop
    {
        public static ValueTask Show(IJSRuntime runtime)
        {
            return runtime.InvokeVoidAsync("starojInteropLoadingInfoShow");
        }

        public static ValueTask Hide(IJSRuntime runtime)
        {
            return runtime.InvokeVoidAsync("starojInteropLoadingInfoHide");
        }
    }
}
