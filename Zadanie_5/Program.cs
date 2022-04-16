using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;


namespace Zadanie_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag2 = true;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите диск на котором лежит файл: D или C (если файл находится на том же диске, что и приложение, введите +)");
                string act = Console.ReadLine();
                switch (act)
                {
                    case "D":
                        string FileName = string.Empty;
                        string[] allfilesD = Directory.GetFiles(@"D:\" , "*.bmp");
                        if (allfilesD.Length == 0)
                        {
                            Console.WriteLine("файлов такого разрешения в данной директории нет.");
                            break;
                        }
                        foreach (string filename in allfilesD)
                        {
                            Console.WriteLine(filename);
                        }
                        while (flag2)
                        {
                            Console.WriteLine("Введите имя файла:");
                            FileName = @"D:\" + Console.ReadLine();                            
                            if (File.Exists(FileName))
                            {
                                flag2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Данного файла не существует, проверьте имя файла.");
                            }                            
                        }
                        Console.WriteLine("Информация о файле: ");

                        using (var breader = new BinaryReader(File.OpenRead(FileName)))
                        {
                            //Console.WriteLine("Размер файла: " + new FileInfo(FileName).Length);
                            breader.BaseStream.Position = 2;
                            Console.WriteLine($"Размер файла: {breader.ReadInt32()} байт");
                            breader.BaseStream.Position = 18;
                            Console.WriteLine($"Ширина: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 22;
                            Console.WriteLine($"Высота: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 28;
                            Console.WriteLine($"Количество бит на пиксель: {breader.ReadInt16()}");
                            breader.BaseStream.Position = 38;
                            Console.WriteLine($"Горизонтальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 42;
                            Console.WriteLine($"Вертикальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 30;
                            Console.WriteLine($"Тип сжатия: {breader.ReadInt32()}");
                        }
                        flag = false;
                        break;
                    case "C":
                        FileName = string.Empty;
                        string[] allfilesC = Directory.GetFiles(@"C:\ ", "*.bmp");
                        if (allfilesC.Length == 0)
                        {
                            Console.WriteLine("файлов такого разрешения в данной директории нет.");
                            break;
                        }
                        foreach (string filename in allfilesC)
                        {
                            Console.WriteLine(filename);
                        }
                        while (flag2)
                        {
                            Console.WriteLine("Введите имя файла:");
                            FileName = @"D:\" + Console.ReadLine();
                            if (File.Exists(FileName))
                            {
                                flag2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Данного файла не существует, проверьте имя файла.");
                            }
                        }
                        using (var breader = new BinaryReader(File.OpenRead(FileName)))
                        {
                            //Console.WriteLine("Размер файла: " + new FileInfo(FileName).Length);
                            breader.BaseStream.Position = 2;
                            Console.WriteLine($"Размер файла: {breader.ReadInt32()} байт");
                            breader.BaseStream.Position = 18;
                            Console.WriteLine($"Ширина: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 22;
                            Console.WriteLine($"Высота: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 28;
                            Console.WriteLine($"Количество бит на пиксель: {breader.ReadInt16()}");
                            breader.BaseStream.Position = 38;
                            Console.WriteLine($"Горизонтальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 42;
                            Console.WriteLine($"Вертикальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 30;
                            Console.WriteLine($"Тип сжатия: {breader.ReadInt32()}");
                        }
                        flag = false;
                        break;
                    case "+":
                        FileName = string.Empty;
                        string[] allfilesDir = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp");
                        if (allfilesDir.Length == 0) 
                        { 
                            Console.WriteLine("файлов такого разрешения в данной директории нет.");
                            break;
                        }
                        foreach (string filename in allfilesDir)
                        {
                            Console.WriteLine(filename);
                        }
                        while (flag2)
                        {
                            Console.WriteLine("Введите имя файла:");
                            FileName = @"D:\" + Console.ReadLine();
                            if (File.Exists(FileName))
                            {
                                flag2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Данного файла не существует, проверьте имя файла.");
                            }
                        }
                        Console.WriteLine("Информация о файле: ");

                        using (var breader = new BinaryReader(File.OpenRead(FileName)))
                        {
                            //Console.WriteLine("Размер файла: " + new FileInfo(FileName).Length);
                            breader.BaseStream.Position = 2;
                            Console.WriteLine($"Размер файла: {breader.ReadInt32()} байт");
                            breader.BaseStream.Position = 18;
                            Console.WriteLine($"Ширина: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 22;
                            Console.WriteLine($"Высота: {breader.ReadInt32()} пикселей");
                            breader.BaseStream.Position = 28;
                            Console.WriteLine($"Количество бит на пиксель: {breader.ReadInt16()}");
                            breader.BaseStream.Position = 38;
                            Console.WriteLine($"Горизонтальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 42;
                            Console.WriteLine($"Вертикальное разрешение, пиксел/м: {breader.ReadInt32()}");
                            breader.BaseStream.Position = 30;
                            Console.WriteLine($"Тип сжатия: {breader.ReadInt32()}");
                        }
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введено неверное значение, введите еще раз");
                        break;
                }
            }

        }
    }
}
