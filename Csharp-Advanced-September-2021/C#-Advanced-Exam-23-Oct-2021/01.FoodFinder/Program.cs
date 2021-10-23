using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            words.Add("pear", 0);
            words.Add("flour", 0);
            words.Add("pork", 0);
            words.Add("olive", 0);

            List<char> pear = "pear".ToCharArray().ToList();
            List<char> flour = "flour".ToCharArray().ToList().ToList();
            List<char> pork = "pork".ToCharArray().ToList();
            List<char> olive = "olive".ToCharArray().ToList();

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                vowels.Enqueue(vowel);
                char consonant = consonants.Pop();
                if (pear.Contains(vowel))
                {
                    pear.Remove(vowel);
                }
                if (pear.Contains(consonant))
                {
                    pear.Remove(consonant);
                }
                if (flour.Contains(vowel))
                {
                    flour.Remove(vowel);
                }
                if (flour.Contains(consonant))
                {
                    flour.Remove(consonant);
                }
                if (olive.Contains(vowel))
                {
                    olive.Remove(vowel);
                }
                if (olive.Contains(consonant))
                {
                    olive.Remove(consonant);
                }
                if (pork.Contains(vowel))
                {
                    pork.Remove(vowel);
                }
                if (pork.Contains(consonant))
                {
                    pork.Remove(consonant);
                }

                if (pork.Count == 0)
                {
                    words["pork"]++;
                    pork = "pork".ToCharArray().ToList();
                }
                if (olive.Count == 0)
                {
                    words["olive"]++;
                    olive = "olive".ToCharArray().ToList();
                }
                if (flour.Count == 0)
                {
                    words["flour"]++;
                    flour = "flour".ToCharArray().ToList();
                }
                if (pear.Count == 0)
                {
                    words["pear"]++;
                    pear = "pear".ToCharArray().ToList();
                }
            }
            words = words.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Words found: {words.Sum(x => x.Value)}");
           
            foreach (var word in words)
            {
                Console.WriteLine(word.Key);
            }
               
        }
    }
}
