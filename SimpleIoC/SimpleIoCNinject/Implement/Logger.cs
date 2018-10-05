using SimpleIoCNinject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCNinject.Implement
{
    public class Logger:ILogger
    {
        public void LogInfo(string info)
        {
            Console.WriteLine(info);
        }
    }
}
