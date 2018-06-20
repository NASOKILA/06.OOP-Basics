using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> peopleList = new List<Person>();
            List<Product> productList = new List<Product>();

            var peopleInput = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

            var productInput = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

            try
            {
                foreach (var input in peopleInput)
                {
                    string[] arr = input
                        .Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (arr.Length < 2)
                    {
                        Console.WriteLine("Name cannot be empty");
                        return;
                    }

                    Person person = new Person(arr[0], decimal.Parse(arr[1]));

                    if (!peopleList.Contains(person))
                        peopleList.Add(person);

                }

                foreach (var input in productInput)
                {
                    string[] arr = input
                        .Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (arr.Length < 2)
                    {
                        Console.WriteLine("Name cannot be empty");
                        return;
                    }

                    Product product = new Product(arr[0], decimal.Parse(arr[1]));

                    if (!productList.Contains(product))
                        productList.Add(product);
                }



                //Parse commands
                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var tokens = command
                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string nameOfPerson = tokens[0];
                    string nameOfProduct = tokens[1];

                    Person currentPerson = peopleList.First(p => p.Name == nameOfPerson);
                    Product currentProduct = productList.First(p => p.Name == nameOfProduct);

                    //ako moje da si go kupi
                    if (currentPerson.Money >= currentProduct.Cost)
                    {
                        //slagame go v chantata
                        currentPerson.Products.Add(currentProduct);

                        //izvajdame cenata ot parite 
                        currentPerson.Money -= currentProduct.Cost;

                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }
                    else
                    {
                        //ako gi nama parite printirame suobshtenieto
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");

                    }

                }


                foreach (Person person in peopleList)
                {
                    if (person.Products.Count > 0)
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.ToList().Select(p => p.Name))}");
                    else
                        Console.WriteLine($"{person.Name} - Nothing bought");
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}





/*
 =3
Chushki=1;
Jeko Chushki
END

     */
