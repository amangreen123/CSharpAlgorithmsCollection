using Stack_Queues_Sorting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Searching
{
    internal class HashMap
    {
        // Define the size of the hash table
        private const int HASH_TABLE_SIZE = 250;
        private int capacity;
        // Create an array of AaronQueues to serve as the hash table
        // Each AaronQueue will handle collisions through chaining
        public AaronQueue[] table = new AaronQueue[HASH_TABLE_SIZE];

        private int totalComparisons = 0;
        private int totalGetOperations = 0;

        public void createHashTable(int capacity)
        {
            this.capacity = capacity;
            this.table = new AaronQueue[HASH_TABLE_SIZE];

            for (int i = 0; i < HASH_TABLE_SIZE; i++)
            {
                this.table[i] = new AaronQueue();
            }
        }

        public void Put(string key)
        {
            int index = makeHashCode(key);
            table[index].Enqueue(key);
        }

        public string Get(string key) { 
         
            int index = makeHashCode(key);
           
            AaronQueue queue = table[index];
            int comparison = 1;

            //increase evertime a get is called 
            totalGetOperations++;

            if (queue.isEmpty())
            {
                Console.WriteLine($"Key '{key}' not found after {comparison} comparison(s).");

                totalComparisons += comparison;
                totalGetOperations++;
                return null;
            }

            int size = queue.Size();

            for (int i = 0; i < size; i++) { 
            
                string item = queue.Dequeue();

                comparison++;
                
                if(item == key)
                {
                    queue.Enqueue(key);
                    Console.WriteLine($"Key '{key}' found after {comparison} comparison(s).");
                    totalComparisons += comparison;

                    return item;
                }

                queue.Enqueue(item);
            }

            Console.WriteLine($"Key '{key}' not found after {comparison} comparison(s).");
            
            totalComparisons += comparison;
            totalGetOperations++;
            
            return null;
        
        }
        

        // Method to generate a hash code for a given string
        public static int makeHashCode(String str)
            {
                str = str.ToUpper();
                int length = str.Length;
                int letterTotal = 0;

                for (int i = 0; i < length; i++)
                {
                    char thisLetter = str[i];
                    int thisValue = thisLetter;

                    letterTotal = letterTotal + thisValue;
                }

                int hashCode = (letterTotal * 1) % 250;
                return hashCode;
        }



        public void Display()
        {
            Console.WriteLine("\nHash Map Contents:");
            for (int i = 0; i < table.Length; i++)
            {
                AaronQueue queue = table[i];
                if (!queue.isEmpty())
                {
                    Console.Write($"Bucket {i}: ");
                    int size = queue.Size();
                    for (int j = 0; j < size; j++)
                    {
                        string item = queue.Dequeue();
                        Console.Write($"{item} ");
                        queue.Enqueue(item);
                    }
                    Console.WriteLine();
                }
            }
        }



            // Method to analyze the distribution of hash values
            public static void analyzeHashValues(int[] hashValues)
            {
                int asteriskCount = 0;
                int [] bucketCount = new int [HASH_TABLE_SIZE];
                int totalCount = 0;
                int arrayIndex = 0;
                int lineinFile = 666;

            Console.WriteLine("HashTable Usage");

            Array.Sort(hashValues);


            for (int i = 0; i < HASH_TABLE_SIZE; i++)
            {
                bucketCount[i] = hashValues[i];
                totalCount += bucketCount[i];
                
                if (bucketCount[i] > 0)
                {
                    Console.WriteLine($"Bucket {i}: {new string('*', bucketCount[i])}");
                    Console.WriteLine($"Count: {bucketCount[i]}");
                }
            }

            // Print analysis results
            Console.WriteLine($"Total hash values: {totalCount}");
            Console.WriteLine($"Asterisk count: {asteriskCount}");

                int emptyBuckets = 0;
                int maxBucketSize = 0;
                double averageBucketSize = 0;

                for (int i = 0; i < HASH_TABLE_SIZE; i++)
                {
                    if (bucketCount[i] == 0)
                    {
                        emptyBuckets++;
                    }
                    else
                    {
                        Console.WriteLine($"Bucket {i}: {new string('*', bucketCount[i])}");
                        Console.WriteLine($"Count: {bucketCount[i]}");

                        maxBucketSize = Math.Max(maxBucketSize, bucketCount[i]);
                        averageBucketSize += bucketCount[i];
                    }
                }

                averageBucketSize /= (HASH_TABLE_SIZE - emptyBuckets);

                Console.WriteLine($"\nEmpty buckets: {emptyBuckets}");
                Console.WriteLine($"Max bucket size: {maxBucketSize}");
                Console.WriteLine($"Average bucket size: {averageBucketSize:F2}");

                // Average load calculations
                Console.Write("Average load (count): ");
                float averageLoad = (float)totalCount / HASH_TABLE_SIZE;
                Console.WriteLine($"{averageLoad:F2}");

                Console.Write("Average load (calc) : ");
                averageLoad = (float)lineinFile / HASH_TABLE_SIZE;
                Console.WriteLine($"{averageLoad:F2}");

                // Standard Deviation calculation
                Console.Write("Standard Deviation: ");
                double sum = 0;
                for (int i = 0; i < HASH_TABLE_SIZE; i++)
                {
                    double result = bucketCount[i] - averageLoad;
                    double square = result * result;
                    sum += square;
                }
                double temp = sum / HASH_TABLE_SIZE;
                double stdDev = Math.Sqrt(temp);
                Console.WriteLine($"{stdDev:F2}");
        }


        public void PrintComparions()
        {
            double averageComparison = (double)totalComparisons / totalGetOperations;
            Console.WriteLine($"Total comparisons: {totalComparisons}");
            Console.WriteLine($"Total Get operations: {totalGetOperations}");
            Console.WriteLine($"Average comparisons per Get: {averageComparison:F2}");

        }


    }

}

