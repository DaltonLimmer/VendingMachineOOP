using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            string absFilePath = "";
            bool hasFile = true;
            string directory = Environment.CurrentDirectory;
            string fileName = "";
            while (hasFile)
            {

                Console.WriteLine("Your current directory is displayed below");
                Console.Write(@"****C:\Users\Mataan Abucar\workspace\team4-c-week4-pair-exercises\m1-w4d3-file-io-part2-exercises-pair\...");
                Console.WriteLine();

                Console.WriteLine("Please enter a file path: ");


                fileName = Console.ReadLine();

                //if (File.Exists(@"C:\Users\Mataan Abucar\workspace\team4-c-week4-pair-exercises\m1-w4d3-file-io-part2-exercises-pair\"+fileName))
                if (File.Exists(fileName))
                {

                    hasFile = false;

                }
                else
                {
                    Console.WriteLine("that file doesnt exist, please enter a differnt filename");
                }


            }
            


            Console.WriteLine("Please enter directory to save NEW file: ");
            Console.Write(@"C:\Book\...");

            string fullPathNew = Console.ReadLine();

            Directory.CreateDirectory(@"C:\Book\"+fullPathNew);

            string newPath = "";

            hasFile = true;


            while (hasFile)
            {

                Console.WriteLine("Please enter name of NEW file to save: ");

                string newFileName = Console.ReadLine();

                newPath = Path.Combine(@"C:\Book\" + fullPathNew, newFileName);

                if (!File.Exists(newPath))
                {

                    hasFile = false;

                }
                else
                {

                    Console.WriteLine("File Already Exist!!!");

                    for (int i = 3; i > 0; i--)
                    {
                        Console.WriteLine($"{i}---{i}---{i}---{i}---{i}");
                        System.Threading.Thread.Sleep(700);
                    }

                    //System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                }


            }

            string backUPFolder = "..\\..\\..\\";

            string filePath = string.Concat(backUPFolder, fileName);

            string fullPath = fileName;

            //string fullPath = Path.Combine(directory, filePath);
            

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    Console.Write("What phrase are you looking for? ");
                    string answerPhrase = Console.ReadLine().ToLower();
                    Console.Write("What would you like to change it to? ");
                    string changedPhrase = Console.ReadLine();

                    using (StreamWriter sw = new StreamWriter(newPath))
                    {


                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine().ToLower();


                            string newLine = line.Replace(answerPhrase, changedPhrase);

                            sw.WriteLine(newLine);


                        }
                    }


                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("that is an error, check your butt");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
