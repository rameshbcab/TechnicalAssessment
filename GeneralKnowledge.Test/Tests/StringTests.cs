using System;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("      Anagram Test");
            Console.WriteLine("-----------------------------------");
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };

            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("      Unique Chars And Count");
            Console.WriteLine("-----------------------------------");
            var unique = word.Distinct();
            Console.WriteLine("Origninal string : " + word);
            Console.WriteLine("Unique chars : " + new String(unique.ToArray()));
            foreach (char c in unique)
            {
                Console.WriteLine(c + " : " + word.ToCharArray().Count(s => s == c));
            }

        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b
            if (a.Length != b.Length)
                return false;
            var s1Array = a.ToLower().ToCharArray();
            var s2Array = b.ToLower().ToCharArray();

            Array.Sort(s1Array);
            Array.Sort(s2Array);

            a = new string(s1Array);
            b = new string(s2Array);

            return a == b;

        }
    }
}
