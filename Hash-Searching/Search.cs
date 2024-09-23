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

                comparisonCount++;

                if (magicItems[i] == target)
                {
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

            Console.WriteLine($"Starting Binary Search for '{target}'");

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                int comparisonResult = string.Compare(target, magicItems[mid]);
                comparisonCount++;

                if (comparisonResult > 0)
                {
                    left = mid + 1;
                    
                }
                else if (comparisonResult < 0)
                {
                    right = mid - 1;

                }
                else
                {
                    Console.WriteLine($"Found '{target}' after {comparisonCount} comparison{(comparisonCount != 1 ? "s" : "")} at index {mid}");

                    return mid;
                }
                
                Console.WriteLine($"Comparison {comparisonCount}: Checked index {mid} - '{magicItems[mid]}'");
            }

            Console.WriteLine($"'{target}' not found. Performed {comparisonCount} comparisons.");
            
            return -1;
        }
    }
}
