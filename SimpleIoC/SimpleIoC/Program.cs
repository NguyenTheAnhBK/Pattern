using SimpleIoC.Implement;
using SimpleIoC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            //với mỗi interface ta define 1 module tương ứng
            DIContainer.SetModule<IDatabase, Database>();
            DIContainer.SetModule<IEmailSender, EmailSender>();
            DIContainer.SetModule<ILogger, Logger>();
            DIContainer.SetModule<Cart, Cart>();

            //DIContainer sẽ tự inject database, logger và cart
            var myCart = DIContainer.GetModule<Cart>();
            //Khi cần thay đổi ta chỉ cần sửa code define
            //DIContainer.SetModule<IDatabase, XMLDatabase>();
            myCart = new Cart(new Database(), new EmailSender(), new Logger());
            //Khi cần thay đổi database, logger, emailSender
            //myCart = new Cart(new XMLDatabase(), new FakeEmailSender(), new FakeLogger());
            myCart.Checkout(2, 3);
            Console.ReadKey();

        }
    }
    //Nhiệm vụ của DIContainer là chứa các Interface, Module tương ứng vào 1 Dictionary có key là Interface
    //và value là module. Để lấy được module từ Container ta cần đưa vào Interface của module đó.

    public class DIContainer {
        //Dictionary để chứa Interface và module tương ứng
        private static readonly Dictionary<Type, Object> resgisteredModules = new Dictionary<Type, object>();
        //
        public static void SetModule<TInterface, TModule>()
        {
            SetModule(typeof(TInterface), typeof(TModule));
        }
        public static T GetModule<T>()
        {
            return (T)GetModule(typeof(T));
        }
        private static void SetModule(Type interfaceType, Type moduleType)
        {
            //Kiểm tra module đã implement interface chưa
            if(!interfaceType.IsAssignableFrom(moduleType))
            {
                throw new Exception("Wrong Module type");
            }
            //tìm constructor đầu tiên
            var firstConstructor = moduleType.GetConstructors()[0];
            object module = null;
            //Nếu không có tham số
            if(!firstConstructor.GetParameters().Any())
            {
                //khởi tạo module
                module = firstConstructor.Invoke(null);
            }
            else
            {
                //Lấy các tham số của constructor
                var constructorParameters = firstConstructor.GetParameters();
                var moduleDependencies = new List<Object>();
                foreach(var parameter in constructorParameters)
                {
                    var dependency = GetModule(parameter.ParameterType);
                    moduleDependencies.Add(dependency);
           
                }
                //Truyền (inject) các dependency vào Constructor của module
                module = firstConstructor.Invoke(moduleDependencies.ToArray());
            }
            //Lưu trữ các interface và module tương ứng
            resgisteredModules.Add(interfaceType, module);
        }
        private static object GetModule(Type interfaceType)
        {
            if (resgisteredModules.ContainsKey(interfaceType))
                return resgisteredModules[interfaceType];
            throw new Exception("Module not register");
        }
    }

}
