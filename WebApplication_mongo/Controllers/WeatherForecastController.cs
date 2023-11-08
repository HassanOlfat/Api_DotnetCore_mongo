using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;
using WebApplication_mongo.data;
namespace WebApplication_mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;

        public WeatherForecastController(ApplicationDbContext context, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _context = context;


        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {

            _context.BankInfoDrivers.AddAsync(new BankInfoDriver { BankName="", });

            var address =new List<AddressInfo>();
            address.Add(new AddressInfo { Pelak = "12", Address = "" });


            var driver = new Driver { Name = "Hassan", FamilyName = "Olfat",AddressInfo = address
            };
            var a=   _context.Drivers.AddAsync(driver);

            _context.BankInfoDrivers.AddAsync(new BankInfoDriver { BankName = "",DriverId= driver._id });

            _context.SaveChanges();


          
            return driver._id.ToString();
        }
    }
}
