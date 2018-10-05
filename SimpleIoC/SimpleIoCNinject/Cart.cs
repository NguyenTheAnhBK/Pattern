using SimpleIoCNinject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoCNinject
{
    public class Cart
    {
        private readonly IDatabase _db;
        private readonly IEmailSender _es;
        private readonly ILogger _log;
        public Cart(IDatabase db, IEmailSender es, ILogger log)
        {
            _db = db;
            _es = es;
            _log = log;
        }
        public void Checkout(int orderId, int userId)
        {
            _db.Save(orderId);
            _es.SendEmail(userId);
            _log.LogInfo("Order has been checkout");
        }
    }
}
