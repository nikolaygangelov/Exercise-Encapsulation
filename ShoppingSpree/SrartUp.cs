using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShoppingSpree
{
    public class SrartUp
    {
        static void Main(string[] args)
        {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
            try
            {
                string personInfo = Console.ReadLine();
                string productInfo = Console.ReadLine();
                string pattern = @"(?<personOrProductName>([A-z]+)?|(\s)|^NULL$|^$)(\=)(?<moneyOrCost>\-?\d+)";

                Regex regexPeople = new Regex(pattern);

                MatchCollection matchesOfpPeople = regexPeople.Matches(personInfo);

                foreach (Match match in matchesOfpPeople)
                {
                    string name = match.Groups["personOrProductName"].Value;
                    int money = int.Parse(match.Groups["moneyOrCost"].Value);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                Regex regexProducts = new Regex(pattern);

                MatchCollection matchesOfProducts = regexProducts.Matches(productInfo);

                foreach (Match match in matchesOfProducts)
                {
                    string name = match.Groups["personOrProductName"].Value;
                    int cost = int.Parse(match.Groups["moneyOrCost"].Value);
                    Product product = new Product(name, cost);
                    products.Add(product);

                }

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

                return;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] peopleAndProducts = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = peopleAndProducts[0];
                string productName = peopleAndProducts[1];

                Person person = people.Find(p => p.Name == personName);
                Product product = products.Find(pr => pr.Name == productName);

                if (person.Money >= product.Cost)
                {
                    person.ProductsPerPerson.Add(product);
                    person.Money -= product.Cost;
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (Person person in people)
            {   
                if (person.ProductsPerPerson.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.ProductsPerPerson.Select(pr => pr.Name))}");
            }

        }
    }
}
