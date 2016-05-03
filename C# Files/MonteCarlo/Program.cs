using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {

        public static float[] start = new float[6];
        public static float[] current = new float[6];
        public static float[] sequence = new float[256];



        public static int passes;
        static void Main(string[] args)
        {
            string input;
            passes = 0;
            int seed = -1;
            int a = 57;
            int c = 1;
            int M = 256;            
            float random, prev;
            do
            {
                seed = -1;
                Console.WriteLine("Enter a numerical seed, between 0 & " + M);
                input = Console.ReadLine();
                try { seed = Convert.ToInt32(input); }
                catch
                {
                    Console.WriteLine("Invalid entry!");
                    seed = -52941;
                    Thread.Sleep(500);
                    Console.Clear();
                }

                if ((seed < 0 || seed > M) && seed != -52941)
                {
                    Console.WriteLine("Out of range! Please try again");
                    Thread.Sleep(500);
                    Console.Clear();
                }

            } while (seed < 0 || seed > M);
            prev = seed;

            do
            {
                random = ((a * prev) + c) % M;
                if (checkArrays(passes, random, prev) == true)
                {
                    break;
                }
                prev = random;
                Console.WriteLine(random / M);
                passes += 1;
            } while (passes > 0);
            Console.WriteLine("");
            Console.Write("There were " + (passes - 5));
            Console.WriteLine(" numbers generated before a repeat occured");
            Console.WriteLine("");            
            Console.WriteLine("Press enter to output");
            Console.ReadLine();

            Output();
        }

        public static void Output() { 
            //Split array to X & Y
            System.IO.File.WriteAllText(@"G:\Y2 S2 LABS\Monte Carlo\Output.txt", string.Empty);
            for (int k = 0; k < 256; k+=2) {
                Console.Write("X: " + (sequence[k]/256));
                Console.WriteLine("   Y: " + (sequence[k + 1]/256));

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"G:\Y2 S2 LABS\Monte Carlo\Output.txt", true))
                {
                    file.WriteLine(sequence[k] / 256 + " " + sequence[k+1] / 256);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Output successfully outputed to Output.txt");
            Console.Read();
        }



        public static bool checkArrays(int i, float pre, float cur)
        {
            int n = 0;
            if (i < 256)
                sequence[i] = cur;
            if (i < 6)
            {
                start[i] = cur;
            }
            else
            {
                for (n = 0; n <= 4; n++)
                {
                    current[n] = current[n + 1];
                }
                current[5] = cur;
            }

            if (Enumerable.SequenceEqual(start, current))
                return true;
            else
                return false;
        }
    }
}


