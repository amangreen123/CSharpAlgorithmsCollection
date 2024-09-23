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

        private const int HASH_TABLE_SIZE = 250;
        public Queue[] table = new Queue[HASH_TABLE_SIZE];

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

            public static void analyzeHashValues(int[] hashvalues)
            {
                int asteriskCount = 0;
                int [] bucketCount = new int [HASH_TABLE_SIZE];
                int totalCount = 0;
                int arrayIndex = 0;
                int lineinFile = 666;

            Console.WriteLine("HashTable Usage");

            Array.Sort(hashvalues);


            for (int i = 0; i < HASH_TABLE_SIZE; i++)
            {
                bucketCount[i] = hashvalues[i];
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

        public void addHash (string item)
        {
            int hash = makeHashCode(item);
            table[hash].Enqueue(item);
        }

       
    }

}

