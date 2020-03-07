using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // If no filename or more than one filenames are provided, throw exception
            if (args.Length == 0 ||  args.Length > 1)
            {
                throw new InvalidOperationException("Please provide valid filename");
            }

            ReadFileAndStartJourney(args[0]);

        }


        /// <summary>
        /// Read file and Parse the results.
        /// </summary>
        /// <param name="filename"></param>

        private static void ReadFileAndStartJourney(string filename)
        {
            List<string> journeys;
            try
            {
                journeys = File.ReadLines(filename).Where(x => !string.IsNullOrEmpty(x)).ToList();

            }
            catch (Exception)
            {
                throw new InvalidDataException("Invalid FileName");
            }
          
            // Loop through lines and read first 3 of them for Robot input.
            for (int i = 0; i < journeys.Count; i+=3)
            {
                // If it starts with 'O', consider it as an obstacle
                if (journeys[i].StartsWith("O"))
                {
                    var obstacle = journeys.Skip(i).Take(3).ToArray();
                    CreateObstacles(obstacle);
                    continue;
                }
                
                    var journey = journeys.Skip(i).Take(3).ToArray();
                    CreateRobot(journey);
            }

        }

        /// <summary>
        /// Create obstacles and save them.
        /// </summary>
        /// <param name="obstacles"></param>
        private static void CreateObstacles(string[] obstacles)
        {
            foreach(var obs in obstacles)
            {
                var coordinates = obs.Split(" ");
                Obstacles.Coordinates.Add(new Coordinate
                {
                    X = Convert.ToInt32(coordinates[1]),
                    Y = Convert.ToInt32(coordinates[2])
                });

            }
        }

        /// <summary>
        /// Create Robot
        /// </summary>
        /// <param name="journey"></param>
        private static void CreateRobot(string[] journey)
        {
            var initialCoordinates = journey[0];
            var commands = journey[1];
            var expectedResult = journey[2];


            var robot = InitializeRobot(initialCoordinates);
            var actualResult = robot.startJourney(commands);

            // If Crashed, do not compare results.
            if (actualResult.Contains("CRASHED"))
            {
                Console.WriteLine(actualResult);
                return;
            }
                

            // Compare results and Print response.
            if (expectedResult.Equals(actualResult))
            {
                Console.WriteLine("SUCCESS" + " " + actualResult);
            }else
            {
                Console.WriteLine("FAILURE" + " " + actualResult);
            }
        }

        /// <summary>
        /// Set initial coordinates and direction of Robot.
        /// </summary>
        /// <param name="initialCoordiantes"></param>
        /// <returns></returns>
        private static Robot InitializeRobot(string initialCoordiantes)
        {
            var currentPosition = initialCoordiantes.Split(" ");

            var coordinates = new Coordinate()
            {
                X = Convert.ToInt32(currentPosition[0]),
                Y = Convert.ToInt32(currentPosition[1])

            };

            var direction = char.Parse(currentPosition[2]);

            return new Robot(coordinates, direction);
         
        }
    }
}
