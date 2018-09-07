using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Product
    {
        public static IProduct GetProduct(string product)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            var productType = assembly.GetTypes().FirstOrDefault(t => t.Name == product);
            LogFile.Instance.WriteLog("Returning instance Based on User Value");
            return (IProduct)Activator.CreateInstance(productType);
        }

        public static IFareStrategy GetFareUpdation(string product)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var productType = assembly.GetTypes().FirstOrDefault(t => t.Name == product);
            LogFile.Instance.WriteLog("Returning instance Based on User Value");
            return (IFareStrategy)Activator.CreateInstance(productType);
        }

        public static IDatabase GetDataBaseType(string product)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var productType = assembly.GetTypes().FirstOrDefault(t => t.Name == product);
            LogFile.Instance.WriteLog("Returning instance Based on User Value");
            return (IDatabase)Activator.CreateInstance(productType);
        }

    }
}