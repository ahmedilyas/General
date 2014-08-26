using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzz.BusinessRules;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using FizzBuzz;

namespace FizzBuzzUnitTest
{
    [TestClass]
    public class FizzBuzzTests
    {
        /// <summary>
        /// Unit test to determine if the number of items given to process is the same number that returns back in the result set
        /// i.e if I say I want a max of 20, I get back 20 results
        /// </summary>
        [TestMethod]
        public void Test_Return_Correct_Items()
        {
            var fbRules = new List<FBBusinessRules>
            {
                new FBBusinessRules("Fizz", new List<int> { 3 }),
                new FBBusinessRules("Buzz", new List<int> { 5 }),
                new FBBusinessRules("FizzBuzz", new List<int> { 3, 5 })
            };

            var fizzBuzzer = new FizzBuzzLogic();
            
            var results = fizzBuzzer.GetFizzBuzzResults(1, 100, fbRules).ToList();
            var expected = 100;
            var actual = results.Count;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Test_Ensure_No_Results_With_No_Rules()
        {
            var fbRules = new List<FBBusinessRules>
            {
            };

            var fizzBuzzer = new FizzBuzzLogic();

            var results = fizzBuzzer.GetFizzBuzzResults(1, 100, fbRules).ToList();
            var expected = 0;
            var actual = results.Count;

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Test_Ensure_All_Correct_Replacements()
        {
            var fbRules = new List<FBBusinessRules>
            {
                new FBBusinessRules("Fizz", new List<int> { 3 }),
                new FBBusinessRules("Buzz", new List<int> { 5 }),
                new FBBusinessRules("FizzBuzz", new List<int> { 3, 5 })
            };

            var fizzBuzzer = new FizzBuzzLogic();

            var results = fizzBuzzer.GetFizzBuzzResults(1, 100, fbRules).ToList();
            
            // how many Fizz? Buzz? FizzBuzz? did we find them?
            var fizzExists = results.Count(r => string.Equals(r, "fizz", StringComparison.OrdinalIgnoreCase)) > 0;
            var buzzExists = results.Count(r => string.Equals(r, "buzz", StringComparison.OrdinalIgnoreCase)) > 0;
            var fizzBuzzExists = results.Count(r => string.Equals(r, "fizzbuzz", StringComparison.OrdinalIgnoreCase)) > 0;

            Assert.IsTrue(fizzExists);
            Assert.IsTrue(buzzExists);
            Assert.IsTrue(fizzBuzzExists);
        }

        [TestMethod]
        public void Test_Ensure_First_Last_Correct_Range()
        {
            var fbRules = new List<FBBusinessRules>
            {
                new FBBusinessRules("Fizz", new List<int> { 3 }),
                new FBBusinessRules("Buzz", new List<int> { 5 }),
                new FBBusinessRules("FizzBuzz", new List<int> { 3, 5 })
            };

            var fizzBuzzer = new FizzBuzzLogic();

            var results = fizzBuzzer.GetFizzBuzzResults(1, 100, fbRules).ToList();
            
            Assert.IsTrue(results.First() == "1");
            Assert.IsTrue(results.Last() == "Buzz"); // I would expect the last one to be buzz since its on every 5th number
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Ensure_Exception_When_End_Range_Less_Start()
        {
            var fbRules = new List<FBBusinessRules>
            {
                new FBBusinessRules("Fizz", new List<int> { 3 }),
                new FBBusinessRules("Buzz", new List<int> { 5 }),
                new FBBusinessRules("FizzBuzz", new List<int> { 3, 5 })
            };

            var fizzBuzzer = new FizzBuzzLogic();
            var results = fizzBuzzer.GetFizzBuzzResults(100, 50, fbRules).ToList();

        }
    }
}
