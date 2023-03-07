using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> productsPerPerson;

        public Person()
        {

        }
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            ProductsPerPerson = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }


        public int Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }
        public List<Product> ProductsPerPerson
        {
            get { return productsPerPerson; }
            set { productsPerPerson = value; }
        }


        public void AddProduct(Product product)
        {
            ProductsPerPerson.Add(product);
        }

    }
}
