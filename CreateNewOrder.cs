// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

namespace dotnet_azurefunction
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Microsoft.Azure.WebJobs.Extensions.Dapr;
    using Newtonsoft.Json.Linq;

    public static class CreateNewOrder
    {
        /// <summary>
        /// Example to use Dapr Service Invocation Trigger and Dapr State Output binding to persist a new state into statestore
        /// </summary>
        [FunctionName("CreateNewOrder")]
        public static void Run(
            [DaprServiceInvocationTrigger] JObject payload,
            [DaprState("statestore", Key = "order")] out JToken order,
            ILogger log)
        {
            log.LogInformation("C# function processed a CreateNewOrder request from the Dapr Runtime.");

            // payload must be of the format { "data": { "value": "some value" } }
            order = payload["data"];
        }
    }
}