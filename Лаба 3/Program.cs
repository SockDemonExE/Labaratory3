using System;
using System.Diagnostics;
using System.Reflection;

namespace Lab3
{
    class Program
    {
        //Переменные
        public static readonly Random random = new Random();
        public static readonly double PI = Math.PI;
        public static Stopwatch timer = new Stopwatch();


        //Методы массивов
        public static void RandomArray(int[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-100, 100);
            }
        }

        public static int[] ArrayCreater(int size)
        {
            int[] array = new int[size];

            RandomArray(array, size);

            return array;
        }

        public static int[] ArrayCopier(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();

            return arrayCopy;
        }

        public static void WriteArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }


        //Сортировки
        public static double BubbleSort(int[] array)
        {
            timer.Restart();

            int tempVar;

            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tempVar = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempVar;
                    }
                }
            }

            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        public static double SelectionSort(int[] array)
        {
            timer.Restart();

            int tempVar;
            int minIndex;

            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }

                tempVar = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tempVar;
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        public static double InsertionSort(int[] array)
        {
            timer.Restart();

            int tempVar;
            int j;
            
            for (int i = 1; i < array.Length; i++)
            {
                tempVar = array[i];
                j = i - 1;

                while (j >= 0 && array[j] > tempVar)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = tempVar;
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        public static double ShellSort(int[] array)
        {
            timer.Restart();
            
            int tempVar;
            bool forExit = true;
            
            for (int i = array.Length / 2; i >= 1; i /= 2)
            {
                for (int j = i; j < array.Length; j++)
                {
                    forExit = true;
                    for (int k = j; k >= i && forExit; k--)
                    {
                        if (array[k] < array[k - i])
                        {
                            tempVar = array[k];
                            array[k] = array[k - i];
                            array[k - i] = tempVar;
                        }
                        else
                        {
                            forExit = false;
                        }
                    }
                }
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        public static double ShakerSort(int[] array)
        {
            timer.Restart();

            int tempVar, begin = 0, end = array.Length;
            
            while (end - begin > 0)
            {
                for (int i = end - 1; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            tempVar = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tempVar;
                        }
                    }
                }
                end -= 1;
                for (int i = begin; i < end; i++)
                {
                    for (int j = end - 1; j > i; j--)
                    {
                        if (array[j] > array[j + 1])
                        {
                            tempVar = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tempVar;
                        }
                    }
                }
                begin += 1;
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }

        public static double GnomeSort(int[] array)
        {
            timer.Restart();

            int tempVar;
            
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        tempVar = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tempVar;
                    }
                }
            }
            timer.Stop();

            return timer.Elapsed.TotalMilliseconds;
        }


        //Методы работы с переменными
        public static int IntParse()
        {
            int num = 0;
            bool isntParse = true;

            while (isntParse)
            {
                isntParse = !int.TryParse(Console.ReadLine(), out num);

                if (isntParse)
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
                else
                {
                    isntParse = false;
                }
            }
            
            return num;
        }

        public static int MenuChoose(int min, int max)
        {
            int item;
            bool cicle;

            Console.Write($"Выберите пункт меню: ");

            do
            {
                cicle = !int.TryParse(Console.ReadLine(), out item);

                if (cicle)
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
                else if (min > item || max < item)
                {
                    Console.Write("Ошибка: такого пункта нет. Повторите ввод: ");
                    cicle = true;
                }
            }
            while (cicle);

            return item;
        }

        public static int SortingChoose(int min, int max)
        {
            int item;
            bool cicle;

            Console.Write($"Выберите сортировку: ");

            do
            {
                cicle = !int.TryParse(Console.ReadLine(), out item);

                if (cicle)
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
                else if (min > item || max < item)
                {
                    Console.Write("Ошибка: такого пункта нет. Повторите ввод: ");
                    cicle = true;
                }
            }
            while (cicle);

            return item;
        }

        public static double DoubleParse()
        {
            double num = 0;
            bool isntParse = true;

            while (isntParse)
            {
                isntParse = !double.TryParse(Console.ReadLine(), out num);

                if (isntParse)
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
                else
                {
                    isntParse = false;
                }
            }

            return num;
        }

        public static char CharParse()
        {
            char doubleNum = '0';
            bool isParse = true;
            while (isParse)
            {
                try
                {
                    doubleNum = char.Parse(Console.ReadLine());
                    isParse = false;
                }
                catch
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
            }
            return doubleNum;
        }

        public static int IntArrayParse()
        {
            int arraySize = 0;
            bool cicle = true;

            Console.Write("Введите размер массива: ");

            do
            {
                cicle = !int.TryParse(Console.ReadLine(), out arraySize);

                if (cicle)
                {
                    Console.Write("Ошибка ввода. Повторите попытку: ");
                }
                else if (0 > arraySize)
                {
                    Console.Write("Ошибка: массив не может быть размера меньше 0. Повторите ввод: ");
                    cicle = true;
                }
            }
            while (cicle);

            return arraySize;
        }


        //Методы пунктов меню
        static void Riddle()
        {
            double a;
            double b;

            Console.WriteLine("\n- - - Отгадай загадку - - -");

            Console.Write("Введите угол a: ");
            a = PI * DoubleParse() / 180;

            Console.Write("Введите угол b: ");
            b = PI * DoubleParse() / 180;

            Guessing(Function(a,b));

            Console.Write("Для выхода нажмите...\n\n");
            Console.ReadKey(true);
        }

        static void MathQuestions()
        {
            byte rightAnswers = 0;
            char mathAction;
            int num1;
            int num2;
            int res;
            int userRes;
            string action;

            Console.WriteLine("\n- - - Простой математический тест - - -");

            for (int i = 0; i < 3; i++)
            {
                mathAction = (char)random.Next('1', '4');
                num1 = random.Next(0, (10));
                num2 = random.Next(0, (10));

                switch (mathAction)
                {
                    case '1':
                        res = num1 + num2;
                        action = "+";

                        break;

                    case '2':
                        res = num1 - num2;
                        action = "-";
                        break;

                    case '3':
                        res = num1 * num2;
                        action = "*";

                        break;

                    default:
                        res = 0;
                        action = "";
                        break;
                }

                Console.WriteLine($"Сколько будет {num1} {action} {num2}?");
                Console.Write("Введите ответ: ");

                userRes = IntParse();

                if (userRes == res)
                {
                    rightAnswers += 1;
                }
            }
            Console.WriteLine($"Правильных ответов: {rightAnswers}");
            Console.Write("Для выхода нажмите...\n\n");
            Console.ReadKey(true);
        }

        static void ArraySorting()
        {
            int n, sort1 = 0, sort2 = 0;
            double sortingTime1, sortingTime2;

            Console.WriteLine("\n- - - Сортировка массива - - -");

            n = IntArrayParse();
            int[] array = ArrayCreater(n);
            int[] arrayCopy = ArrayCopier(array);

            if (n > 10)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10\n");
            }
            else
            {
                Console.Write("Ваш массив: ");
                WriteArray(array);
                Console.WriteLine();
            }

            Console.WriteLine("Выберите желаемые сортировки:\n" +
                              "1. Сортировка пузырьком\n" +
                              "2. Сортировка выбором\n" +
                              "3. Сортировка вставками\n" +
                              "4. Сортировка Шелла\n" +
                              "5. Сортировка перемешиванием\n" +
                              "6. Гномья сортировка\n");
            
            Console.Write("Первая сортировка: ");

            sort1 = SortingChoose(1, 6);

            sortingTime1 = Sortier(array, sort1);

            sort2 = SortingChoose(1, 6);

            sortingTime2 = Sortier(arrayCopy, sort2);

            if (n <= 10)
            {
                Console.Write($"\nВаш отсортированный массив: ");
                WriteArray(array);
            }

            Console.WriteLine($"\nВремя работы первой сортировки: {sortingTime1} мс.\n" +
                              $"Время работы второй сортировки: {sortingTime2} мс.");

            Console.Write("Для выхода нажмите...\n\n");
            Console.ReadKey(true);
        }

        static void Information()
        {
            Console.WriteLine("\n- - - Об авторе - - -\n" +
                            "ФИО: Лылов Владислав Вячеславович\n" +
                            "Группа: 6101-090301D");
            Console.Write("Для выхода нажмите...\n\n");
            Console.ReadKey(true);
        }

        static bool Exit()
        {
            char sure;
            bool cicle = true;

            Console.WriteLine("\n- - - Выход - - -");
            Console.Write("Вы уверены? (д / н)\n" +
                "Выберете: ");

            while (cicle)
            {
                sure = CharParse();
                switch (sure)
                {
                    case 'д':
                        {
                            return true;
                        }
                    case 'н':
                        {
                            Console.WriteLine();
                            cicle = false;
                            return false;
                        }
                    default:
                        {
                            Console.Write("Ошибка ввода. Повторите попытку:");
                            break;
                        }
                }
            }
            return false;
        }


        //Подметоды пунктов меню
        private static double Function(double a, double b)
        {
            return Math.Round(Math.Sin((Math.Pow(a, 3) + Math.Pow(b, 5)) / (2 * PI)) + Math.Pow(Math.Cos(a + b), (1.0 / 3)), 2);
        }

        static void Guessing(double result)
        {
            byte trys = 3;
            double answer;

            Console.Write("Введите ваш ответ (окргулите до двух после запятой): ");

            for (byte i = 1; i <= trys; i++)
            {
                answer = DoubleParse();

                if (answer == result)
                {
                    Console.WriteLine("Вы победили!");
                    return;
                }
                else
                {
                    if (i < 3)
                    {
                        Console.Write($"\nВы не угадали. Осталось попыток: {3 - i}\n" +
                                      $"Попробуйте ещё раз: ");
                    }
                    else
                    {
                        Console.WriteLine($"\nУ вас закончились попытки, вы проиграли.\n" +
                                          $"Правильный ответ: {result}");
                    }
                }
            }
        }

        static double Sortier(int[] array, int sortType)
        {
            double sortingTime = 0;

            switch (sortType)
            {
                case 1:
                    sortingTime = BubbleSort(array);
                    break;

                case 2:
                    sortingTime = SelectionSort(array);
                    break;

                case 3:
                    sortingTime = InsertionSort(array);
                    break;

                case 4:
                    sortingTime = ShellSort(array);
                    break;

                case 5:
                    sortingTime = ShakerSort(array);
                    break;

                case 6:
                    sortingTime = GnomeSort(array);
                    break;
            }

            return sortingTime;
        }


        //Метод программы
        static void Main()
        {
            bool cicleWhile = true;

            do
            {
                Console.WriteLine("- - - Меню - - -\n" +
                    "1. Отгадай загадку\n" +
                    "2. Простой математический тест\n" +
                    "3. Cортировка массива\n" +
                    "4. Об авторе\n" +
                    "5. Выход");
                Console.Write("Выберите действие: ");

                switch (MenuChoose(1, 5))
                {
                    case 1:
                        Riddle();
                        break;

                    case 2:
                        MathQuestions();
                        break;

                    case 3:
                        ArraySorting();
                        break;

                    case 4:
                        Information();
                        break;

                    case 5:
                        cicleWhile = !Exit();
                        break;
                }
            }
            while (cicleWhile);
        }
    }
}