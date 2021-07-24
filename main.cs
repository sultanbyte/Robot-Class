using System;
using System.Collections;
using System.IO;


namespace RobotMain
{
    class MainClass
    {
        static string filename = @"/grid.txt";

        public static void Main()
        {       
            // Read the grid from file
            String input = File.ReadAllText(filename);

            int i = 0, j = 0;
            int[,] grid = new int[11, 11];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    grid[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }

            ArrayList robots = new ArrayList();

            robots.Add(new Robot(grid));
            robots.Add(new RotRobot(grid));
            robots.Add(new TranRobot(grid));


            System.Console.WriteLine("Initial positions of the robots:");
            foreach (Robot r in robots)
            {
                System.Console.Write(r.getXPosition());
                System.Console.Write(", ");
                System.Console.WriteLine(r.getYPosition());
            }


            System.Console.WriteLine("Testing functionality of move function from parent class on all robots:");
            foreach (Robot r in robots)
            {
                r.Move();
                System.Console.Write(r.getXPosition());
                System.Console.Write(", ");
                System.Console.WriteLine(r.getYPosition());
            }


            System.Console.WriteLine("Testing the rotating robot by rotating to the right: ");
            foreach (Robot r in robots)
            {
                if (r.GetType() == typeof(RotRobot))
                {       
                    RotRobot robo = (RotRobot)r;
                    robo.Move();

                    //Demonstarting a left rotation
                    robo.Rotate("LEFT");

                    robo.Move();

                    System.Console.WriteLine("Current cordinates of rotating robot");
                    System.Console.Write(r.getXPosition());
                    System.Console.Write(", ");
                    System.Console.WriteLine(r.getYPosition());                
                }
            }



            System.Console.WriteLine("Testing the translating robot by translating to the left");
            foreach (Robot r in robots)
            {
                if (r.GetType() == typeof(TranRobot))
                {
                    TranRobot robo = (TranRobot)r;
                    robo.Move();

                    //Demonstrating a left translation
                    robo.Left();

                    System.Console.WriteLine("Current cordinates of translating robot");
                    System.Console.Write(r.getXPosition());
                    System.Console.Write(", ");
                    System.Console.WriteLine(r.getYPosition());
                }
            }
        }
    }
}