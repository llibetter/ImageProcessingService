using ImageProcessing.Core;
using OpenCVSharpUtils= ImageProcessing.Core.OpenCvSharp;
using MagicNetUtils = ImageProcessing.Core.Magic.Net;
using ImageSharpUtils = ImageProcessing.Core.ImageSharp;
using NetVipsUtils = ImageProcessing.Core.NetVips;
using SkiaSharpUtils = ImageProcessing.Core.SkiaSharp;
using MicrosoftMauiGraphicsUtils = ImageProcessing.Core.Microsoft.Maui.Graphics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageProcessingService.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Trace.WriteLine("hello");

            var sampleTest6 = new MicrosoftMauiGraphicsUtils.SampleTest();
            sampleTest6.Sample1();

            var sampleTest5 = new SkiaSharpUtils.SampleTest();
            sampleTest5.Sample1();

            var sampleTest4 = new NetVipsUtils.SampleTest();
            sampleTest4.Sample1();

            var sampleTest3 = new ImageSharpUtils.SampleTest();
            sampleTest3.Sample1();

            var sampleTest2 = new MagicNetUtils.SampleTest();
            sampleTest2.Sample1();

            var sampleTest = new OpenCVSharpUtils.SampleTest();
            sampleTest.Sample1();
             
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}