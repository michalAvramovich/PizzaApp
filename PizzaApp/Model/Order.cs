namespace PizzaApp.Model
{
    public class Order
    {
        public IEnumerable<Pizza>? pizzas {  get; set; } 
    }

    public class Pizza
    {
        public IEnumerable<Topping>? Toppings { get; set; }
    }

    public class Topping
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
