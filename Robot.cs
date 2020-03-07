using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotApp
{
    public class Robot
    {
        #region Private Properties

        private List<char> TurningCommands = new List<char> { 'R', 'L' };

        private Dictionary<char, char> DirectionsOnTurningRight = new Dictionary<char, char>
        {
            { 'E', 'S'},
            { 'S', 'W'},
            { 'W', 'N'},
            { 'N', 'E'}
        };

        private Dictionary<char, char> DirectionsOnTurningLeft = new Dictionary<char, char>
        {
            { 'E', 'N'},
            { 'N', 'W'},
            { 'W', 'S'},
            { 'S', 'E'}
        };


        private string Response { get; set; }

        #endregion Private Properties

        public Coordinate Coordinates { get; set; }

        public char Direction { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="Robot"/> class.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="direction"></param>
        public Robot(Coordinate coordinates, char direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }


        /// <summary>
        /// Start Journey and execute commands.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string startJourney(string command)
        {

           
            var commands = command.ToCharArray();
            foreach(var cmd in commands)
            {
                // Update direction of Robot.
                if (TurningCommands.Contains(cmd))
                {
                    UpdateDirection(cmd);
                }
                else
                {
                    // Update Coordinates if command is 'F' i.e move forward
                    if (IsCrashed())
                        return Response;

                    UpdateCoordinates();
                }

               

            }


            Response = Coordinates.ToString() + " " + Direction.ToString();
            return Response;
        }

        private bool IsCrashed()
        {
           if (Obstacles.Coordinates.Any(x => x.X == Coordinates.X && x.Y == Coordinates.Y))
            {
                Response = "CRASHED" + " " +  Coordinates.ToString();
                return true;
            }


            return false;
        }


        /// <summary>
        /// Update coordinates based on <see cref="Direction"/>
        /// </summary>
        private void UpdateCoordinates()
        {
            switch (Direction)
            {
                case 'S':
                    Coordinates.X--;
                    break;
                case 'N':
                    Coordinates.X++;
                    break;

                case 'E':
                    Coordinates.Y--;
                    break;

                case 'W':
                    Coordinates.Y++;
                    break;

                default:
                    throw new InvalidOperationException("Invalid Direction Provided!!!");
            }
        }


        /// <summary>
        /// Update <see cref="Direction"/> based on Turning commands
        /// </summary>
        /// <param name="cmd"></param>
        private void UpdateDirection(char cmd)
        {
            var currentDirection = Direction;
           Direction = cmd == 'R'
                        ? DirectionsOnTurningRight[currentDirection]
                        : DirectionsOnTurningLeft[currentDirection];
        }
    }
}
