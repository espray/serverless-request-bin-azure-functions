﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequestInspector.Function.Models
{
    /// <summary>
    /// Class to implement the Options Pattern described here
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.2#reload-configuration-data-with-ioptionssnapshot
    /// And particularly on Azure Functions here
    /// https://docs.microsoft.com/en-us/azure/architecture/serverless/code
    /// </summary>
    public class RequestBinOptions
    {
        public string RequestBinProvider { get; set; } = "memory";
        public string RequestBinRenderer { get; set; } = "liquid";
        public int RequestBinMaxSize { get; set; } = 20;
        public int RequestBodyMaxLength { get; set; } = 128000;
        public int RequestBinSlidingExpiration { get; set; } = 180;
        public int RequestBinAbsoluteExpiration { get; set; } = 360;
    }
}
