using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebUI.Repository;
using WebUI.Services;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQwNDY5QDMxMzkyZTMxMmUzMGJhU0NxbWNiOU9aeEltalNCRnFrZi85MTQvSUI1SlhPUFFPZHVyZm1XNGM9");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("oidc", options.ProviderOptions);
                options.ProviderOptions.DefaultScopes.Add("profile");
            });

            builder.Services.AddScoped<IGenericRepository, GenericRepository>();
            builder.Services.AddScoped<IMeasurementService, MeasurementService>();

            await builder.Build().RunAsync();
        }
    }
}
