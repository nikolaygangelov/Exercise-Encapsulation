using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2.00;

        private const double WhiteDoughModifier = 1.5;
        private const double WholegrainDoughModifier = 1.0;
        private const double CrispyDoughModifier = 0.9;
        private const double ChewyDoughModifier = 1.1;
        private const double HomemadeDoughModifier = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public string FlourType
        {
            get => flourType;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.ToLower() != "chewy" && value.ToLower() != "crispy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                double flourTypeModifier = 0.00;
                double techniqueModifier = 0.00;

                switch (FlourType.ToLower())
                {
                    case "white":
                        flourTypeModifier = WhiteDoughModifier;
                        break;
                    case "wholegrain":
                        flourTypeModifier = WholegrainDoughModifier;
                        break;
                    default:
                        break;
                }

                switch (BakingTechnique.ToLower())
                {
                    case "crispy":
                        techniqueModifier = CrispyDoughModifier;
                        break;
                    case "chewy":
                        techniqueModifier = ChewyDoughModifier;
                        break;
                    case "homemade":
                        techniqueModifier = HomemadeDoughModifier;
                        break;
                    default:
                        break;
                }

                return Math.Round(BaseCaloriesPerGram * flourTypeModifier * techniqueModifier * Weight, 2);
            }
        }

    }
}
