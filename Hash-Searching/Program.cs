﻿using System;
using Stack_Queues_Sorting;



namespace Hash_Searching
{


    internal class Program
    {
        static void HashandSearch()
        {
           
            string filepath = @"C:\Users\aaron\Desktop\magicitems.txt";
            List<string> magicItems = new List<string>();
            int linecount = 0;
            
            Random random = new Random();
            Search Search = new Search();
            Sort sort = new Sort();


            try
            {
                //Passes file path and name to streamReader constructor 
                StreamReader sr = new StreamReader(filepath);

                using (sr)
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        linecount++;
                        //ignores white space and Caps
                        string lowerCase = line.ToLower();
                        string cleanLine = string.Concat(lowerCase.Where(c => char.IsLetterOrDigit(c)));

                        //adds lines into list 
                        if (!string.IsNullOrEmpty(cleanLine)) // Only add non-empty lines
                        {
                            magicItems.Add(cleanLine);
                        }

                    }

                    Console.WriteLine("=== Magic Item Search Comparison ===\n");
                    //Gets 42 random items for the list 
                    List<string> randomMagicItems = GetRandomItems(magicItems, 42);
                    Console.WriteLine($"Selected 42 random items from the list of {magicItems.Count} magic items.\n");
                    sort.QuickSorting(randomMagicItems, 0, randomMagicItems.Count - 1);

                    for (int i = 0; i < randomMagicItems.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {randomMagicItems[i]}");
                    }
                    Console.WriteLine();

                    int chosenItem = random.Next(randomMagicItems.Count);
                    string target = randomMagicItems[chosenItem];

                    Console.WriteLine($"Randomly chosen item to search for: '{target}'\n");
                    Console.WriteLine("--- Linear Search ---");

                    int linearSerachResult = Search.LinearSearch(randomMagicItems, randomMagicItems[chosenItem]);
                    Console.WriteLine($"Linear Search Result: Position {linearSerachResult}\n");

                    Console.WriteLine("--- Binary Search ---");
                    int binaryResult = Search.BinarySearch(randomMagicItems, randomMagicItems[chosenItem]);
                    Console.WriteLine($"Binary Search Result: Position {binaryResult}\n");


                    Console.WriteLine("Hash code tests and analysis.");
                    Console.WriteLine("-----------------------------");

                    HashMap hashMap = new HashMap();
                    int[] hashValues = new int[666];
                    hashMap.createHashTable(250);

                    AaronQueue queue = new AaronQueue();
                    int hashCode = 0;
       

                    foreach (string item in randomMagicItems)
                    {
                        hashMap.Put(item);
                    }

                    foreach (string item in randomMagicItems) { 
                    
                        hashMap.Get(item);
                    }
                 


                    Console.WriteLine("\nHash Map Contents:");
                    hashMap.Display();

                    //Perform Search
                    Console.WriteLine("\nSearching for all items and counting comparisons:");
                    
                    string targetItem = randomMagicItems[chosenItem];
                    hashMap.PrintComparions();

                    Console.WriteLine($"\nSearching for: {targetItem}");

                    string result = hashMap.Get(targetItem);

                    if (result != null)
                    {
                        Console.WriteLine($"Target {targetItem} found in the map.");
                    }
                    else
                    {
                        Console.WriteLine($"Target {targetItem} not found in the map.");
                    }

                    Console.WriteLine("\nGenerating hash codes for all items:");
                    
                    for (int i = 0; i < randomMagicItems.Count; i++) {

                        hashCode = HashMap.makeHashCode(randomMagicItems[i]);
                        hashValues[i] = hashCode;
                        Console.WriteLine(String.Format("{0:D3}", hashCode));
                    }

                    HashMap.analyzeHashValues(hashValues);

                    sr.Close();
                    Console.ReadLine();

                }
            }

            catch (Exception e)
            {

                Console.WriteLine("Exception:" + e.Message);
            }
        }


        static void Main(string[] args)
        {
            HashandSearch();
        }



        public static List<string> GetRandomItems(List<string> magicItems, int numberofElements)
        {
            var random = new Random();
            var randomItems = new List<string>(magicItems.Count);  // Allocate memory for significant speedup.
            int count = 0;

            for (int i = 0; i < numberofElements; i++)
            {

                var randomIndex = random.Next(0, magicItems.Count);
                var randomItem = magicItems[randomIndex];
                randomItems.Add(randomItem);

                //Console.WriteLine($"Item Added: {randomItem}");
               // count++;
            }
            return randomItems;
        }


    }


}
