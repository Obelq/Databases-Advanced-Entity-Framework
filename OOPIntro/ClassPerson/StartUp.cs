using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPerson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //PersonConstructor();

            //OldestFamilyMember();

            //StrudntsTask();

            //Planck();

            MathUtilities();
            
        }

        private static void MathUtilities()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var command = input[0];
                if (command == "End")
                {
                    break;
                }
                var firstNum = double.Parse(input[1]);
                var secNum = double.Parse(input[2]);
                switch (command)
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(firstNum, secNum):F2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Subtract(firstNum, secNum):F2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(firstNum, secNum):F2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(firstNum, secNum):F2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percentage(firstNum, secNum):F2}");
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Planck()
        {
            Console.WriteLine(Calculation.ReducedPlanckConstant());
        }

        private static void StrudntsTask()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var student = new Student(input);
            }
            Console.WriteLine(Student.counter);
        }

        private static void OldestFamilyMember()
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }
            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }

        private static void PersonConstructor()
        {
            var input = Console.ReadLine().Split(',').ToArray();
            Person person;
            if (input[0] == "")
            {
                person = new Person();
            }
            else if (input.Length == 2)
            {
                person = new Person(input[0], int.Parse(input[1]));
            }
            else
            {
                int age;
                if (int.TryParse(input[0], out age))
                {

                    person = new Person(age);
                }
                else
                {

                    person = new Person(input[0]);
                }
            }
        }
    }
}
