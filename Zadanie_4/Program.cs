using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string g = new string('_', 80);
            string path = @"D:\Lab6_Temp";
            string filename = path + "\\lab.dat";
            string tempfile = path + "\\lab_backup.dat";
            Directory.CreateDirectory(path);
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            File.Copy(@"D:\Обучение C#\lab5\lab5\bin\Debug\net5.0\lab.dat", filename);
            using (StreamReader sr = new StreamReader(filename))
            {
                string str = sr.ReadToEnd();
                using (FileStream f = new FileStream(tempfile, FileMode.OpenOrCreate))
                {                   
                    byte[] a = System.Text.Encoding.Default.GetBytes(str);                                     
                    f.Write(a,0,a.Length);                                      
                }
            }
            Console.WriteLine("Директория и файл были успешно созданы.");
            Console.WriteLine(g);
            Console.WriteLine("Размер файла: " + new FileInfo(filename).Length);
            Console.WriteLine(g);
            Console.WriteLine("Время последнего изменения: " + File.GetLastWriteTime(filename));
            Console.WriteLine(g);
            Console.WriteLine("Время последнего доступа к файлу: " + File.GetLastAccessTime(filename));
        }
    }
}
