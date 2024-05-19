using Microsoft.AspNetCore.Mvc.Filters;
using PizzaApp.Model;
using System.Text;

namespace PizzaApp.Services
{
    public class OrderCalc : IOrderCalc
    {
        private readonly IToppingCalc _toppingCalc;

        public OrderCalc(IToppingCalc topping)
        {
           _toppingCalc = topping;
        }

        public string CalcPizza(Order order) 
        { 
           StringBuilder sb = new StringBuilder();
            try
            {
                if (order!=null && order.pizzas.Count() > 0)
                {
                    Guid guid = Guid.NewGuid();
                    int res = CalcPizzas(order.pizzas, sb);
                    sb.Append($" Order number: {guid}. Order details: sum: {res.ToString()}. status: new");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sb.ToString();
        }

        private int CalcPizzas(IEnumerable<Pizza> pizzas, StringBuilder sb)
        {
            int sum = 0;
            try
            {
                foreach (Pizza pizza in pizzas)
                {
                    sum += 25;
                    sb.Append("pizza ");
                    var toppingResult = _toppingCalc.ToppingPizzaCalc(pizza.Toppings, sum, sb);
                    sum = toppingResult.Item1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sum;
        }
    }
}
