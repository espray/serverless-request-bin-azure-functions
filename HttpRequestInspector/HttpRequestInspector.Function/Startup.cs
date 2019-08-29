﻿using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(HttpRequestInspector.Function.Startup))]

namespace HttpRequestInspector.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            if (Environment.GetEnvironmentVariable("RequestBinProvider").ToLower() == "memory")
            {
                builder.Services.AddMemoryCache();
                builder.Services.AddSingleton<IRequestBin, InMemoryRequestBin>();
            }
                

            //builder.Services.AddHttpClient();
            //builder.Services.AddSingleton((s) => {
            //    //return new CosmosClient(Environment.GetEnvironmentVariable("COSMOSDB_CONNECTIONSTRING"));
            //});
            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }
    }
}