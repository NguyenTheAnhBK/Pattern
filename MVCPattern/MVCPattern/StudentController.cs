using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPattern
{
    class StudentController
    {
        public StudentView view { set; get; }
        public Student model { set; get; }
        public void UpdateView()
        {
            view.PrintStudentDetails(model.name, model.rollNo);
        }
    }
}
