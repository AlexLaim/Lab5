﻿using System;
using System.Collections;

namespace lab5
{
    public enum types
    {
        Т,
        С
    }


    public struct Item
    {
        public String Name;
        public String Type;
        public int Age;
        public int Exp;

        public Item(string Name, String Types, int Age, int Exp)
        {
            this.Name = Name;
            this.Type = Types;
            this.Age = Age;
            this.Exp = Exp;

        }

        public void Print()
        {
            Console.WriteLine($"|{this.Name,-24}|{this.Type,-12}|{this.Age,-20}|{this.Exp,-15}|");
        }
    }

    class program
    {
        private static void Main()
        {
            ArrayList list = new();


            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Меню:");
                //ControlLogs(50);
                Console.WriteLine("1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход");
                Console.WriteLine("Выберите действие:");
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        Console.WriteLine(new String('-', 76));
                        Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                        Console.WriteLine(new String('-', 76));
                        Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                        Console.WriteLine(new String('-', 76));
                        foreach (Item item in list)
                        {
                            item.Print();
                            Console.WriteLine(new String('-', 76));
                        }
                        Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                        Console.WriteLine(new String('-', 76));
                        break;
                    case "2":
                        Console.WriteLine("Введите данные:");

                        Console.WriteLine("ФИО:");
                        string Name = Console.ReadLine();

                        Console.WriteLine("Тип деятельности: Т-тренер, С-спортсмен");
                        string Types = Console.ReadLine();

                        Console.WriteLine("Введите год рождения:");
                        int Age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите опыт работы(лет):");
                        int Exp = int.Parse(Console.ReadLine());
                        Item value = new(Name, Types, Age, Exp);
                        list.Add(value);
                        break;
                    case "3":
                        Console.WriteLine("Введите номер записи которую хотите удалить:");
                        Console.WriteLine("Кол-во записей: " + list.Count);
                        int num = int.Parse(Console.ReadLine());
                        while (num > list.Count)
                        {
                            Console.WriteLine("Введено неверное значение");
                            Console.WriteLine("Введите номер записи которую хотите удалить:");
                            Console.WriteLine("Кол-во записей: " + list.Count);
                            num = int.Parse(Console.ReadLine());
                        }
                        list.RemoveAt(num - 1);
                        break;
                    case "4":
                        Console.WriteLine("Введите номер записи которую хотите обновить:");
                        Console.WriteLine("Кол-во записей: " + list.Count);
                        int num2 = int.Parse(Console.ReadLine());
                        while (num2 > list.Count)
                        {
                            Console.WriteLine("Введено неверное значение");
                            Console.WriteLine("Введите номер записи которую хотите обновить:");
                            Console.WriteLine("Кол-во записей: " + list.Count);
                            num2 = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Введите данные:");

                        Console.WriteLine("ФИО:");
                        string Name2 = Console.ReadLine();

                        Console.WriteLine("Тип деятельности: Т-тренер, С-спортсмен");
                        string Types2 = Console.ReadLine();

                        Console.WriteLine("Введите год рождения:");
                        int Age2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите опыт работы(лет):");
                        int Exp2 = int.Parse(Console.ReadLine());
                        list[num2 - 1] = new Item(Name2, Types2, Age2, Exp2);

                        break;
                    case "5":
                        Console.WriteLine("Введите тип поиска: ");
                        Console.WriteLine("1 - поиск по ФИО, \n2 - поиск по году рождения \n3 - по типу деятельности (Т-тренер, С-спортсмен)");
                        string act = string.Empty;
                        ArrayList list2 = new();
                        switch (Console.ReadLine().Trim())
                        {
                            case "1":
                                Console.WriteLine("Введите ФИО: ");
                                act = Console.ReadLine();
                                foreach (Item item in list)
                                {
                                    if (item.Name.Equals(act))
                                        list2.Add(item);
                                }
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                Console.WriteLine(new String('-', 76));
                                foreach (Item item in list2)
                                {
                                    item.Print();
                                    Console.WriteLine(new String('-', 76));
                                }
                                Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                Console.WriteLine(new String('-', 76));
                                break;
                            case "2":
                                Console.WriteLine("Введите год рождения");
                                int act2 = int.Parse(Console.ReadLine());
                                foreach (Item item in list)
                                {
                                    if (item.Age.Equals(act2))
                                        list2.Add(item);
                                }
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                Console.WriteLine(new String('-', 76));
                                foreach (Item item in list2)
                                {
                                    item.Print();
                                    Console.WriteLine(new String('-', 76));
                                }
                                Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                Console.WriteLine(new String('-', 76));
                                break;
                            case "3":
                                Console.WriteLine("Введите тип деятельности");
                                act = Console.ReadLine();
                                foreach (Item item in list)
                                {
                                    if (item.Type.Equals(act))
                                        list2.Add(item);
                                }
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                Console.WriteLine(new String('-', 76));
                                foreach (Item item in list2)
                                {
                                    item.Print();
                                    Console.WriteLine(new String('-', 76));
                                }
                                Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                Console.WriteLine(new String('-', 76));
                                break;
                        }
                        break;
                    case "6":
                        //logs
                        break;
                    case "7":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестное действие.");
                        break;
                }
            }
        }
    }
}