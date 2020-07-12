using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using StarOJ.Client.Interops;
using StarOJ.Models;
using StarOJ.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace StarOJ.Client.Shared
{
    public class BasePage : ComponentBase, IDisposable
    {
        private string _title;

        protected string BaseUri { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IOJService Service { get; set; }

        protected OJOptions OJOptions { get; set; } = new OJOptions();

        protected virtual string Title
        {
            get => _title; set
            {
                if (value != _title)
                {
                    _title = value;
                    StateHasChanged();
                }
            }
        }

        private string LocalAnchorJump { get; set; } = "";

        private string GetBaseUri()
        {
            var url = NavigationManager.Uri;
            var ind = url.IndexOf('#');
            if (ind >= 0)
                url = url.Remove(ind);
            return url;
        }

        protected override void OnInitialized()
        {
            BaseUri = GetBaseUri();
            Title = "";
            NavigationManager.LocationChanged += LocationChanged;
            LocationChanged(null, null);
        }

        protected override async Task OnInitializedAsync()
        {
            OJOptions = await Service.GetOptions();
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            string title = OJOptions.Name;
            if (!string.IsNullOrEmpty(Title))
                title = $"{Title} - {OJOptions.Name}";
            await WindowInterop.SetTitle(JSRuntime, title);
            if (!string.IsNullOrEmpty(LocalAnchorJump))
            {
                await WindowInterop.ScrollTo(JSRuntime, LocalAnchorJump);
                LocalAnchorJump = null;
            }
        }

        private void LocationChanged(object sender, LocationChangedEventArgs args)
        {
            var url = NavigationManager.Uri;
            if (url.StartsWith(BaseUri))
            {
                var frag = url[BaseUri.Length..];
                if (frag.StartsWith("#"))
                {
                    LocalAnchorJump = HttpUtility.UrlDecode(frag[1..]);
                    StateHasChanged();
                }
            }
        }

        public virtual void Dispose()
        {
            NavigationManager.LocationChanged -= LocationChanged;
        }
    }
}
