using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobDemoFunctionApp
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static async Task Run([QueueTrigger("myqueue-items", Connection = "Azurefunctions822d656e_CONNECTION")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
            var functionDomain = System.Environment.GetEnvironmentVariable("Function_FQDN");

            var client = new HttpClient();
            if (myQueueItem == "httptrigger1")
            {
                log.Info($"＠＠＠＠＠C# Queue trigger function can processed: {myQueueItem}");
                var response = await client.GetAsync(functionDomain + @"/api/HttpTrigger1?name=helloworld1");
            }
            else if (myQueueItem == "httptrigger2")
            {
                log.Info($"＠＠＠＠＠C# Queue trigger function can processed: {myQueueItem}");
                var response = await client.GetAsync(functionDomain + @"/api/HttpTrigger2?name=helloworld2");
            }
            else
            {
                log.Info($"＠＠＠＠＠C# Queue trigger function can't processed: {myQueueItem}");
            }
        }
    }
}
