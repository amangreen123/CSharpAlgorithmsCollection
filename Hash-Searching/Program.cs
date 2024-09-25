using System;
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

                    Console.WriteLine("===============================================");
                    Console.WriteLine("=== Magic Item Search and Hash Analysis ===");
                    Console.WriteLine("===============================================\n");

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


                    Console.WriteLine("===============================================");
                    Console.WriteLine("=== Search Comparisons ===");
                    Console.WriteLine("===============================================\n");

                    Console.WriteLine($"Randomly chosen item to search for: '{target}'\n");
                    Console.WriteLine("--- Linear Search ---");

                    int linearSerachResult = Search.LinearSearch(randomMagicItems, randomMagicItems[chosenItem]);
                    Console.WriteLine($"Linear Search Result: Position {linearSerachResult}\n");

                    Console.WriteLine("--- Binary Search ---");
                    int binaryResult = Search.BinarySearch(randomMagicItems, randomMagicItems[chosenItem]);
                    Console.WriteLine($"Binary Search Result: Position {binaryResult}\n");

                    Console.WriteLine("===============================================");
                    Console.WriteLine("=== Hash Code Analysis ===");
                    Console.WriteLine("===============================================\n");

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


                    Console.WriteLine("\nGenerating hash codes for all items:");

                    for (int i = 0; i < randomMagicItems.Count; i++)
                    {

                        hashCode = HashMap.makeHashCode(randomMagicItems[i]);
                        hashValues[i] = hashCode;
                        hashValues[hashCode]++;
                        //Console.WriteLine(String.Format("{0:D3}", hashCode));
                        Console.WriteLine($"Item: {randomMagicItems[i]}, Hash Code: {hashCode:D3}");
                    }

                    HashMap.analyzeHashValues(hashValues);

                    Console.WriteLine("Prints the HashMap:");
                    hashMap.Display();

                    Console.WriteLine("\n===============================================");
                    Console.WriteLine("=== Search Performance ===");
                    Console.WriteLine("===============================================\n");

                    Console.WriteLine("Searching for all items and counting comparisons:");
                    Console.WriteLine("------------------------------------------------");

                    //Perform Search
                    Console.WriteLine("\nSearching for all items and counting comparisons:");
                
                    hashMap.PrintComparions();

                    Console.WriteLine($"\nSearching for: {target}");

                    string result = hashMap.Get(target);

                    if (result != null)
                    {
                        Console.WriteLine($"Target {target} found in the map.");
                    }
                    else
                    {
                        Console.WriteLine($"Target {target} not found in the map.");
                    }


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
