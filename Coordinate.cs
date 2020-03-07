namespace RobotApp
{
    /// <summary>
    /// Represent coordinates of Robot.
    /// </summary>
    public class Coordinate
    {

        /// <summary>
        /// X-Axis
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-Axis
        /// </summary>
        public int Y { get; set; }


        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
