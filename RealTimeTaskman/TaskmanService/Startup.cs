﻿

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TaskmanService.Startup))]
namespace TaskmanService
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}