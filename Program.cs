using System;

namespace Coding_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine;
            string[] inputs;
            int width;
            int height;
            int xInitialCoordinate;
            int yInitialCoordinate;
            string commandLine;
            char orientation;

            //User inputs

            Console.WriteLine("Enter dimensions of the square (width x height) ");
            Console.WriteLine("Examples:");
            Console.WriteLine("3 3");
            Console.WriteLine("32 1");
            Console.WriteLine("12 55 \n");
            inputLine = Console.ReadLine();
            inputs = inputLine.Split(' ');
            width = Convert.ToInt32(inputs[0]);
            height = Convert.ToInt32(inputs[1]);

            Console.WriteLine("Enter coordinate and initial orientation");
            Console.WriteLine("Examples:");
            Console.WriteLine("0 0 N");
            Console.WriteLine("1 2 S");
            inputLine = Console.ReadLine();
            inputs = inputLine.Split(' ');
            xInitialCoordinate = Convert.ToInt32(inputs[0]);
            yInitialCoordinate = Convert.ToInt32(inputs[1]);
            orientation = inputs[2][0];


            Console.WriteLine("Enter command line");
            Console.WriteLine("Examples");
            Console.WriteLine("AALAARALA \n");
            commandLine = Console.ReadLine();


        }

    }
}
