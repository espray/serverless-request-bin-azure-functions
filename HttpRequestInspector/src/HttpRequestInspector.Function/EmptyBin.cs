using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using HttpRequestInspector.Function.Services;

namespace HttpRequestInspector.Function
{
    public class EmptyBin
    {
        private readonly IRequestBinManager RequestBinManager;

        public EmptyBin(IRequestBinManager requestBinManager)
        {
            RequestBinManager = requestBinManager;
        }

        [FunctionName("EmptyBin")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, 
            "delete", 
            Route = "bin/{binId}")] HttpRequest request,
            string binId,
            ILogger log)
        {
            try
            {
                log.LogInformation(new EventId(300), "{BinId}, {Message}", binId, $"A request to delete request history for bin '{binId}' has been received.");

                if (!RequestBinManager.IsBinIdValid(binId, out var validationMessage))
                {
                    log.LogError(new EventId(391), "{BinId}, {Message}", binId, $"Invalid Bin Id '{binId}'.");
                    return new BadRequestObjectResult(validationMessage);
                }
                RequestBinManager.EmptyBin(binId);
                log.LogInformation(new EventId(310), "{BinId}, {Message}", binId, $"Request history for bin '{binId}' has been deleted.");
                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(new EventId(290), ex, "{BinId}", binId, $"Error occurred returning request history for bin: '{binId}'");
                throw;
            }
        }
    }
}
