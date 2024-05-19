using Microsoft.AspNetCore.Mvc;
using PizzaApp.Model;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
   
        private readonly IOrderCalc _orderCalc;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOrderCalc orderCalc)
        {
            _logger = logger;
            _orderCalc = orderCalc;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<string> Get()
        {
            try
            {
                IEnumerable<Topping> toppings1 = new List<Topping>()
                {
                    new Topping { Id =3, Name = "Mashrooms"},
                    new Topping { Id =1, Name = "Moozarella"}
                };
                Pizza pizza1 = new Pizza();
                pizza1.Toppings = toppings1;

                Pizza pizza2 = new Pizza();

                Order order = new Order() { pizzas = new List<Pizza>() { pizza1, pizza2 } };

                return _orderCalc.CalcPizza(order); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError); ;
            } 
        }
    }
}
