using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Movie.Infrastructure.Elastic
{

    public class ElasticLogger
    {
        private readonly HttpClient _httpClient;
        private readonly string _index = "app-logs";
        public ElasticLogger(HttpClient httpClient)

        {
            _httpClient = httpClient;

            var username = "elastic";
            var password = "B!z@g!@mblp.ir";
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");

            _httpClient.BaseAddress = new Uri("http://192.168.20.181:9200");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task LogAsync<T>(T log)
        {
            var json = JsonSerializer.Serialize(log);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_index}/_doc", content);
            response.EnsureSuccessStatusCode();
        }
    }
}


//public class ElasticLogger
//{
//    public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
//    {
//        var elasticUrl = OptionsData.Elastic.Url;
//        var index = $"G4b-logs-{environment.EnvironmentName?.ToLower()}";

//        Log.Logger = new LoggerConfiguration()
//            .Enrich.FromLogContext()
//            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUrl))
//            {
//                AutoRegisterTemplate = true,
//                IndexFormat = index,
//                NumberOfShards = 2,
//                NumberOfReplicas = 1
//            })
//            .CreateLogger();

//        services.AddLogging(loggingBuilder =>
//            loggingBuilder.ClearProviders().AddSerilog());

//        return services;
//    }
//}
//public class ElasticOption
//{
//    public string Url { get; set; }
//    public string TykIndex { get; set; }
//    public string Username { get; set; }
//    public string Password { get; set; }
//}

