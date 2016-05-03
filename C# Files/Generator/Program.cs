using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    
    class Program
    {
        public static float[] sequence;
        public static float[] start;
        public static int max = 10000;
        static void Main(string[] args)
        {
            int passes=0;
            Random Rand;
            int seed;

            Console.WriteLine("Enter the seed:");
            seed = Convert.ToInt32(Console.Read());

            Rand = new Random(seed);
            start = new float[5];
            sequence = new float[max];
            do
            {
                sequence[passes] = Rand.Next(max) / (float)max;
                //Console.WriteLine(sequence[passes]);
                if (passes < 5)
                    start[passes] = sequence[passes];
                passes += 1;
                if (passes > max - 1) {
                    Console.WriteLine("No repeat occured");
                    seed = -2353;
                    break; 
                }
            } while (checkrepeat(passes-1) == false);
            if (seed != -2353) {
                Console.WriteLine("A repeat occured at " +(passes - 5));
            }
            Console.ReadLine();
            Console.WriteLine("Outputting to file");
            Output();
        }
        public static void Output() {
            //Split array to X & Y
            //System.IO.File.WriteAllText(@"G:\Y2 S2 LABS\Monte Carlo\Output1.txt", string.Empty);
            System.IO.File.WriteAllText(@"F:\Development\Monte Carlo\Output1.txt", string.Empty);
            
            for (int k = 0; k < max; k += 2)
            {
                //Console.Write("X: " + (sequence[k] / 256));
                //Console.WriteLine("   Y: " + (sequence[k + 1] / max));

                using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(@"G:\Y2 S2 LABS\Monte Carlo\Output1.txt", true))
                    new System.IO.StreamWriter(@"F:\Development\Monte Carlo\Output1.txt", true))
                {
                    file.WriteLine(sequence[k] + " " + sequence[k + 1]);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Data successfully outputed to Output1.txt");
            Console.Read();
        }
        public static bool checkrepeat(int n){
            float[] current = new float[5];
            for (int i = 0; i < 5; i++) {
                current[i] = sequence[n];
            }
            if(Enumerable.Equals(start,current))return true;else return false;
        }
    
    }
}
