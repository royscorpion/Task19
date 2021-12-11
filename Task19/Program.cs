using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    class PC
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CPU_Type { get; set; }
        public int CPU_Frequency { get; set; }
        public int RAM_Size { get; set; }
        public int HDD_Volume { get; set; }
        public int GC_Memory { get; set; }
        public int InStock { get; set; }
        public int ProductCost { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<PC> listPC = new List<PC>()
            {
                new PC() { ProductCode = 4854564, ProductName = "DEXP Mars E332", ProductCost = 72999, CPU_Type = "Intel Core i5-10400F", CPU_Frequency = 4300, RAM_Size = 8, HDD_Volume = 512, GC_Memory = 4, InStock = 2 },
                new PC() { ProductCode = 4880600, ProductName = "ZET Gaming NEO M001", ProductCost = 74999, CPU_Type = "Intel Core i5-10400F", CPU_Frequency = 4300, RAM_Size = 16, HDD_Volume = 500, GC_Memory = 4, InStock = 6, },
                new PC() { ProductCode = 4815809, ProductName = "HP Pavilion Gaming TG01-2060ur", ProductCost = 77999, CPU_Type = "AMD Ryzen 5 5600G", CPU_Frequency = 4400, RAM_Size = 16, HDD_Volume = 512, GC_Memory = 4, InStock = 8, },
                new PC() { ProductCode = 4735380, ProductName = "Lenovo IdeaCentre Gaming G5 14IMB05", ProductCost = 99999, CPU_Type = "Intel Core i5-10400", CPU_Frequency = 4300, RAM_Size = 16, HDD_Volume = 512, GC_Memory = 6, InStock = 1, },
                new PC() { ProductCode = 4880808, ProductName = "ZET Gaming WARD H143", ProductCost = 99999, CPU_Type = "Intel Core i5-10400F", CPU_Frequency = 4300, RAM_Size = 16, HDD_Volume = 512, GC_Memory = 6, InStock = 8, },
                new PC() { ProductCode = 4815452, ProductName = "MSI MAG Codex 5 11SC-670XRU", ProductCost = 107999, CPU_Type = "Intel Core i5-11400F", CPU_Frequency = 4400, RAM_Size = 16, HDD_Volume = 512, GC_Memory = 6, InStock = 1, },
                new PC() { ProductCode = 4887029, ProductName = "ZET Gaming WARD H151", ProductCost = 124999, CPU_Type = "Intel Core i5-10400F", CPU_Frequency = 4300, RAM_Size = 16, HDD_Volume = 512, GC_Memory = 12, InStock = 32, },
                new PC() { ProductCode = 1425902, ProductName = "Dell Precision 3240", ProductCost = 113220, CPU_Type = "Intel Core i7-10700", CPU_Frequency = 2900, RAM_Size = 16, HDD_Volume = 256, GC_Memory = 4, InStock = 2, },
                new PC() { ProductCode = 4829350, ProductName = "ZET Gaming WARD H091", ProductCost = 179999, CPU_Type = "Intel Core i7-11700", CPU_Frequency = 4900, RAM_Size = 32, HDD_Volume = 1000, GC_Memory = 8, InStock = 1, },
                new PC() { ProductCode = 0079773, ProductName = "Zotac ZBOX-QK7P5000-BE SFF", ProductCost = 292960, CPU_Type = "Intel Core i7-7700T", CPU_Frequency = 3800, RAM_Size = 32, HDD_Volume = 512, GC_Memory = 16, InStock = 2, }
            };


            Console.WriteLine("Подбор конфигурации компьютера");
            do
            {
                switch (PC_Select())
                {
                    case 1: //все компьютеры с указанным процессором. Название процессора запросить у пользователя
                        {
                            Console.WriteLine("Поиск по типу процессора");
                            Console.Write("Укажите тип процессора: ");
                            string search = Console.ReadLine();
                            var pCs = listPC
                                .Where(cp => cp.CPU_Type.Contains(search))
                                .ToList();
                            if (pCs.Count > 0)
                                foreach (PC i in pCs)
                                {
                                    PC_print(i);
                                }
                            else
                                Console.WriteLine("\nКонфигурации с процессором {0} не найдены", search);
                            break;
                        }
                    case 2: // все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя
                        {
                            Console.WriteLine("\nПоиск по объему ОЗУ");
                            Console.Write("Укажите минимальный объем ОЗУ: ");
                            InputIntNumber(out int search);
                            var pCs = listPC
                                .Where(rams => rams.RAM_Size>=search)
                                .ToList();
                            if (pCs.Count > 0)
                                foreach (PC i in pCs)
                                {
                                    PC_print(i);
                                }
                            else
                                Console.WriteLine("\nКонфигурации с объемом ОЗУ на менее {0} не найдены.",search);
                            break;
                        }
                    case 3: // вывести весь список, отсортированный по увеличению стоимости
                        {
                            Console.WriteLine("\nВсе компьютеры в порядке увеличения стоимости:\n");
                            var pCs = listPC
                                .OrderBy(pc => pc.ProductCost)
                                .ToList();
                            foreach (PC i in pCs)
                            {
                                PC_print(i);
                            }
                            break;
                        }
                    case 4: // вывести весь список, сгруппированный по типу процессора
                        {
                            Console.WriteLine("\nВсе компьютеры с группировкой по типу процессора:\n");
                            var pcTypes = listPC
                                .GroupBy(pc => pc.CPU_Type);
                            foreach (IGrouping<string, PC> i in pcTypes)
                            {
                                Console.WriteLine(i.Key);
                                foreach (var j in i)
                                    PC_print(j);
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 5: // найти самый дорогой и самый бюджетный компьютер
                        {
                            Console.WriteLine("Cамый дорогой и самый бюджетный компьютер");
                            int maxCost = listPC
                                .Max(pc => pc.ProductCost);
                            IEnumerable<PC> maxPC = listPC
                                .Where(pc => pc.ProductCost == maxCost)
                                .ToList();
                            Console.Write("Cамый дорогой компьютер: ");
                            foreach (PC i in maxPC)
                            {
                                PC_print(i);
                            }
                            int minCost = listPC
                                .Min(pc => pc.ProductCost);
                            IEnumerable<PC> minPC = listPC
                                .Where(pc => pc.ProductCost == minCost)
                                .ToList();
                            Console.Write("Cамый бюджетный компьютер: ");
                            foreach (PC i in minPC)
                            {
                                PC_print(i);
                            }
                            break;
                        }
                    case 6: // есть ли хотя бы один компьютер в количестве не менее 30 штук?
                        {
                            Console.WriteLine("Модели в количестве не менее 30 шт.");
                            bool pcInStock = listPC
                                .Any(pc => pc.InStock>=30);
                            if (pcInStock)
                            {
                                var pCs = listPC
                                    .Where(pc => pc.InStock >= 30)
                                    .ToList();
                                Console.WriteLine("Найдено {0} модель(и/ей) компьютеров в количестве не менее 30 шт.:",pCs.Count);
                                foreach (PC i in pCs)
                                {
                                    PC_print(i);
                                }
                            }
                            else
                                Console.WriteLine("Модели компьютеров в количестве не менее 30 шт. не найдены");
                            break;
                        }
                    default:
                        Console.WriteLine("Вариант с таким номером отсутствует");
                        break;
                }
            } while (PC_OneMore());
        }

        //Вывод конфигурации компьюетра
        public static void PC_print(PC pC)
        {
            Console.WriteLine("({0})|{1}|CPU {3}, {4} Гц|RAM {5} Гб|HDD {6} Гб|GraphicCard {7} Гб|Цена: {2} у.е. - в наличии {8} шт.", pC.ProductCode, pC.ProductName, pC.ProductCost, pC.CPU_Type, pC.CPU_Frequency, pC.RAM_Size, pC.HDD_Volume, pC.GC_Memory, pC.InStock);
        }
        //Выбор варианта поиска
        public static int PC_Select()
        {
            Console.WriteLine("Выбор типа поиска:\n1 - Поиск по типу процессора\n2 - Поиск по объему ОЗУ\n3 - Все в порядке увеличения стоимости");
            Console.WriteLine("4 - Все с группировкой по типу процессора\n5 - Cамый дорогой и самый бюджетный компьютер\n6 - Компьютеры в наличии, в количестве не менее 30 шт.");
            Console.Write("Укажите тип поискового запроса:");
            InputIntNumber(out int number);
            return number;
        }
        //Запрос на повторный вывод
        public static bool PC_OneMore()
        {
            Console.Write("Хотите попробовать еще раз?(Да/Нет) ");
            string answer = Console.ReadLine();
            if (answer.Contains("д") || answer.Contains("Д") || answer.Contains("y") || answer.Contains("Y")) return true; else return false;
        }
        //Проверка корректности введенных данных (integer)
        static void InputIntNumber(out int number)
        {
            number = 0;
            bool x;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите целое число: ");
                    x = true;
                }
            } while (x);
        }
        
    }
}
