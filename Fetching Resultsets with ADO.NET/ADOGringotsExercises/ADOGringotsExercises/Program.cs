using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOGringotsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GringotsContext();

            //FirstLetter(context);

        }

        private static void FirstLetter(GringotsContext context)
        {
            var firstLetters = context
                .WizzardDeposits.Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName.Substring(0, 1))
                .Distinct().OrderBy(w => w)
                .ToList();
            foreach (var letter in firstLetters)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
