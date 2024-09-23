using Stack_Queues_Sorting;

namespace StacksAndQueue_Sorting
{
    internal class Program
    {
        static void PalindromeCount()
        {
            // few plaindrom here edge case  string filepath = @"C:\Users\aaron\Desktop\edgecase.txt"
            // no plaindromes edge case "C:\Users\aaron\Desktop\nomatchcase.txt"
            // real case @"C:\Users\aaron\Desktop\magicitems.txt"

            string filepath = @"C:\Users\aaron\Desktop\magicitems.txt";
            List<string> magicItems = new List<string>();
            int linecount = 0;
            Stack stack = new Stack();
            Queue queue = new Queue();
            Sort sort = new Sort();

            try
            {
                //Passes file path and name to streamReader constructor 
                StreamReader sr = new StreamReader(filepath);

                int palindromeCount = 0;


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

                    foreach (string item in magicItems)
                    {
                        //Console.WriteLine($"Magical Item: {item}");

                        foreach (char c in item)
                        {
                            stack.Push(c);
                            queue.Enqueue(c);

                            //Console.WriteLine($"Characters: {c}
                        }

                        if (CompareLetter(stack, queue))
                        {
                            palindromeCount++;
                            Console.WriteLine("\t" + $"Magical Item: {item}" + " is a palindrome");
                        }

                    }

                    Console.WriteLine(new string('-', 40));

                    Console.WriteLine("There are " + palindromeCount + " Palindromes in the text file");
                    Console.WriteLine("Total number of lines: " + linecount);


                    //Shuffle(magicItems);
                    //sort.SelectionSort(magicItems);
                    //Shuffle(magicItems);
                    //sort.InsertionSort(magicItems);
                    //Shuffle(magicItems);
                    //sort.MergeSorting(magicItems,0,magicItems.Count - 1);
                    //Shuffle(magicItems);
                    //sort.QuickSorting(magicItems,0,magicItems.Count);


                }
                Console.WriteLine(new string('-', 40));

                PerformSorting(magicItems, sort);

                sr.Close();
                Console.ReadLine();

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception:" + e.Message);
            }
        }

        public static bool CompareLetter(Stack s, Queue q)
        {
            bool match = true;

            while (!q.isEmpty() && !s.isEmpty())
            {
                char stackChar = s.Pop();
                char queueChar = q.Dequeue();

                if (stackChar != queueChar)
                {
                    match = false;
                }

            }
            return match;
        }

        public static void Shuffle(List<string> items)
        {

            Random r = new Random();
            //Step 1: For each unshuffled item in the collection
            for (int n = items.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick an item which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unstruck" letter in the collection
                string temp = items[n];
                items[n] = items[k];
                items[k] = temp;
            }
        }

        static void PerformSorting(List<string> items, Sort sort)
        {
            Shuffle(items);
            Console.WriteLine("\nPerforming Selection Sort:");
            sort.SelectionSort(items);


            Shuffle(items);
            Console.WriteLine("\nPerforming Insertion Sort:");
            sort.InsertionSort(items);

            Shuffle(items);
            Console.WriteLine("\nPerforming Merge Sort:");
            sort.MergeSorting(items, 0, items.Count - 1);

            Shuffle(items);
            Console.WriteLine("\nPerforming Quick Sort:");
            sort.QuickSorting(items, 0, items.Count - 1);
        }

        static void Main(string[] args)
        {
            PalindromeCount();
        }

    }
}
