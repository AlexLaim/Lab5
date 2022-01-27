using System;
using System.Collections.Generic;

namespace lab5
{
    public enum types
    {
        Т,
        С
    }

    public enum actions
    {
        add,
        del,
        upd
    }

    public struct Item
    {
        public String Name;
        public types Type;
        public int Age;
        public int Exp;

        public Item(string Name, types Types, int Age, int Exp)
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
    public struct Action
    {
        public actions Act;
        public string Name;
        public DateTime Time;

        public Action(actions act, string name, DateTime time)
        {
            this.Act = act;
            this.Name = name;
            this.Time = time;
        }

        public void Print()
        {
            //Console.WriteLine($"|{this.Act,-24}|{this.Name,-12}|{this.Time,-20}|");
            if (Act == actions.add)
            {
                Console.WriteLine($"{this.Time} - Добавлена запись '{this.Name}' ");
            }else if (Act == actions.del)
            {
                Console.WriteLine($"{this.Time} - Удалена запись '{this.Name}' ");
            }else if (Act == actions.upd)
            {
                Console.WriteLine($"{this.Time} - Обновлена запись '{this.Name}' ");
            }
        }
    }

    class program
    {
        private static void Main()
        {
            List<Item> list = new List<Item>();
            List<Action> list3 = new List<Action>();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Меню:");                
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

                        Console.WriteLine("Тип деятельности: Т-тренер - 0, С-спортсмен - 1");
                        types Types = (types)int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите год рождения:");
                        int Age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите опыт работы(лет):");
                        int Exp = int.Parse(Console.ReadLine());
                        Item value = new(Name, Types, Age, Exp);
                        list.Add(value);
                        DateTime time = DateTime.Now;
                        string name = Name;
                        actions act = actions.add;
                        Action val = new(act, name, time);
                        list3.Add(val);
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
                        time = DateTime.Now;
                        name = list[num - 1].Name;
                        act = actions.del;
                        val = new(act, name, time);
                        list3.Add(val);
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
                        time = DateTime.Now;
                        name = list[num2 - 1].Name;
                        act = actions.upd;
                        val = new(act, name, time);
                        list3.Add(val);
                        Console.WriteLine("Введите данные:");

                        Console.WriteLine("ФИО:");
                        string Name2 = Console.ReadLine();

                        Console.WriteLine("Тип деятельности: Т-тренер - 0, С-спортсмен - 1");
                        types Types2 = (types)int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите год рождения:");
                        int Age2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите опыт работы(лет):");
                        int Exp2 = int.Parse(Console.ReadLine());
                        list[num2 - 1] = new Item(Name2, Types2, Age2, Exp2);

                        break;
                    case "5":
                        Console.WriteLine("Введите тип поиска: ");
                        Console.WriteLine("1 - поиск по ФИО, \n2 - поиск по году рождения \n3 - по типу деятельности (Т-тренер, С-спортсмен)");
                        string var = string.Empty;
                        List<Item> list2 = new List<Item>();
                        switch (Console.ReadLine().Trim())
                        {
                            case "1":
                                Console.WriteLine("Введите ФИО: ");
                                var = Console.ReadLine();
                                foreach (Item item in list)
                                {
                                    if (item.Name.Equals(var))
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
                                int var2 = int.Parse(Console.ReadLine());
                                foreach (Item item in list)
                                {
                                    if (item.Age.Equals(var2))
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
                                Console.WriteLine("Введите тип деятельности: Т- тренер - 0, С - спортсмен - 1");
                                types var3 = (types)int.Parse(Console.ReadLine());
                                foreach (Item item in list)
                                {
                                    if (item.Type.Equals(var3))
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
                        foreach (Action logs in list3)
                        {
                            logs.Print();                            
                        }
                        TimeSpan varr = list3[1].Time - list3[0].Time;
                       for (int i = 2; i< list3.Count; i++)
                        {
                            TimeSpan varr2 = list3[i].Time - list3[i - 1].Time;
                            if(varr2 > varr)
                            {
                                varr = varr2;
                            }
                        }
                        Console.WriteLine($"Наибольшее время простоя: {varr}");                        
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