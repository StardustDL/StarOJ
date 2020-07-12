using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using StarOJ.Client.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace StarOJ.Client.Pages.Settings
{
    public class BaseSettingsPage : BasePage
    {
        protected override string Title
        {
            get => base.Title; set
            {
                if (string.IsNullOrEmpty(value))
                    value = $"Settings";
                else
                    value = $"{value} - Settings";
                base.Title = value;
            }
        }
    }
}
