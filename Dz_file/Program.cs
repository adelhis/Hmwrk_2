using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Domashka
{
    class Program
    {
        public static void Main()
        {
            /*#1. Выведите на экран информацию о каждом типе данных в виде:
            Тип данных – максимальное значение – минимальное значение*/
            Console.WriteLine("Задание 1. Вывод на экран максимального и минимального значения численныъ типов данных");
            Console.WriteLine($"\t Целочисленные типы \n" +
                $"{"Наименование типа",-30}{"Мин.знач",-30}{"Макс.знач."}\n" +
                $"{"byte",-30}{"0",-30}{"255"}\n" +
                $"{"sbyte",-30}{"-128",-30}{"127"}\n" +
                $"{"short",-30}{"-32 768",-30}{"32 767"}\n" +
                $"{"ushort",-30}{"0",-30}{"65535"}\n" +
                $"{"int",-30}{"-2 147 483 648",-30}{"2 147 483 647"}\n" +
                $"{"uint",-30}{"0",-30}{"4 294 967 295"}\n" +
                $"{"long",-30}{"-9 223 372 036 854 775 808",-30}{"9 223 372 036 854 775 807"}\n" +
                $"{"ulong",-30}{"0",-30}{"18 446 744 073 709 551 615"}\n" +
                $"{"float",-30}{"-3.402823e38",-30}{"3.402823e38"}\n" +
                $"{"double",-30}{"-1.797693e308",-30}{"1.797693e308"}\n" +
                $"{"decimal",-30}{"-7.922816e28",-30}{"7.922816e28"}\n");

            /*#2. Напишите программу, в которой принимаются данные пользователя в виде имени,
            города, возраста и PIN-кода. Далее сохраните все значение в соответствующей
            переменной, а затем распечатайте всю информацию в правильном формате.*/
            Console.WriteLine("Задание 2. сбор данных пользователя и их вывод");
            Console.Write("Введите имя:");
            string name = Console.ReadLine();
            Console.Write("Введите город проживания:");
            string city = Console.ReadLine();
            Console.Write("Введите возраст:");
            int age = 0;
            bool isage = int.TryParse(Console.ReadLine(), out age);
            Console.Write("Введите PIN-код:");
            int pin = 0;
            bool ispin = int.TryParse(Console.ReadLine(), out pin);
            (string, string, int, int) tuple = ("", "", 0, 0);
            if (ispin && isage && Regex.IsMatch(name, @"^[a-zA-Z]+$") && Regex.IsMatch(city, @"^[a-zA-Z]+$"))
            {
                tuple.Item1 = name;
                tuple.Item2 = city;
                tuple.Item3 = age;
                tuple.Item4 = pin;
                Console.WriteLine($"Имя:{tuple.Item1}\nГород:{tuple.Item2}\nВозраст:{tuple.Item3}\nPIN-код:{tuple.Item4}");
            }
            else
            {
                Console.WriteLine("Вы ввели некоректные данные");
            }
            Console.WriteLine();

            /*#3. Преобразуйте входную строку: строчные буквы замените на заглавные, заглавные – настрочные.*/
            Console.WriteLine("Задание 3. Поменять регистр букв в строке пользователя");

            //Console.WriteLine(Regex.IsMatch(a, @"^[a-zA-Z]+$"));
            Console.Write("Введите строку из букв:");
            string str = Console.ReadLine();
            string otvet = "";
            if (Regex.IsMatch(str, @"^[a-zA-Zа-яА-Я]+$"))
            {
                int size = str.Length;
                for (int i = 0; i < size; i++)
                {
                    if (str[i] == char.ToLower(str[i]))
                    {
                        otvet += char.ToUpper(str[i]);
                    }
                    else
                    {
                        otvet += char.ToLower(str[i]);
                    }
                   
                }
                Console.WriteLine(otvet);
            }
            else
            {
                Console.WriteLine("В вашей строке есть не только буквы");
            }
            Console.WriteLine("\n");

            /*#4. Введите строку, введите подстроку. Необходимо найти количество вхождений и вывестина экран.*/
            Console.WriteLine("Задание 4. Нахождение количества вхождений подстроки в строке");
            Console.Write("Введите строку:");
            string s1 = Console.ReadLine();
            Console.Write("Введите подстроку:");
            string s2 = Console.ReadLine();
            int index, length;
            int otvet1 = 0;
            if (s1.Length > 0 && s2.Length > 0)
            {
                if (s1.Contains(s2))
                {
                    do
                    {
                        length = s2.Length;
                        index = s1.IndexOf(s2);
                        s1 = s1.Remove(index, length);
                        otvet1 += 1;
                    } while (s1.Contains(s2));
                    Console.WriteLine($"Количество вхождений = {otvet1}\n");
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else
            {
                Console.WriteLine("Вы ввели пустую строку\n");
            }
                

            /*#5. Цель этой задачи - определить, сколько бутылок виски беспошлинной торговли вам
            нужно будет купить, чтобы экономия по сравнению с обычной средней ценой фактически
            покрыла расходы на ваш отпуск. Вам будет предоставлена стандартная цена (normPrice),
            скидка в Duty Free (salePrice) и стоимость отпуска (holidayPrice). Например, если бутылка
            обычно стоит 10 фунтов стерлингов, а скидка в дьюти фри составляет 10%, вы
            сэкономите 1 фунт стерлингов на каждой бутылке. Если ваш отпуск стоит 500 фунтов
            стерлингов, ответ, который вы должны вернуть, будет 500. Все входные данные будут
            целыми числами. Пожалуйста, верните целое число. Округлить в меньшую сторону.*/
            Console.WriteLine("Задание 5. Фиксируем прибыль от алкоголя");
            int normPrice, salePrice, holidayPrice;
            Console.Write("Введите стандартную цену:");
            bool isnum1 = int.TryParse(Console.ReadLine(), out normPrice);
            Console.Write("Введите скидку(в %):");
            bool isnum2 = int.TryParse(Console.ReadLine(), out salePrice);
            Console.Write("Введите стоимость отпуска:");
            bool isnum3 = int.TryParse(Console.ReadLine(), out holidayPrice);
            if (isnum1 && isnum2 && isnum3)
            {
                if (normPrice <= 0)
                {
                    Console.WriteLine("Такой цены на алкоголь не бывает)\n");
                }
                else if (salePrice <= 0)
                {
                    Console.WriteLine("С такой скидкой и на дачу не съездишь)\n");
                }
                else if (salePrice >= 100)
                {
                    Console.WriteLine("Не бывает таких скидок, не придумывай\n");
                }
                else if (holidayPrice <= 0)
                {
                    Console.WriteLine("Билеты от авиасейлс?\n");
                }
                else
                {
                    Console.WriteLine($"Вам понадобиться купить {holidayPrice/(normPrice*salePrice/100)} бутылок\n");
                }

            }
            else
            {
                Console.WriteLine("Вы ввели некорректные данные\n");
            }
            Console.ReadKey();
            /*6. Создать структуру студента. У студента есть Фамилия, Имя, его Идентификатор, Дата
            рождения, Категория алкоголизма (a – студент алкоголик, b – студент любитель
            выпить, но не алкоголик, c – студент пьет по праздникам, d – студент не пьет), также у
            студента есть Объем выпитой жидкости конкретного напитка. Создать 5 студентов с
            различными параметрами. Посчитать общий объем выпитого, общий объем алкоголя
            (процент спирта) и кто сколько процентов алкоголя и жидкости от общего количества
            выпил. Предполагается, что студент пьет один вид напитка. Напитки задать в виде
            структуры: наименование типа напитка и процент спирта.*/
            Console.WriteLine("Задание 6. Пьющие студенты. Необходимо вычислить общий объем выпитового и кто сколько выпил процентов от общего");
            Drinks drink1 = new Drinks();
            drink1.nazv_alk = "Сидр";
            drink1.procent_alk = 5;

            Drinks drink2 = new Drinks();
            drink2.nazv_alk = "Пиво";
            drink2.procent_alk = 7;

            Drinks drink3 = new Drinks();
            drink3.nazv_alk = "Винишко";
            drink3.procent_alk = 15;

            Drinks drink4 = new Drinks();
            drink4.nazv_alk = "Водка";
            drink4.procent_alk = 40;

            Drinks drink5 = new Drinks();
            drink5.nazv_alk = "Текила";
            drink5.procent_alk = 60;

            Student student1 = new Student();
            student1.surname = "Иванов";
            student1.name = "Иван";
            student1.iden = "100012";
            student1.datarozh = "12.12.1999";
            student1.kat_alk = "c";
            student1.obyem = 12;
            student1.chtopil = drink2;

            Student student2 = new Student();
            student2.surname = "Сидоров";
            student2.name = "Леонид";
            student2.iden = "100013";
            student2.datarozh = "15.10.1999";
            student2.kat_alk = "c";
            student2.obyem = 10;
            student2.chtopil = drink1;

            Student student3 = new Student();
            student3.surname = "Винишкотянова";
            student3.name = "Галя";
            student3.iden = "100024";
            student3.datarozh = "25.4.1997";
            student3.kat_alk = "b";
            student3.obyem = 20;
            student3.chtopil = drink3;

            Student student4 = new Student();
            student4.surname = "Аляулю";
            student4.name = "Зиноида";
            student4.iden = "100025";
            student4.datarozh = "20.6.1997";
            student4.kat_alk = "a";
            student4.obyem = 24;
            student4.chtopil = drink4;

            Student student5 = new Student();
            student5.surname = "Семонов";
            student5.name = "Станислав";
            student5.iden = "1";
            student5.datarozh = "вчера";
            student5.kat_alk = "SSS";
            student5.obyem = 30;
            student5.chtopil = drink5;

            float obsh_obyem = student1.obyem + student2.obyem + student3.obyem + student4.obyem + student5.obyem;
            student1.obsh_obyem_jid = obsh_obyem;
            student2.obsh_obyem_jid = obsh_obyem;
            student3.obsh_obyem_jid = obsh_obyem;
            student4.obsh_obyem_jid = obsh_obyem;
            student5.obsh_obyem_jid = obsh_obyem;
            float obsh_obyem2 = student1.obyem * student1.chtopil.procent_alk /100 + student2.obyem * student2.chtopil.procent_alk / 100 + student3.obyem * student3.chtopil.procent_alk / 100
                + student4.obyem * student4.chtopil.procent_alk / 100 + student5.obyem * student5.chtopil.procent_alk / 100;
            student1.obsh_obyem_alc = obsh_obyem2;
            student2.obsh_obyem_alc = obsh_obyem2;
            student3.obsh_obyem_alc = obsh_obyem2;
            student4.obsh_obyem_alc = obsh_obyem2;
            student5.obsh_obyem_alc = obsh_obyem2;
            Console.WriteLine($"Общий объем выпитой жидкости = {obsh_obyem}\nОбщий объем выпитого алкоголя = {obsh_obyem2}\n");
            student1.Print_std();
            student2.Print_std();
            student3.Print_std();
            student4.Print_std();
            student5.Print_std();
            Console.ReadKey();
        }
        struct Drinks
        {
            public string nazv_alk;
            public int procent_alk;
        }
        struct Student
        {
            public string surname;
            public string name;
            public string iden;
            public string datarozh;
            public string kat_alk;
            public float obyem;
            public Drinks chtopil;
            public float obsh_obyem_jid;
            public float obsh_obyem_alc;
            public void Print_std()
                
            {
                Console.WriteLine($"Студент {surname} {name}\n" +
                    $"Идентификатор: {iden}\n" +
                    $"Дата рождения: {datarozh}\n" +
                    $"Категория алкоголизма: {kat_alk}\n" +
                    $"Выпито жидкости: {obyem}\n" +
                    $"Выпитый напиток: {chtopil.nazv_alk}\n" +
                    $"Процент выпитой жидкости от общего значения: {obyem / obsh_obyem_jid * 100}\n" +
                    $"Процент выпитого алкоголя от общего значения: {obyem*chtopil.procent_alk/100 / obsh_obyem_alc * 100}\n");
            }
        }
    }

}
    