/*************************************************************************
 * Copyright © 2019 Fragged Games, Doug Wilson https://fragged.com
 * 
 * This file is part of Pretender
 *
 * Pretender is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Pretender is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public 
 * License along with Pretender.  If not, please visit 
 * https://www.gnu.org/licenses/ to obtain a copy.
 *
 ************************************************************************/

using Lamar;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace Pretender.Server
{
    public class EntryPoint
    {
        public static void Main(String[] args)
        {
            Run(CreateWebHostBuilder(args).Build());
        }

        private static void Run(IWebHost host)
        {
            using (var container = host.Services.GetService<IContainer>())
            {
                var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
                var logger = container.GetService<ILogger<EntryPoint>>();
                logger.LogInformation("Pretender {Version}", version);
#if DEBUG
                logger.LogDebug(container.WhatDidIScan());
                logger.LogDebug(container.WhatDoIHave());
#endif
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UsePretenderLogging()
                .UseLamar(new PretenderServiceRegistry());
    }
}
