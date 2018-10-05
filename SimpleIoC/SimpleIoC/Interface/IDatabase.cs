using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoC.Interface
{
    public interface IDatabase
    {
        void Save(int orderId);
    }
}
