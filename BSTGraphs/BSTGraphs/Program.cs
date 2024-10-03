using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;

namespace BSTGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\aaron\Desktop\magicitemsBST.txt";
            List<string> magicItems = new List<string>();

            try
            {
                //Passes file path and name to streamReader constructor 
                StreamReader sr = new StreamReader(filepath);

                using (sr)
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        //ignores white space and Caps
                        string lowerCase = line.ToLower();
                        string cleanLine = string.Concat(lowerCase.Where(c => char.IsLetterOrDigit(c)));

                        //adds lines into list 
                        if (!string.IsNullOrEmpty(cleanLine)) // Only add non-empty lines
                        {
                            magicItems.Add(cleanLine);
                            Console.WriteLine(cleanLine);
                        }
                        
                    }
                   
                }

            } catch (Exception e) {

                Console.WriteLine("Exception:" + e.Message);
            }

            Console.ReadLine();
        }
    }
}


