using SimpleIoCNinject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCNinject.Implement
{
    public class EmailSender:IEmailSender
    {
        public void SendEmail(int userId)
        {
            Console.WriteLine("Email has been send");
        }
    }
}
