using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Searching
{
    internal class Search
    {

        public static int LinearSearch(List<string> magicItems, string target)
        {
            Console.WriteLine($"Starting Linear Search for '{target}'");

            int comparisonCount = 0;

            for (int i = 0; i < magicItems.Count; i++)
            {

                if (magicItems[i] == target)
                {
                    comparisonCount++;
                    Console.WriteLine($"Found '{target}' after {comparisonCount} comparison{(comparisonCount > 1 ? "s" : "")} at index {i}");
                    return i;
                }

            }
            return -1;
        }

        public static int BinarySearch(List<string> magicItems, string target)
        {
            int left = 0;
            int right = magicItems.Count - 1;
            int mid;

            int comparisonCount = 0;

            while (left < right)
            {
                mid = left + (left + right) / 2;

                int comparisonResult = string.Compare(target, magicItems[mid]);

                if (comparisonResult > 0)
                {
                    left = mid + 1;
                    comparisonCount++;
                }
                else if (comparisonResult < 0)
                {
                    right = mid - 1;

                }
                else
                {
                    Console.WriteLine($"Found '{target}' after {comparisonCount} comparisons at index {mid}");
                    return mid;

                }
                Console.WriteLine($"Comparison {comparisonCount}: Checked index {mid} - '{magicItems[mid]}'");
            }

            Console.WriteLine($"'{target}' not found. Performed {comparisonCount} comparisons.");
            return -1;
        }
    }
}
