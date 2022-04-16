using System;
using System.IO;
using System.Collections.Generic;

namespace Zadanie_2
{
    class Program
    {

        public struct Action
        {
            public Action(int M, int N, double MN)
            {
                this.M = M;
                this.N = N;
                this.MN = MN;
            }
            public int M;
            public int N;
            public double MN;
        }

        static void Main(string[] args)
        {
            //ВАРИАНТ 7           
            List<double> thirdnumber = new List<double>();
            List<Action> allnumber = new List<Action>();

            for (int M = 1; M <= 5; M++)
            {
                for (int N = 1; N <= 5; N++)
                {
                    double MN = Math.Pow(M, N);                   
                    allnumber.Add(new Action(M, N, Math.Pow(M, N)));
                }
            }

            for (int i = 0; i < allnumber.Count; i++)
            {
                Console.WriteLine(allnumber[i].M + "\t" + allnumber[i].N + "\t" + allnumber[i].MN);
            }
            
            writer1(allnumber);
            reader2(thirdnumber);
            writer2(thirdnumber);           
        }
        static string filename1 = Directory.GetCurrentDirectory() + "\\file1.dat";
        static string filename2 = Directory.GetCurrentDirectory() + "\\file2.dat";
        static void writer1(List<Action> allnumber)
        {
   
            for(int i = 0; i < allnumber.Count; i++)
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename1, FileMode.Append)))
            {
                    writer.Write($"{allnumber[i].M} {allnumber[i].N} {allnumber[i].MN}");
            }
        }

        static void reader2(List<double> thirdnumber)
        {
            using (BinaryReader br = new BinaryReader(File.Open(filename1, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    string[] entryStrings = br.ReadString().Split();
                    thirdnumber.Add(Double.Parse(entryStrings[2]));
                }
            }
        }

        static void writer2(List<double> thirdnumber)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filename2, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < thirdnumber.Count; i++)
                {
                    bw.Write(thirdnumber[i]);
                }
            }
        }
    }
}

