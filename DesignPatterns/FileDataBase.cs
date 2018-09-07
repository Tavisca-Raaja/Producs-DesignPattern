using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class FileDataBase:IDatabase
    {
        private FileStream _Fstream;
        private StreamWriter _Swriter;

        public FileDataBase()
        {
            _Fstream = new FileStream("c:\\FileData.txt",FileMode.Append,FileAccess.Write);
            _Swriter = new StreamWriter(_Fstream);
        }
        public void Save(string ProductName, Decimal price, string type, bool status)
        {
            _Swriter.WriteLine("ProductType: {0}",type);
            _Swriter.WriteLine("ProductName: {0}",ProductName);
            _Swriter.WriteLine("ProductFare: {0}",price);
            _Swriter.WriteLine("ProductStatus: {0}",status);
            _Swriter.WriteLine("<--------------------------->");
            _Swriter.Flush();
            Console.WriteLine("Product Saved Successfully");
            LogFile.Instance.WriteLog("Product Saved Successfully");
        }
        public void Book(string ProductName, Decimal price, string type, bool status)
        {
            if (status != true)
            {
                status = true;
                _Swriter.WriteLine("ProductType: {0}", type);
                _Swriter.WriteLine("ProductName: {0}", ProductName);
                _Swriter.WriteLine("ProductFare: {0}", price);
                _Swriter.WriteLine("ProductStatus: {0}", status);
                _Swriter.WriteLine("<--------------------------->");
                _Swriter.Flush();
                Console.WriteLine("Product Booked Successfully");
                LogFile.Instance.WriteLog("Product Booked Successfully");
            }
            else
            {
                Console.WriteLine("Currently Unavailable");
                _Swriter.WriteLine("Currently Unavailable");
                LogFile.Instance.WriteLog("Currently Unavailable");
                _Swriter.Flush();
            }
        }
    }
}
