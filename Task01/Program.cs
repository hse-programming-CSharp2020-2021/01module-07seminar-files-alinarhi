using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";

        static int[] ReadFile(string path)
        {
            string[] input = File.ReadAllText(path).Split();
            int n = input.Length;
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            return arr;
        }

        static bool CheckArray(int[] array)
        {
            foreach (var el in array)
            {
                if (el < -10 || el > 10)
                {
                    return false;
                }               
            }
            return true;
        }

        static bool[] IntToBoolArray(int[] array)
        {
            bool[] bools = new bool[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                bools[i] = array[i] >= 0 ? true : false;
            }
            return bools;
        }

        static void WriteFile(string path, bool[] array)
        {
            string text = "";
            foreach(var el in array)
            {
                text += el ? "true " : "false ";
            }
            text.TrimEnd();
            File.WriteAllText(path, text);
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();

            int[] A;
            bool[] L;

            try
            {
                A = ReadFile(inputPath);

                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                }
                else 
                {
                    L = IntToBoolArray(A);
                    WriteFile(outputPath, L);
                    ConsoleOutput();
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // do not touch
            //ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}