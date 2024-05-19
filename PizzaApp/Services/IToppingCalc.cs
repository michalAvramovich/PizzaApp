using PizzaApp.Model;
using System.Text;

namespace PizzaApp.Services
{
    public interface IToppingCalc
    {
        public (int, string) ToppingPizzaCalc(IEnumerable<Topping> toppings, int sum, StringBuilder sb);
    }
}
