using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace StarOJ.Client.Interops
{
    public static class BrowserResizeService
    {
        public static event Func<Task> OnResize;

        [JSInvokable]
        public static async Task OnBrowserResize()
        {
            await OnResize?.Invoke();
        }
    }
}
