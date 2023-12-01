using Microsoft.AspNetCore.Mvc;

using StackExchange.Redis;

namespace DockerWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetRedisData")]
        public string GetRedisData()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("my-redis:6379,abortConnect=false");
            IDatabase db = redis.GetDatabase();

            string value = "abcdefg";
            db.StringSet("mykey", value);

            //Console.Write(db.ToString());

            /*This would be the null forgiving operator.
            It tells the compiler "this isn't null, trust me", so it does not issue a warning for a possible null reference.*/
            string value2 = (string)db.StringGet("mykey")!;
            Console.WriteLine(value2);
            return value2;

        }

    }
}