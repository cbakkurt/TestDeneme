using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CicekSepeti.Core.IUnitOfWork;
using CicekSepeti.Domain.Context;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CicekSepeti.API.Controllers
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
        private readonly CicekSepetiDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CicekSepetiDbContext db, IUnitOfWork unitOfWork, IProductService productService)
        {
            _logger = logger;
            _db = db;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            _logger.LogInformation("testlog123");
            var test = await _unitOfWork.ProductRepositories.GetAllAsync();
            var testService = await _productService.GetAllProducts();

            var products = _db.Products.ToList();
            var users = _db.Users.ToList();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
