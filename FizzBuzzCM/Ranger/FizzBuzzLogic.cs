using FizzBuzz.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public sealed class FizzBuzzLogic
    {
        public FizzBuzzLogic()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<string> GetFizzBuzzResults(int start, int end, IList<FBBusinessRules> rules)
        {
            // recruiting@clear-measure.com - put on github
            // support any number of diversers and replacement words. customer to provide x business rules.
            // TDD - what test cases to ensure stability over time. make a couple of test cases
            // over a large range without erroring out. (i.e could be efficiency.
            // IEnumerable and yield return new
            // 
            if (end < start)
            {
                throw new ArgumentException("End must not be less than start");
            }

            if (rules == null || rules.Count == 0)
            {
                yield break;
            }

            bool isMatch = false;
            string result = string.Empty;

            for (int counter = start; counter <= end; counter++)
            {
                result = counter.ToString();

                // for each rule - we want to apply that rule
                foreach (var currentRule in rules)
                {
                    foreach (var currentDivisor in currentRule.Divisors) // for each of the divisors
                    {
                        isMatch = counter % currentDivisor == 0; // is it a match?
                        if (!isMatch) // no match, so get out of this loop
                        {
                            break;
                        }
                    }

                    if (isMatch) // matched!
                    {
                        result = currentRule.ReplacementWord; // get the replacement word
                    }
                }

                yield return result;
            }

        }
    }
}
