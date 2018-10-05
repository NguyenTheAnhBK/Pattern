using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUnitTest
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y*9;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
