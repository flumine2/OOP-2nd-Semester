using Lab_3.DivideTask;
using Lab_3.TimerTask;
using Lab_3_Part_1.SumOfAPTask;
using System;
using System.Linq;

namespace Lab_3_Part_1
{
    public delegate void DelegWash();

    //SharpWasher
    class Program
    {
        private const string Format = "{0:0.##}";

        static void Main(string[] args)
        {
            //SharpWasherTask();
            //TimerTask();
            //IntegerDivideTask();
            SumPfAPTask();
        }

        public static void SharpWasherTask()
        {
            Garage garage = new Garage();
            garage.Add("BMW", true);
            garage.Add("Volkswagen", true);
            garage.Add("Mercedes", false);
            garage.Add("Infinity", false);
            garage.Add("Kostya", true);

            foreach (Car item in garage)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (Car car in garage)
            {
                DelegWash delegWash = car.Wash;
                Washer.Wash(delegWash);
            }
        }

        public static void TimerTask()
        {
            Console.WriteLine("Enter countdown`s timer:");
            int countdown = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the message:");
            string message = Console.ReadLine();

            Timer.Start(countdown, Console.WriteLine, message);
        }

        public static void IntegerDivideTask()
        {
            Console.WriteLine("Input int array:");
            int[] array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            foreach (int item in array)
            {
                if (IntegerDivide.IsDivisible(item, IntegerDivide.IsDivisibleBy3, IntegerDivide.IsDivisibleBy7))
                {
                    Console.WriteLine($"{item} divided as an integer by the numbers 3 and 7.");
                }
            }
        }

        public static void SumPfAPTask()
        {
            Console.WriteLine("Input accuracy:");
            double accuracy = double.Parse(Console.ReadLine());

            Console.WriteLine("Input startpoint:");
            double startpoint = double.Parse(Console.ReadLine());

            Console.WriteLine(string.Format(Format, SumOfAPService.GetSumOfProgression(startpoint, SumOfAPService.DivideByTwo, accuracy)));
            Console.WriteLine(string.Format(Format, SumOfAPService.GetSumOfProgression(startpoint, SumOfAPService.DivideByMinusTwo, accuracy)));
            Console.WriteLine(string.Format(Format, SumOfAPService.GetSumOfProgression(startpoint, SumOfAPService.DivideByIterarionFactorial, accuracy)));
        }
    }
}
