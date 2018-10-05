using SimpleIoCNinject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCNinject.Implement
{
    public class Database:IDatabase
    {
        public void Save(int orderId)
        {
            Console.WriteLine("Save real orderId");
        }
    }
}
