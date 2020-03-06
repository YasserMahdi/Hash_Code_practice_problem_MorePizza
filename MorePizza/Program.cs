using System;
using System.IO;
using System.Collections.Generic;

namespace MorePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] FirstLine = new string[2];
            int SizeOfArr = 0;
            int LineCounter = 0;
            int SlicesMaximum;
            string[] lines = File.ReadAllLines("b_small.txt");

            foreach (string line in lines)
            {
                FirstLine = line.Split(" ");
                SizeOfArr = Convert.ToInt32(FirstLine[1]);
                break;
            }

            string[] slice = new string[SizeOfArr];
            List<int> index = new List<int>();
            int selectedPizza = 0;
            Int32 max = 0;
            foreach (string line in lines)
            {
                LineCounter++;
                if (LineCounter > 1) { slice = line.Split(" "); }
            }

            SlicesMaximum = Convert.ToInt32(FirstLine[0]);
            for (int i = SizeOfArr - 1; i >= 0; i--)
            {
                if (max < SlicesMaximum)
                {
                    int NumOfSliceInOnePizza = Convert.ToInt32(slice[i]);
                    if (max + NumOfSliceInOnePizza < SlicesMaximum)
                    {
                        max += NumOfSliceInOnePizza;
                        index.Add(i);
                        selectedPizza++;
                    }

                }

            }

            index.Reverse();
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter
                (@"C:\Users\HP\source\repos\MorePizza\MorePizza\bin\Debug\netcoreapp2.1\b.txt"))
            {
                file.WriteLine(selectedPizza);
                foreach (int item in index)
                {
                    file.Write(item);
                    file.Write(" ");
                }
            }
        }
    }
}
