using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace ITCOURSES;

public class ITCOURSESWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<ITCOURSESWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
