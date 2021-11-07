using System;

namespace Les4_DZ1
{
    public class Program
    {
        // Создать массив на N элементов, где N указывается с консольной строки.Заполнить его случайными числами от 1 до 26 включительно.
        // Создать 2 массива, где в 1 массиве будут значение только четных значений, а во втором нечетных.
        // Заменить числа в 1 и 2 массиве на буквы английского алфавита.
        // Значения ячеек этих массивов равны порядковому номеру каждой буквы в алфавите.
        // Если же буква является одной из списка (a, e, i, d, h, j) то она должна быть в верхнем регистре.
        // Вывести на экран результат того, в каком из массивов будет больше букв в верхнем регистре.
        // Вывести оба массива на экран.Каждый из массивов должен быть выведен 1 строкой, где его значения будут разделены пробелом.
        public static void Main(string[] args)
        {
            int sizeArray;
            do
            {
                Console.Write("Enter size array :");
            }
            while (!int.TryParse(Console.ReadLine(), out sizeArray));

            // int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            // int size_array = arr.Length;
            int[] arr = new int[sizeArray];
            char[] arrOdd = new char[sizeArray];
            char[] arrEven = new char[sizeArray];
            char[] arrUpper = new char[] { 'a', 'e', 'i', 'd', 'h', 'j' };

            FillArray(arr, sizeArray, 1, 26);
            int k = 0, j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arrOdd[j++] = NumberToChar(arr[i], arrUpper);
                }
                else
                {
                    arrEven[k++] = NumberToChar(arr[i], arrUpper);
                }
            }

            Array.Resize(ref arrEven, j);
            Array.Resize(ref arrOdd, k);

            int countUpperLetterEven = CountUpperLetter(arrEven);
            int countUpperLetterOdd = CountUpperLetter(arrOdd);

            Console.Write($"Array Odd  <LETTERS> [{countUpperLetterOdd}]: ");
            DisplayArray(arrOdd);
            Console.Write($"Array Even <LETTERS> [{countUpperLetterEven}]: ");
            DisplayArray(arrEven);
            Console.WriteLine();

            if (countUpperLetterEven > countUpperLetterOdd)
            {
                Console.Write($"Count Upper letters: {countUpperLetterEven} =>");
                DisplayArray(arrEven);
            }
            else if (countUpperLetterEven < countUpperLetterOdd)
            {
                Console.Write($"Count Upper letters:{countUpperLetterOdd}  =>");
                DisplayArray(arrOdd);
            }
            else
            {
                Console.WriteLine($"Both arrays have the same number of uppercase letters: {countUpperLetterOdd}");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void FillArray(int[] a, int size_array, int low_BoundRandom, int high_BoundRandom)
        {
            Random rnd = new Random();

            for (int i = 0; i < size_array - 1; i++)
            {
                a[i] = rnd.Next(low_BoundRandom, high_BoundRandom);
            }
        }

        private static char NumberToChar(int i, char[] upperLetter)
        {
            char letter = (char)(i + 97);
            if (Array.IndexOf(upperLetter, letter) >= 0)
            {
                letter = char.ToUpper(letter);
            }

            return letter;
        }

        private static int CountUpperLetter(char[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                // if (a[i] >= 65 & a[i] <= 90)
                if (char.IsUpper(a[i]))
                {
                    count++;
                }
            }

            return count;
        }

        private static void DisplayArray(char[] arr, char separator = ' ')
        {
            Console.WriteLine(string.Join(separator, arr));
        }
    }
}
