using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {          
            string filename3 = Directory.GetCurrentDirectory() + "\\file1.txt";
            string newfilename3 = Directory.GetCurrentDirectory() + "\\file2.txt";           
            int k = 0;
            File.Create(newfilename3).Close();
            Console.WriteLine("Текст файла: ");
            using (StreamReader sr = new StreamReader(filename3))
            {
                using (StreamWriter streamwriter = new StreamWriter(newfilename3, false))
                {                  
                    while (!sr.EndOfStream)
                    {                        
                        string[] Array2 = sr.ReadLine().Split();
                        for (int i = 0; i < Array2.Length; i++)
                        {

                            string str = Array2[i];
                            Console.WriteLine(str);
                            if (str == string.Empty)
                            {
                                streamwriter.WriteLine(str);
                                k++;
                            }
                            else if (str != string.Empty)
                            {
                                streamwriter.WriteLine(str + "(c)Student");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Количество пустых строк: " + k);
            using (StreamReader sr = new StreamReader(newfilename3))
            {
                while (!sr.EndOfStream)
                {                   
                    string[] Array2 = sr.ReadLine().Split();
                    for (int i = 0; i < Array2.Length; i++)
                    {
                        string str = Array2[i];
                        Console.WriteLine(str);
                    }
                }
            }
        }
    }
}
