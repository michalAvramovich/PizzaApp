using PizzaApp.Model;
using System.Text;

namespace PizzaApp.Services
{
    public class ToppingCalc: IToppingCalc
    {
        List<int> speicalPriceIds = new List<int>() { 1,2};

        public (int, string) ToppingPizzaCalc(IEnumerable<Topping> toppings, int sum, StringBuilder sb)
        {
            try
            {
                if (toppings!=null && toppings.Count()>0)
                {
                    sb.Append("with toppings:");
                    foreach (var topping in toppings.Take(3))
                    {
                        sum += speicalPriceIds.Contains(topping.Id) ? 3 : 2;
                        sb.Append($" {topping.Name} ");
                    }

                }
                else
                {
                    sb.Append("without toppings");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return (sum, sb.ToString());
        }
    }
}
