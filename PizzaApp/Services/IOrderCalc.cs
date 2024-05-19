using PizzaApp.Model;

namespace PizzaApp.Services
{
    public interface IOrderCalc
    {
        public string CalcPizza(Order order);
    }
}
