using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{

    public class Product
    {
        // Deserialized json constructed class with non nullable variables. Meaning all behaviour will be predictable.
        public string name { get; set; }
        public int domestic { get; set; }
        public float price { get; set; }
        public int weight { get; set; }
        public string description { get; set; }

        // Nullsafe constructor for product so any variable can be null and not effect final tally.
        public Product(string? name,
                       bool? domestic,
                       float? price,
                       int? weight,
                       string? description)
        {
            if (name == null)
            {
                this.name = string.Empty;
            }else
            {
                this.name = name;
            }
            if (domestic == null)
            {
                this.domestic = 3;
            }
            else if (domestic == true)
            {
                this.domestic = 1;
            }
            else
            {
                this.domestic = 0;
            }
            if (price == null)
            {
                this.price = 0;
            }else
            {
                this.price = (float)price;
            }
            if (weight == null)
            {
                this.weight = 0;
            }else
            {
                this.weight = (int)weight;
            }
            if (description == null)
            {
                this.description = string.Empty;
            }else
            {
                this.description = description;
            }
        }

        // Simple printAll() func for product with checks for zeroes.
        public void printAll()
        {
            if (name.Length > 0)
            {
                Console.WriteLine(name);
            }
            if (price != 0)
            {
                Console.WriteLine("    " + "Price: $" + price.ToString("N1"));
            }
            if (description.Length >= 10)
            {
                Console.WriteLine("    " + description.Substring(0, 10) + "...");
            }
            else if (description.Length != 0)
            {
                Console.WriteLine("    " + description);
            }
            if (weight != 0)
            {
                Console.WriteLine("    " + "Weight: " + weight + "g");
            }
            else
            {
                Console.WriteLine("    " + "Weight: N/A");
            }
        }
    }

}
