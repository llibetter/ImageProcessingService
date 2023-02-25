using ImageProcessing.Core;
using ImageProcessing.Core.Implementation;
using ImageProcessing.Core.Utils;
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("[action]")]
        public IActionResult GetSample()
        {
            Trace.WriteLine("hello");

            //var sampleTest6 = new Microsoft_Maui_GraphicsSample();
            //sampleTest6.Sample1();

            var sampleTest5 = new SkiaSharpSample();
            sampleTest5.Sample1();

            var sampleTest4 = new NetVipsSample();
            sampleTest4.Sample1();

            var sampleTest3 = new ImageSharpSample();
            sampleTest3.Sample1();

            var sampleTest2 = new Magic_NetSample();
            sampleTest2.Sample1();

            var sampleTest = new OpenCvSharpSample();
            sampleTest.Sample1();

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetFormatConvert()
        {
            Trace.WriteLine("hello");

            var sampleTest4 = new NetVipsSample();
            using var srcStream = FileUtils.LocalFile2Stream("lenna.png");
            foreach (var targetFormat in new MyImageFormat[] {  
                MyImageFormat.Tiff, MyImageFormat.Webp,
                //MyImageFormat.Bmp, 
                MyImageFormat.Jpeg, MyImageFormat.Png
                })
            {
                using var resStream = sampleTest4.FormatConvert(srcStream, targetFormat.ToString(), 0.5f);
                FileUtils.Stream2LocalFile(resStream,
                    $"./Output/lenna_netvips_formatconvert{CommonUtils.GetExtensionWithDot(targetFormat)}");
            }
            return Ok();
        }
    }
}