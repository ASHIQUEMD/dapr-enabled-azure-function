// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

namespace dotnet_azurefunction
{
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.Functions.Extensions.Dapr.Core;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Dapr;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;

    public static class PublishOutputBinding
    {
        [FunctionName("PublishOutputBinding")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "topic/{topicName}")] HttpRequest req,
            [DaprPublish(PubSubName = "messagebus", Topic = "{topicName}")] out DaprPubSubEvent pubSubEvent,
            ILogger log)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            pubSubEvent = new DaprPubSubEvent(requestBody);
        }
    }
}
