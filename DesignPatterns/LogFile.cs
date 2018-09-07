using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class LogFile
    {
        public static LogFile _instance;
        static int Steps = 1;
        private FileStream _FStream;
        private StreamWriter _Fwriter;
       public static LogFile Instance
       {
         get
         {
          if(_instance == null)
          _instance = new LogFile();
          return _instance;
         }
       }
       private LogFile()
       {
         _FStream = File.OpenWrite("C:/LogFile");
         _Fwriter = new StreamWriter(_FStream);
       }
       public void WriteLog(string message)
       {
         String Message = "Step " + Steps + ": " + message;
         _Fwriter.WriteLine(Message);
         Steps++;
         _Fwriter.Flush();
       }
    }
 }

