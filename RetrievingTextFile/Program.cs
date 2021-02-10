using Iveonik.Stemmers;//variation of porter stemmer for . net4.7
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("declaration");;
            Paths(File.OpenRead(@"..\..\Text1.txt"), File.OpenRead(@"..\..\stopwords.txt"));
            Console.ReadLine();
            Console.WriteLine("Alice");
            Paths(File.OpenRead(@"..\..\Text2.txt"), File.OpenRead(@"..\..\stopWords.txt"));
           
            Console.ReadKey();

        }
        //---------------------------------------------------------------------------------------------------------
       /* async */private static void Paths(FileStream fullText, FileStream fullStopWords)
        {
            FileStream fileStream = fullText;
            StreamReader readFullTextFilePath = new StreamReader(fileStream);
            string text;
            text =/* await */readFullTextFilePath.ReadToEnd/*Async*/();
            string fullTextWithoutNonalpha = Regex.Replace(text, "[^A-Za-z0-9 -]", "");
 

            //---------------------------------------------------------------------------------------------------------
            FileStream fileStreamStopWords = fullStopWords;
            StreamReader readStopWordsPath = new StreamReader(fileStreamStopWords);
            string lineOfStopWords;
            string[] linesArrayOfStopWords;
            var list = new List<string>();
            //--------------------------------------------------------------------------------------------------------

            while ((lineOfStopWords = readStopWordsPath.ReadLine()) != null)
            {

                list.Add(lineOfStopWords);
            }
            linesArrayOfStopWords = list.ToArray();

            foreach (string l in linesArrayOfStopWords)
            {
      
            }

            //-----------------------------------------------------------------------------------------------------------
            string valueOfFullText = fullTextWithoutNonalpha; //text is my sentence
            var words = valueOfFullText.Split();//text
            var revisedWords = words.Except(linesArrayOfStopWords, StringComparer.InvariantCultureIgnoreCase);//text exept lines
            //--------------------------------------------------------------------------------------------------------
            StringBuilder input = new StringBuilder(valueOfFullText);
            foreach (var word1 in words)
            {
                foreach (string word in linesArrayOfStopWords)
                {
                    if (word1.Equals(word) && word1.Length == word.Length)
                    {
                        valueOfFullText = string.Join(" ", revisedWords);

                    }
                    fullTextWithoutNonalpha = valueOfFullText;
                }
            }

//-------------------------------------------------------------------------------------------------

            string textBody = fullTextWithoutNonalpha;
            string[] stringArray = textBody.ToString().Split(' ').ToArray();
            TestStemmer(new EnglishStemmer(), stringArray);
            Console.ReadKey();
        }
//-------------------------------------------------------------------------------------------------
        private static void TestStemmer(IStemmer stemmer, params string[] words)
        {
            Dictionary<string, int> CounterForWordFrequency = new Dictionary<string, int>();

            foreach (string term in words)
            {
                var stemmedWord = stemmer.Stem(term);
                // \w+ matches one or more word characters (same as [a-zA-Z0-9_]+ ).
                var match = Regex.Match(stemmedWord, "\\w+");
                while (match.Success)
                {
                    string word = match.Value;
                    if (CounterForWordFrequency.ContainsKey(word))
                    {
                        CounterForWordFrequency[word]++;
                    }
                    else
                    {
                        CounterForWordFrequency.Add(word, 1);

                    }
                    match = match.NextMatch();
                }

            }
                Console.WriteLine("Total word Count:{0}", CounterForWordFrequency.Count);
                Console.WriteLine("Word & Fequency");

                foreach (var element in CounterForWordFrequency.OrderByDescending(x => x.Value).Take(20))
                {

                    Console.WriteLine(element.Key + "-----" + element.Value);
                }
                Console.Write("");

            }
        }
    }

