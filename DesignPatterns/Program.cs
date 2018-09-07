using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            int ExitCriteria=0;
            try
            {
                Console.WriteLine("Enter the Product Type");
                Console.WriteLine("<--------------------->");
                Console.WriteLine("1. CarProduct   2. AirProduct  3. ActivityProduct  4.HotelProduct");
                string input = Console.ReadLine();
                LogFile.Instance.WriteLog("User Entered the Choice of Product");

                IProduct productType = Product.GetProduct(input);// To Find What The Product User Entered
                LogFile.Instance.WriteLog("Object Created Dynamically");

                IFareStrategy newProduct = Product.GetFareUpdation(input + "Fare");//To Update FareStrategy
                LogFile.Instance.WriteLog("Object for strategy class has been created");

                Console.WriteLine("Enter The Database Type: 1. SqlDataBase  2. FileDataBase ");
                string DataBaseType = Console.ReadLine();
                IDatabase type = Product.GetDataBaseType(DataBaseType);
                do
                {

                    Console.WriteLine("Enter 1 to save or 2 to book");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice);
                    if (choice == 1)
                    {
                        type.Save(productType.Name, newProduct.FareCalculation(productType), productType.type, productType.status);
                    }
                    else if (choice == 2)
                    {
                        type.Book(productType.Name, newProduct.FareCalculation(productType), productType.type, productType.status);
                        productType.status = true;
                        
                    }
                    else
                        Console.WriteLine("Enter a Valid Input");
                     Console.WriteLine();
                     Console.WriteLine("Enter 0 to Exit or 1 to continue");
                     int.TryParse(Console.ReadLine(), out ExitCriteria);
                    
                    LogFile.Instance.WriteLog("User Details are Saved");
                   
                }while (ExitCriteria != 0);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.ReadKey();
            }
        }
    }
}
