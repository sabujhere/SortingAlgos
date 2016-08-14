using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 4, 1, 6,562,41,879,125,20,87,5,8,5,8 };

            IEnumerable<int> sortedNumbers = MergeSort(numbers);
            foreach (int number in sortedNumbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }

        public static IEnumerable<int> MergeSort(IEnumerable<int> numbers)
        {
            if (numbers.Count() <= 1)
                return numbers;

            int mid = numbers.Count() / 2;

            IEnumerable<int> left = numbers.Take(mid).ToList();
            IEnumerable<int> right = numbers.Skip(mid).ToList();
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static IEnumerable<int> Merge(IEnumerable<int> left, IEnumerable<int> right)
        {
            
            List<int> results = new List<int>();
            int totalNumber = left.Count() + right.Count();
            int rightIndex =  0;
            int leftIndex = 0;
 
            for (int i = 0; i < totalNumber;i++ )
            {
                if(rightIndex >= right.Count())
                {
                    results.AddRange(left.Skip(leftIndex));
                    return results;
                }
                if(leftIndex>= left.Count())
                {
                    results.AddRange(right.Skip(rightIndex));
                    return results;
                }
                if (left.ElementAt(leftIndex) <= right.ElementAt(rightIndex))
                {
                    results.Add(left.ElementAt(leftIndex));
                    leftIndex++;
                }
                else if(left.ElementAt(leftIndex) > right.ElementAt(rightIndex))
                {
                    results.Add(right.ElementAt(rightIndex));
                    rightIndex++;
                }
            }
            return results;
        }
    }
}
