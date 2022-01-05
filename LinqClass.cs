using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    public class LinqClass
    {
        public void Ex1()
        {
            string[] names = { "John", "Ali", "Aslam", "Bilal" };
            IEnumerable<string> filterNames = names.Where(n => n.Contains('a'));
            foreach (string name in filterNames)
                Console.WriteLine(name);
        }
        public void FluentSyntax()
        {
            string[] names = { "John", "Ali", "Aslam", "Bilal", "Ahsan" };
            IEnumerable<string> filteredNames = names.Where(n => n.Contains('A')).OrderBy(n => n.Length).Select(n => n.ToUpper());
            foreach (string name in filteredNames)
                Console.WriteLine(name);
        }
        public void GroupExample()
        {
            Console.WriteLine("Grouping Results with LINQ Example");

            int [] numbers = { 15, 24, 35, 42, 51, 63, 70, 81, 90, 7, 62, 46 };
            int divisor = 5;

            var numberGroups = from n in numbers
                               group n by n % divisor into g
                               select new { remainder = g.Key, numbers = g };

            foreach (var nGroup in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by {1} :",
                    nGroup.remainder, divisor);
                foreach (var n in nGroup.numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }
        public bool TestForSquares(IEnumerable<int> numbers, IEnumerable<int> squares)
        {
            //https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/combined-exercise-1
            //The following method should return true if each element in the squares sequence
            // is equal to the square of the corresponding element in the numbers sequence.
            // Try to write the entire method using only LINQ method calls, and without writing
            // any loops.
            return numbers.Select(n => n * n).SequenceEqual(squares);
        }
        public void CallingTestForSquares()
        {
            var num = new List<int>();
            num.Add(1);
            num.Add(2);
            num.Add(3);
            var squares = new List<int>();
            squares.Add(1);
            squares.Add(4);
            squares.Add(9);
            Console.WriteLine(TestForSquares(num, squares));
        }
        public string GetTheLastWord(IEnumerable<string> words)
        {
            //https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/combined-exercise-2
            // Given a sequence of words, get rid of any that don't have the character 'e' in them,
            // then sort the remaining words alphabetically, then return the following phrase using
            // only the final word in the resulting sequence:
            //    -> "The last word is <word>"
            // If there are no words with the character 'e' in them, then return null.
            //
            // TRY to do it all using only LINQ statements. No loops or if statements.
            
            var lastWord = words.Where(n => n.Contains('e')).OrderBy(n => n).LastOrDefault();
            return $"The last word is {lastWord}";
        }

        public void CallingGetTheLastWord()
        {
            var words = new List<string>();
            words.Add("grapes");
            words.Add("apple");
            words.Add("banana");
            words.Add("pear");
            words.Add("orange");
            Console.WriteLine(GetTheLastWord(words));
        }
    }
}
