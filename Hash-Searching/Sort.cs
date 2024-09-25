using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Stack_Queues_Sorting
{
    public class Sort
    {

        public int numComparisons {  get; set; }
        private bool printsOnce = true;

        public Sort() { 
          
            numComparisons = 0;
        }

        private void PrintSortResults(string sortName, List<string> items)
        {
            Console.WriteLine($"\n{new string('-', 40)}");
            Console.WriteLine($"{sortName}:");
            Console.WriteLine($"\nTotal Comparisons Made: {numComparisons}");
            Console.WriteLine(new string('-', 40));
        }


        public void SelectionSort(List<string> items)
        {
            int size = items.Count;

            int minimum_index;


            for (int i = 0; i < size - 1;  i++)
            {
                minimum_index = i;

                for (int j = i + 1; j <= size - 1; j++)
                {
                    if (items[j] == items[minimum_index])
                    {
                        minimum_index = j;
                    }

                    numComparisons++;
                    
                }

                string temp = items[i];
                items[i] = items[minimum_index];
                items[minimum_index] = temp;
            }

            PrintSortResults("Selection Sort", items);
        }

        public List<string> InsertionSort(List<string> items)
        {

            //i starts form second element and goes through the list
            //j tracks the position of the current element being compared with prev to find its place

            // Start from the second element and iterate through the list
            for (int i = 1; i < items.Count; i++)
            {
                int j = i - 1;
                string value = items[i]; // Store the current element being sorted


                // Move elements that are larger than 'value' to the right
                while (j >= 0 && string.Compare(value, items[j + 1]) < 0) {

                    items[j] = items[j - 1]; // Shift the element to the right
                    j --; // Move to the previous element
                }

                items[j + 1] = value;
                numComparisons++;

            }

            PrintSortResults("Insertion Sort", items);
            return items;
        }


        public void Merge(List<string> items, int l, int m, int r)
        {
            //find lengths of two subarrays
            int leftLength = m - l + 1;
            int rightLength = r - m;


            //creates temp arrays
            var tempLeft = new string[leftLength];
            var tempRight = new string[rightLength];

            //Copy the sorted left and right half to temp arrays

            for (int a = 0; a < leftLength; a++)
            {
                tempLeft[a] = items[l + a];
            }

            for (int b = 0; b < rightLength; b++)
            {
                tempRight[b] = items[m + 1 + b];
            }

            // initial indexes of left and right sub-arrays
            int i = 0; // index for left
            int j = 0; // index for right
            int k = l; // Initial index of merged subarray array

            while (i < leftLength && j < rightLength)
            {
                if (string.Compare(tempLeft[i],tempRight[j]) <= 0)
                {
                    items[k] = tempLeft[i];
                    i++;
                }
                else
                {
                    items[k] = tempRight[j];
                    j++;
                }

                k++;
                numComparisons++;
            }

            // Copy remaining elements of L[] if any 
            while (i < leftLength)
            {
                items[k] = tempLeft[i];
                i++;
                k++;    
            }

            // Copy remaining elements of R[] if any 
            while (j < rightLength)
            {
                items[k] = tempRight[j];
                j++;
                k++;
            }

        }

        public List<string> MergeSorting(List<string> items, int l, int r)
        {
            
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSorting(items, l, m);
                MergeSorting(items, m + 1, r);
                Merge(items, l,m,r);


                if (l == 0 && r == items.Count - 1)
                {
                    PrintSortResults("Merge Sort", items);
                }

            }     

            return items;
        }

        public List<string> QuickSorting(List<string> items, int s, int e) {

            // Base case: if the segment is 1 or fewer elements, return
            if (e - s + 1 <= 1) {

                return items;

            }

            string pivot = items[e];
            int left = s; // pointer for left side


            // Partition the array
            for (int i = s; i < e; i++) {

                if (string.Compare(items[i],pivot) < 0)
                {
                    string tmp = items[left];
                    items[left] = items[i];
                    items[i] = tmp;
                    left++;
                }
                numComparisons++;
            }

            //Move pivot in-between left & right sides
            items[e] = items[left];
            items[left] = pivot;

            // Recursively sort the left and right subarrays
            QuickSorting(items, s, left - 1);
            QuickSorting(items, left + 1, e);

            if (s == 0 && e == items.Count - 1 && printsOnce)
            {
                //PrintSortResults("Quick Sort", items);
                printsOnce = false; // Ensure print happens only once
            }


            return items;

        }


    }

   
}
