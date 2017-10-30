using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace JobDemoFunctionApp
{
    public static class SQLDBTimerTrigger
    {
        [FunctionName("SQLDBTimerTrigger")]
        public static void Run([TimerTrigger("* */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.UtcNow}");
            var list = new List<MovieModel>();
            var str = ConfigurationManager.ConnectionStrings["SQLDB_CONNECTION"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                var text = "SELECT * FROM MOVIES;";
                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            var model = new MovieModel()
                            {
                                Id = reader["Id"] as int?,
                                Title = reader["TITLE"] as string,
                            };
                            list.Add(model);
                            log.Info($"@@@ {model}");
                        }
                    }
                    log.Info($"{list.Count} rows were extracted");
                }
            }

        }
    }

    public class MovieModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return "{ Id=" + Id + ", Title=" + Title + " }";
        }
    }
}
