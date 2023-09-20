// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* 
            Вариант Б16
1. Проверить истинность высказывания: "Сумма цифр данного положительного трехзначного числа является нечетным числом".

2. Задано целое положительное четырехзначное число N (N > 0).
    Найти сумму между произведениями первых двух и последних двух его цифр.

3. Дан целочисленный массив, состоящий из N элементов (N > 0). 
    Если в наборе имеются отрицательные четные числа, то найти сумму всех положительных нечетных чисел, 
    иначе вычислить сумму всех чисел, которые кратные числу 3.

4. Вводится строка-предложение на английском языке. 
    Длина строки может быть разной. Определить и вывести слово, содержащего наибольшее число символов 'd'.

5. Вводится строка, состоящая из слов, разделенных подчеркиваниями (одним или несколькими).
    Длина строки может быть разной. Определить и вывести количество слов, которые начинаются и заканчиваются одной и той же буквой.
*/

namespace RR06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1
            uint N;

        task1_Input:
            try
            {
                Console.ResetColor();
                Console.WriteLine("Введите трёхзначное значение N");
                N = Convert.ToUInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                if (N.ToString().Length != 3)
                {
                    Console.WriteLine("Число должно быть трёхзначным");
                    Console.WriteLine("\n\n\n\n");
                    goto task1_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.WriteLine("\n\n\n\n");
                goto task1_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\n\n\n\n");
                goto task1_Input;
            }

            uint[] array01 = new uint[3];

            for (int i = 0; i < array01.Length; i++)
            {
                array01[i] = (N%10);
                N /= 10;
            }

            uint abc = 0;
            for (int i = 0; i < array01.Length; i++) 
            {
                abc += array01[i];
            }
            abc %= 2;
            string result01 = abc==0 ? "Ложь" : "Истина";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nРезультат: {0}", result01);
            Console.ResetColor();
            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 2
            uint N2;

        task2_Input:
            try
            {
                Console.ResetColor();
                Console.WriteLine("Введите четырёхзначное значение N");
                N2 = Convert.ToUInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                if (N2.ToString().Length != 4)
                {
                    Console.WriteLine("Число должно быть четырёхзначным");
                    Console.WriteLine("\n\n\n\n");
                    goto task2_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное значение");
                Console.WriteLine("\n\n\n\n");
                goto task2_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\n\n\n\n");
                goto task2_Input;
            }
            uint[] array02 = new uint[4];

            for (int i = 0; i < array02.Length; i++)
            {
                array02[i] = (N2 % 10);
                N2 /= 10;
            }

            uint task2_comp12 = array02[0] * array02[1];
            uint task2_comp34 = array02[2] * array02[3];
            uint task2_sum = task2_comp12 + task2_comp34;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nРезультат: {0}", task2_sum); 
            Console.ResetColor();
            Console.Write("\nНажмите любую клавишу для продолжения... ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 3
            uint elementsCount_task3 = 0;

        task3_Input:
            Console.WriteLine("Введите количество элементов массива");
            try
            {
                Console.ResetColor();
                elementsCount_task3 = Convert.ToUInt32(Console.ReadLine());
                
                if (elementsCount_task3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество элементов в массиве не может равняться нулю");
                    Console.WriteLine("\n\n\n\n");
                    goto task3_Input;
                }
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВведено слишком большое, либо отрицательное число");
                Console.WriteLine("\n\n\n\n");
                goto task3_Input;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\n\n\n\n");
                goto task3_Input;
            }

            int[] array03 = new int[elementsCount_task3];
        task3_Input_arr:
            Console.ResetColor();
            Console.WriteLine("Выберите способ заполнения массива: \n1. Вручную \n2. Автоматически");
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; elementsCount_task3 > i; i++)
                    {
                        Console.WriteLine("Введите элемент массива #{0}", i);

                        try
                        {
                            array03[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nВведено слишком большое число");
                            Console.WriteLine("\n\n\n\n");
                            goto task3_Input_arr;

                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nНеверный формат ввода");
                            Console.WriteLine("\n\n\n\n");
                            goto task3_Input_arr;
                        }

                    }
                    break;
                case "2":
                    Random randomNumber_task3 = new Random();
                    for (int i = 0; elementsCount_task3 > i; i++)
                    {
                        array03[i] = randomNumber_task3.Next(-150, 150);
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Выбран некорректный вариант заполнения массива");
                    Console.ResetColor();
                    break;
            }

            bool hasNegativeAndParity = false;
            int array03sum = 0;
            for (int i = 0; i < array03.Length; i++)
            {
                if (array03[i] < 0 && (array03[i] % 2) == 0) hasNegativeAndParity = true;
            }

            if (hasNegativeAndParity)
            {
                for (int i = 0; i < array03.Length; i++)
                {
                    if (array03[i] > 0 && (array03[i] % 2) != 0) array03sum += array03[i];
                }
            }

            if (!hasNegativeAndParity)
            {
                for (int i = 0; i < array03.Length; i++)
                {
                    if ((array03[i] % 3) == 0) array03sum += array03[i];
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nРезультат: {0}", array03sum);
            Console.ResetColor();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 4
            Console.WriteLine("Введите предложение, разделяя слова пробелами");
            string string04 = Console.ReadLine();

            string[] string04Splitted = string04.Split(' ');
            int[] counter04 = new int[string04Splitted.Length];

            for (int i = 0; i < string04Splitted.Length; i++)
            {
                char[] charsInWord = string04Splitted[i].ToCharArray();
                for(int c = 0; c < charsInWord.Length; c++)
                { 
                    if (charsInWord[c] == 'd') counter04[i]++;
                }
            }

            int neededIndex = counter04.ToList().IndexOf(counter04.Max());

            Console.ForegroundColor = ConsoleColor.Green;
            if (counter04.Max() == 0)
            {
                Console.WriteLine("В данном предложении нет слов содержащих \"d\"");
                goto task4_end;
            }

            Console.WriteLine("Результат: {0}", string04Splitted[neededIndex]);
            for (int i = 0; i < counter04.Length; i++)
            {
                if (counter04[i] == counter04.Max() && i != neededIndex) Console.WriteLine("Слово #{0} с таким же количеством " +
                                                     "символов d: {1}", i, string04Splitted[i]);
            }

        task4_end:
            Console.ResetColor();
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
            #endregion

            #region Задание 5
            Console.WriteLine("Введите предложение, разделяя слова символом \"_\"");
            string string05 = Console.ReadLine();

            string[] string05Splitted = string05.Split('_');
            int counter05 = 0;

            for (int i = 0; i < string05Splitted.Length; i++)
            {
                char[] charsInWord05 = string05Splitted[i].ToCharArray();
                for (int j = 0; j < charsInWord05.Length; j++)
                {
                    if (charsInWord05[0] == charsInWord05[charsInWord05.Length - 1]) { counter05 += 1; break; }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результат: {0}", counter05);
            Console.ResetColor();
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            #endregion
        }
    }
}
