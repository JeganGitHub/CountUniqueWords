using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountUniqueWords
{
    public class Program
    {
        /// <summary>
        /// Convenience method which prints the number of occurrences of each word in the given file
        /// </summary>
        public string PrintWordCountsInFile(string fileName)
        {
            try
            {
                var text = System.IO.File.ReadAllText(fileName);
                var words = SplitWords(text);
                var counts = CountWordOccurrences(words);
                WriteWordCounts(counts, System.Console.Out, fileName);
                return counts.Count.ToString();
            }
            catch (FileNotFoundException ex)
            {
                // Write error.
                return "File Not Found!";
            }
            catch (Exception exc)
            {
                return "General Exception";
            }
        }

        /// <summary>
        /// Splits the given text into individual words, stripping punctuation
        /// A word is defined by the regex @"\p{L}+"
        /// </summary>
        public static IEnumerable<string> SplitWords(string text)
        {
            Regex wordMatcher = new Regex(@"[\p{L}']+");
            return wordMatcher.Matches(text).Cast<Match>().Select(c => c.Value);
        }

        /// <summary>
        /// Counts the number of occurrences of each word in the given enumerable
        /// </summary>
        public static IDictionary<string, int> CountWordOccurrences(IEnumerable<string> words)
        {
            return CountOccurrences(words, StringComparer.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Prints word-counts to the given TextWriter
        /// </summary>
        public static void WriteWordCounts(IDictionary<string, int> counts, TextWriter writer, string fileName)
        {
            writer = new StreamWriter("Output_" + fileName);
            
            writer.WriteLine("The number of counts for each words are:");

            foreach (KeyValuePair<string, int> kvp in counts)
            {
                writer.WriteLine("Counts: " + kvp.Value + " for " + kvp.Key.ToLower()); // print word in lower-case for consistency
            }

            writer.Flush();

            writer.Close();
        }

        /// <summary>
        /// Counts the number of occurrences of each distinct item
        /// </summary>
        public static IDictionary<T, int> CountOccurrences<T>(IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            var counts = new Dictionary<T, int>(comparer);

            foreach (T t in items)
            {
                int count;
                if (!counts.TryGetValue(t, out count))
                {
                    count = 0;
                }
                counts[t] = count + 1;
            }

            return counts;
        }

        /// <summary>
        /// Main Console program
        /// </summary>
        static void Main(string[] args)
        {
            //file name
            var fileName = "PositiveAttitude.txt";

            //instante the class
            var program = new Program();

            //Call the method the compute the counts of unique words in the given file.
            var counts = program.PrintWordCountsInFile(fileName);

            //Open the file and show it Notepad
            Process.Start(fileName);

            //Show the output file with unique count of words
            Process.Start("Output_"+fileName);

        }
    }
}
