using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Environment.CurrentDirectory;

            Console.Write("Please enter a file name: ");

            string fileName = Console.ReadLine();

            string backUPFolder = "..\\..\\..\\";

            string filePath = string.Concat(backUPFolder, fileName);
            


            string fullPath = Path.Combine(directory, filePath);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {


                    string line = sr.ReadToEnd();

                    string[] words = line.Split(new Char[0], StringSplitOptions.RemoveEmptyEntries);


                    //Console.WriteLine(wordsWords);
                    string[] sentences = line.Split('.', '!', '?');
                    Console.WriteLine();
                    Console.WriteLine($"{fileName} has --> {words.Length} <--words in the file.");
                    Console.WriteLine();
                    Console.WriteLine($"{fileName} has --> {sentences.Length - 1} <-- sentences in the file.");
                    //Console.WriteLine(line);



                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
