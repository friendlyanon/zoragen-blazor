/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace zoragen_blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IZoraGenDetails, ZoraGenDetails>();
            services.AddSingleton<ILocalStorage, LocalStorage>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            JSRuntime.Current.InvokeAsync<object>("ZoraGen.doneLoading");
            app.Services.GetService<IZoraGenDetails>().InitAsync(
                app.Services.GetService<ILocalStorage>()
            );
            app.AddComponent<App>("app");
        }
    }
}
