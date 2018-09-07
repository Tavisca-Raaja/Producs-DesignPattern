using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface IProduct
    {
        string Name { get; set; }
         Decimal Fare { get; set; }
        bool status { get; set; }
        string type { get;}
      
    }
}