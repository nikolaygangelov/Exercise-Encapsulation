using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                string[] info = Console.ReadLine().Split();

                string flour = info[1];
                string technique = info[2];
                double doughWeight = double.Parse(info[3]);

                Dough dough = new Dough(flour, technique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                Topping topping;

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] input = command.Split();

                    string type = input[1];
                    double toppingWeight = double.Parse(input[2]);

                    topping = new Topping(type, toppingWeight);

                    pizza.AddTopping(topping);
                }
                
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
