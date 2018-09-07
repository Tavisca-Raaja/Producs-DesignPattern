using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DesignPatterns
{
    class SqlDataBase:IDatabase
    {
        SqlConnection Connection;
        SqlConnectionStringBuilder Connector;
        public SqlDataBase()
        {
             Connection = new SqlConnection();
            try
            {
                Connector = new SqlConnectionStringBuilder();
                Connector.DataSource = "localhost";
                Connector.UserID = "sa";
                Connector.Password = "test123!@#";
                Connector.InitialCatalog = "Product";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
     public void Save(string ProductName,Decimal price,string type,bool status)
        {
            using (Connection = new SqlConnection(Connector.ConnectionString))
            {
                Connection.Open();
                String command = "insert into " + type + " values('" + ProductName + "','" + price + "','" + status + "' )";
                SqlCommand cmd = new SqlCommand(command, Connection);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Entry Saved");
            LogFile.Instance.WriteLog("Content Saved");
        }
        public void Book(string ProductName, Decimal price, string type, bool status)
        {
            using (Connection = new SqlConnection(Connector.ConnectionString))
            {
                if (status == false)
                {
                    Connection.Open();
                    status = true;
                    String command = "update " + type + " set IsBooked ='" + status + "' where Name = '" + ProductName + "'";
                    SqlCommand cmd = new SqlCommand(command, Connection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Entry Booked Successfully");
                    LogFile.Instance.WriteLog("Content Booked Successfully");
                }
                else
                {
                    Console.WriteLine("Currently Unavailable");
                    LogFile.Instance.WriteLog("Currently Unavailable");
                }
            }
        }
    }
}
