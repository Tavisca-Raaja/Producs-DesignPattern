using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface IDatabase
    {
        void Save(string productname,decimal price,string type,bool isBooked);
        void Book(string productName,decimal price,string type,bool isBooked);
    }
}
