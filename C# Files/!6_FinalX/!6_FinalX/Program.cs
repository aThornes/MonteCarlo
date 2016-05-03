﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_FinalX
{
    class Program
    {
        public static int max = 10000;
        public static double[] sX, sY, sR;
        public static double[] maxX;
        public static int trials, passes, runs;

        static void Main(string[] args)
        {
            double delX, delY;
            double x = 0;
            double y = 0;
            double R = 0;

            trials = 100;
            passes = 10000;
            runs = 10000;

            sX = new double[10000];
            sY = new double[10000];
            sR = new double[10000];
            maxX = new double[10000];
            Random rand;
            int seed;
            Console.WriteLine("Enter seed");
            seed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customise number of passes? (1 for yes, anything else for no)");
            if (Console.ReadLine() == "1")
            {
                //Console.WriteLine("How many trails?");
                //trials = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many passes?");
                passes = Convert.ToInt32(Console.ReadLine());
            }
            rand = new Random(seed);
            Console.WriteLine("Calculating...");
            for (int n = 0; n < runs; n++)
            {
                for (int j = 0; j < trials; j++) //Average over x trials
                {
                    x = 0; y = 0; R = 0;
                    for (int i = 0; i < passes; i++)
                    {
                        //theta = ((rand.Next(max) / (double)max) * 2 * Math.PI);
                        delX = ((rand.Next(max) / (double)max) * 2 * Math.Pow(2, 0.5)) - Math.Pow(2, 0.5);
                        delY = ((rand.Next(max) / (double)max) * 2 * Math.Pow(2, 0.5)) - Math.Pow(2, 0.5);
                        sX[i] += delX;
                        sY[i] += delY;

                        R = Math.Pow((Math.Pow(x, 2) + Math.Pow(y, 2)), 0.5); //Calculate distance
                        sR[i] += R;
                    }
                }
                maxX[n] = sX[passes - 1] / passes;
            }
            Console.WriteLine("Output to a file?(1 for yes, anything else for no)");
            if (Console.ReadLine() == "1")
                Output();
        }

        // -- Print file (ONLY WORKS ON UNIVERSITY COMPUTERS)
        public static void Output()
        {
            //Split array to X & Y
            System.IO.File.WriteAllText(@"F:\Development\Monte Carlo\Output2.txt", string.Empty);
            for (int k = 0; k < runs; k++)
            {
                using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(@"F:\Development\Monte Carlo\Output2.txt", true))
                {
                    file.WriteLine(passes + " " + maxX[k]);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Data successfully outputed to Output2.txt");
            Console.Read();
        }

    }


}