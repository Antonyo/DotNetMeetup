using DotNetMeetup.Blazor.Client.Services;
using DotNetMeetup.Blazor.Shared.Services.Trace;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetMeetup.Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITraceService, TraceService>();
            services.AddSingleton<AppState>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
