using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassPerson
{
    class Calculation
    {
        private static double planck = double.Parse("6.62606896e-34", System.Globalization.NumberStyles.Float);
        private static double pi = 3.14159;

        public static double ReducedPlanckConstant()
        {
            return planck / (2 * pi);
        }
    }
}
