using System;
using System.IO;

namespace Zadanie_2
{
    class Program
    {
       
    
        static void Main(string[] args)
        {
            //ВАРИАНТ 7
            Console.WriteLine("Программа начала работу");
            
            
            string filename = Directory.GetCurrentDirectory() + "\\file1.dat";
            using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
            {
                for (int M = 1; M <= 5; M++)
                {
                    for (int N = 1; N <= 5; N++)
                    {
                        bw.Write(M);
                        bw.Write(N);
                        bw.Write(Math.Pow(M, N));
                        
                    }
                }               
            }
            foo();
            Console.WriteLine();
        }

        static void foo()
        {   
            string filename1 = Directory.GetCurrentDirectory() + "\\file1.dat";
            string filename2 = Directory.GetCurrentDirectory() + "\\file2.dat";
            using (BinaryReader br = new BinaryReader(File.Open(filename1, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(filename2, FileMode.OpenOrCreate)))
                {                                           
                        br.BaseStream.Position += 6;
                        bw.Write(br.ReadDouble());                                                               
                }
            }
            Console.WriteLine("Программа отработала без ошибок");
        }
    }
}
