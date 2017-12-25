using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace ClientNotifications.ServiceExtensions
{
    public static class ClientNotificationServiceExtensions
    {
        public static void AddToastNotification(this IServiceCollection services){
            var assembly = typeof(ClientNotifications.Components.NotificationViewComponent).GetTypeInfo().Assembly;
            //Create an EmbeddedFileProvider for that assembly
            var embeddedFileProvider = new EmbeddedFileProvider(assembly,"ClientNotifications");
            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });
            
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddTransient<IClientNotification,ClientNotification>();
        }
    }
}