using Npgsql;
using System.Text.Json;
using System.Xml.Linq;

namespace PostgreQueryRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 1;

            string textFile = System.IO.Directory.GetCurrentDirectory() + "\\input.json";

            string text = File.ReadAllText(textFile);

            var root = JsonSerializer.Deserialize<Root>(text);


            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    root.appsettings.host,
                    root.appsettings.username,
                    root.appsettings.dbname,
                    root.appsettings.port,
                    root.appsettings.password);


            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    Console.Out.WriteLine("Opening connection");
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("Error on opening connection: " + ex.Message);
                }

                foreach (var query in root.queries)
                {

                    try
                    {
                        using (var command = new NpgsqlCommand(query, conn))
                        {
                            command.ExecuteNonQuery();
                            Console.Out.WriteLine("Finished executing command: {0}/{1}", count, root.queries.Count);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine("Error executing command: {0}/{1}", count, root.queries.Count);
                    }
                    count++;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}