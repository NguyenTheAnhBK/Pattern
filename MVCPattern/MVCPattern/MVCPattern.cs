using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern
{
    class MVCPattern
    {
        static void Main(string[] args)
        {
            Student model = RetriveStudentFromDatabase();
            StudentView view = new StudentView();
            StudentController studentController = new StudentController() { model = model, view = view };
            studentController.UpdateView();
            studentController.model.name = "Tran Van A";
            studentController.UpdateView();
            Console.ReadKey();
        }
        private static Student RetriveStudentFromDatabase()
        {
            Student student = new Student { name = "Nguyen The Anh", rollNo = "20160154" };
            return student;
        }
    }
}
