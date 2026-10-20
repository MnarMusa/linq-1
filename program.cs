using System;
using System.Linq;
using LINQ.Models;
using LINQ.DataSources;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Get all products from the "Seafood" category. Print each product's name and price.
            var seafoodProducts = Source.ProductList
                .Where(p => p.Category == "Seafood");

            foreach (var product in seafoodProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.UnitPrice:C2}");
            }





            //2. Get a list of only the product names from ProductList. Print each name.
            var productNames = Source.ProductList
            .Select(p => p.ProductName);

            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }




            //3. Sort all products by UnitPrice (ascending). Print each product's name and price. 
            var sortedProducts = Source.ProductList
                        .OrderBy(p => p.UnitPrice);

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.UnitPrice:C2}");
            }



            //4.Get all products where UnitPrice is between 10 and 30

            var filteredProducts = Source.ProductList
            .Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30m);

           
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.UnitPrice:C2}");
            }


            //5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category. 

            var availableCondiments = Source.ProductList
            .Where(p => p.UnitsInStock > 0 && p.Category.Contains("Condiments"));

          
            foreach (var product in availableCondiments)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Category: {product.Category}, Stock: {product.UnitsInStock}, Price: {product.UnitPrice:C2}");
            }



            //6. Create a new anonymous type with three properties: ● Name → the product name ● Price → the unit price● StockStatus → a string: "Available" if UnitsInStock > 0, otherwise "Out of Stock"● Print the result.
            var productInfo = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            
            foreach (var item in productInfo)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price:C2}, Status: {item.StockStatus}");
            }


            //17.Print each product's name along with its position (1-based) in the list. Expected format: 1. Chai, 2. Chang, etc. 

            var indexedProducts = Source.ProductList
            .Select((p, index) => new { Position = index + 1, Name = p.ProductName });

            foreach (var item in indexedProducts)
            {
                Console.WriteLine($"{item.Position}. {item.Name}");
            }


            //8. Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending. 
            var sortedProducts = Source.ProductList
                        .OrderBy(p => p.Category)
                        .ThenByDescending(p => p.UnitPrice);

=            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Product: {product.ProductName}, Price: {product.UnitPrice:C2}");
            }

            //9. Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.
            var beverages = Source.ProductList
            .Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock);

           
            foreach (var product in beverages)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Stock: {product.UnitsInStock}");
            }


            //10. Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate. 
            var ordersFrom1997 = from c in Source.CustomerList
                                 from o in c.Orders
                                 where o.OrderDate.Year >= 1997
                                 select new
                                 {
                                     c.CustomerID,
                                     o.OrderDate
                                 };

            foreach (var item in ordersFrom1997)
            {
                Console.WriteLine($"CustomerID: {item.CustomerID}, OrderDate: {item.OrderDate:d}");
            }


            //11. Show position number alongside ProductName 
            var indexedProducts = Source.ProductList
            .Select((p, index) => new { Position = index + 1, Name = p.ProductName });

            foreach (var item in indexedProducts)
            {
                Console.WriteLine($"{item.Position}. {item.Name}");
            }


            //12. Sort first by-word length and then by a case -insensitive sort of the words in an array. String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }

            //13. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array. 
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();

          
            foreach (var digit in result)
            {
                Console.WriteLine(digit);
            }

        }
    }
}
