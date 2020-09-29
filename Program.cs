using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

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
            int int_orientation;
            (int,int) currentPosition;

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
            int_orientation = getOrientationToInt(inputs[2][0]);

            Console.WriteLine(int_orientation);

            Console.WriteLine("Enter command line");
            Console.WriteLine("Examples");
            Console.WriteLine("AALAARALA \n");
            commandLine = Console.ReadLine();

            //Movement calculation

            currentPosition = (xInitialCoordinate, yInitialCoordinate);
            foreach (char command in commandLine)
            {
                switch (command)
                {
                    case 'A':
                        currentPosition = advance(int_orientation, currentPosition);
                        break;
                    case 'L':
                        int_orientation -= 1;
                        if (int_orientation == 0)
                            int_orientation = 4;
                        break;
                    case 'R':
                        int_orientation += 1;
                        if (int_orientation == 5)
                            int_orientation = 1;
                        break;
                    default:
                        //Will never enter here
                        break;
                }

                if (!checkPosition(width, height, currentPosition))
                {
                    Console.WriteLine("False");
                    Environment.Exit(0);
                }
                    
            }
            Console.WriteLine("True," + getOrientationToChar(int_orientation)  + ",({0},{1})",currentPosition.Item1,currentPosition.Item2);

        }

        private static int getOrientationToInt(char orientation)
        {
            switch (orientation)
            {
                case 'N':
                    return 1;
                case 'E':
                    return 2;
                case 'S':
                    return 3;
                case 'W':
                    return 4;
                default:
                    return -1;
            }
        }

        private static char getOrientationToChar(int orientation)
        {
            switch (orientation)
            {
                case 1:
                    return 'N';
                case 2:
                    return 'E';
                case 3:
                    return 'S';
                case 4:
                    return 'w';
                default:
                    return 'X';
            }
        }

        private static (int,int) advance(int orientation, (int,int) currentPosition)
        {
            switch(orientation)
            {
                case 1:       // North                    
                    return (currentPosition.Item1,currentPosition.Item2 + 1);
                case 2:       // East
                    return (currentPosition.Item1 + 1 , currentPosition.Item2);
                case 3:       // South
                    return (currentPosition.Item1, currentPosition.Item2 - 1);
                case 4:       // West
                    return (currentPosition.Item1 - 1, currentPosition.Item2);
                default:
                    return (-1,-1);
            }
        }

        private static bool checkPosition (int w, int h, (int,int) currentPostion)
        {
            if (currentPostion.Item1 >= w || currentPostion.Item1 < 0)
                return false;
            if (currentPostion.Item2 >= h || currentPostion.Item2 < 0)
                return false;

            return true;
        }
    }
}
