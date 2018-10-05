using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCNinject.Interface
{
    public interface IEmailSender
    {
        void SendEmail(int userId);
    }
}
