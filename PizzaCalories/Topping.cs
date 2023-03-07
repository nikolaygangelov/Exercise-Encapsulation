using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2.00;

        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauseModifier = 0.9;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.ToLower() != "meat" && value.ToLower() != "veggies" && 
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                double typeModifier = 0.00;

                switch (Type.ToLower())
                {
                    case "meat":
                        typeModifier = MeatModifier;
                        break;
                    case "veggies":
                        typeModifier = VeggiesModifier;
                        break;
                    case "cheese":
                        typeModifier = CheeseModifier;
                        break;
                    case "sauce":
                        typeModifier = SauseModifier;
                        break;
                    default:
                        break;
                }

                double result = BaseCaloriesPerGram * typeModifier * Weight;
                return  Math.Round(result, 2);
            }
        }

        

    }
}
