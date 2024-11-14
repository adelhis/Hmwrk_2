using System;

namespace Dzshka
{
    class Tumakov
    {
        //энамы тут
        enum Bank
        {
            Сберегательный,
            Текущий
        }
        enum VUZ
        {
            КГУ,
            КАИ,
            КХТИ
        }
        public static void Main()
        {
            /*Упражнение 3.1 Создать перечислимый тип данных отображающий виды банковского
            cчета (текущий и сберегательный). Создать переменную типа перечисления, присвоить ей
            значение и вывести это значение на печать.*/
            Console.WriteLine("\tУпражнение 3.1. Вывод на экран значения созданной переменной типа перечисление\n");
            Bank bank1 = Bank.Текущий;
            Console.WriteLine($"{bank1}\n");


            /*Упражнение 3.2 Создать структуру данных, которая хранит информацию о банковском
            счете – его номер, тип и баланс. Создать переменную такого типа, заполнить структуру
            значениями и напечатать результат.*/
            Console.WriteLine("\tУпражнение 3.2. Вывод в консоль значений созданной переменной нового типа\n");
            Shet shet1 = new Shet();
            shet1.nomer_sheta = "2200 4421 5543 6431";
            shet1.tip_sheta = Bank.Сберегательный;
            shet1.balans_sheta = 12456.11;
            shet1.Print_shetinf();
            

            /*Домашнее задание 3.1 Создать перечислимый тип ВУЗ{КГУ, КАИ, КХТИ}. Создать
            структуру работник с двумя полями: имя, ВУЗ. Заполнить структуру данными и
            распечатать.*/
            Console.WriteLine("\tДомашнее задание 3.1. Вывод в консоль информации о работнике,создание структуры с двумя полями\n");
            Worker worker1 = new Worker();
            worker1.name = "Ибрагим";
            worker1.vuz = VUZ.КХТИ;
            worker1.Print_work();
        }
        //структуры тут
        struct Shet
        {
            public string nomer_sheta;
            public Bank tip_sheta;
            public double balans_sheta;
            public void Print_shetinf()
            {
                Console.WriteLine($"Номер счета: {nomer_sheta}\nТип: {tip_sheta}\nБаланс: {balans_sheta}\n");
            }
        }
        struct Worker
        {
            public string name;
            public VUZ vuz;
            public void Print_work()
            {
                Console.WriteLine($"Меня зовут {name}, я работаю в {vuz}");
            }

        }

    }
}