namespace Hash_Searching
{
    internal class Program
    {
        static void HashandSearch()
        {

            string filepath = @"C:\Users\aaron\Desktop\magicitems.txt";
            List<string> magicItems = new List<string>();
            int linecount = 0;
            Search Search = new Search();

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
                            List<string> randomItems = GetRandomItems(magicItems, 42);

                            foreach (var item in randomItems)
                            {
                               Search.LinearSearch(magicItems, item);

                            }
                        }

                    }

                }
                sr.Close();
                Console.ReadLine();

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

            for (int i = 0; i < numberofElements; i++)
            {

                var randomIndex = random.Next(0, magicItems.Count);
                var randomItem = magicItems[randomIndex];
                randomItems.Add(randomItem);
            }

            return randomItems;
        }
    }


}
