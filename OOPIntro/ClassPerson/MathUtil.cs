using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPerson
{
    class MathUtil
    {
        public static double Sum(double firstNum, double secNum)
        {
            return firstNum + secNum;
        }

        public static double Subtract(double firstNum, double secNum)
        {
            return firstNum - secNum;
        }

        public static double Multiply(double firstNum, double secNum)
        {
            return firstNum * secNum;
        }

        public static double Divide(double divident, double divisor)
        {
            return divident / divisor;
        }
        public static double Percentage(double totalNum, double percent)
        {
            return totalNum * percent/ 100;
        }
    }
}
