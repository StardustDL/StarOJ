using Microsoft.Extensions.DependencyInjection;
using AcBlog.UI.Components.Loading;
using AcBlog.UI.Components.Markdown;
using AcBlog.UI.Components.AntDesigns;
using AcBlog.Extensions;

namespace StarOJ.Client
{
    public static class ServiceExtensions
    {
        public static void AddUIComponents(this IServiceCollection services)
        {
            services.AddExtensions()
                .AddExtension<ClientUIComponent>()
                .AddExtension<LoadingUIComponent>()
                .AddExtension<MarkdownUIComponent>()
                .AddExtension<AntDesignUIComponent>();
        }
    }
}
