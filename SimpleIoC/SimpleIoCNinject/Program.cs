using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SimpleIoCNinject.Implement;
using SimpleIoCNinject.Interface;
using Unity;

namespace SimpleIoCNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*Use Ninject để inject*/
            //var kernel = new StandardKernel();
            //kernel.Bind<IDatabase>().To<Database>();
            //kernel.Bind<IEmailSender>().To<EmailSender>();
            //kernel.Bind<ILogger>().To<Logger>();
            //kernel.Bind<Cart>().To<Cart>();
            ////DIContainer sẽ tự inject Database, Logger, EmailSender vào Cart
            //var myCart = kernel.Get<Cart>();

            /*Usse Unity để inject*/
            var container = new UnityContainer();
            container.RegisterType<IDatabase, Database>();
            container.RegisterType<IEmailSender, EmailSender>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<Cart, Cart>();

            var myCart = container.Resolve<Cart>();
            myCart = new Cart(new Database(), new EmailSender(), new Logger());
            myCart.Checkout(1, 2);
            Console.ReadKey();
        }
    }
}
