using System;
using System.Linq;
using System.Collections.Generic;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter the sequence of numbers separated by comma and space: ");
                var arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();


                Console.Write("Please enter the number who you are looking: ");
                var numberForLooking = double.Parse(Console.ReadLine());

                var saveCurrentIndexes = new Dictionary<double, List<int>>();
                FillSaveCurrentIndexes(saveCurrentIndexes, arr);

                var result = BinarySearch(arr, numberForLooking);

                PrintResult(saveCurrentIndexes, result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
            }
        }

        private static void FillSaveCurrentIndexes(Dictionary<double, List<int>> numberIndex, double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (!numberIndex.ContainsKey(arr[i]))
                {
                    numberIndex.Add(arr[i], new List<int>());
                }

                numberIndex[arr[i]].Add(i);
            }
        }

        private static double BinarySearch(double[] arr, double number)
        {
            Array.Sort(arr);

            var index = (arr.Length - 1) / 2;
            int length = arr.Length;

            if (arr.Length % 2 == 0)
            {
                if (arr[index] == number)
                {
                    return arr[index];
                }

                if (arr[index] > number)
                {
                    index = index + 1;
                }
            }


            while (length > 0 && index <= arr.Length - 1 && index >= 0)
            {

                if (arr[index] == number)
                {
                    return arr[index];
                }

                if (index > 0 && arr[index - 1] == number)
                {
                    return arr[index - 1];
                }

                if (index < arr.Length - 1 && arr[index + 1] == number)
                {
                    return arr[index + 1];
                }

                length /= 2;

                if (arr[index] < number)
                {
                    index = index + length;
                }
                else
                {
                    index = index - length;

                }
            }

            return -1;
        }

        private static void PrintResult(Dictionary<double, List<int>> saveCurrentIndexes, double result)
        {
            if (result == -1)
            {
                Console.WriteLine("Number not present");
            }
            else
            {
                var currentIndexNumber = saveCurrentIndexes[result];

                if (currentIndexNumber.Count == 1)
                {
                    Console.WriteLine($"Number found at index {currentIndexNumber[0]}");
                }
                else
                {
                    Console.WriteLine($"Numbers found at indexs {string.Join(", ", currentIndexNumber)}");
                }
            }
        }
    }
}
