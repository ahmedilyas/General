using FizzBuzz;
using FizzBuzz.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            var ranger = new FizzBuzzLogic();
            var fizzRule = new FBBusinessRules("Fizz", new List<int> { 3 });
            var buzzRule = new FBBusinessRules("Buzz", new List<int> { 5 });
            var fizzBuzzRule = new FBBusinessRules("FizzBuzz", new List<int> { 3, 5 });

            var results = ranger.GetFizzBuzzResults(1, Int32.MaxValue, new List<FBBusinessRules> { fizzRule, buzzRule, fizzBuzzRule });
            foreach (var currentResult in results)
            {
                Console.WriteLine(currentResult);
            }
            Console.ReadLine();
        }
    }
}
