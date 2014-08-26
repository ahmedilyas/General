using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.BusinessRules
{
    public class FBBusinessRules
    {
        public string ReplacementWord { get; private set; }
        public IList<int> Divisors { get; private set; }

        public FBBusinessRules(string replacementWord, IList<int> divisor)
        {
            this.ReplacementWord = replacementWord;
            this.Divisors = divisor;
        }
    }
}
