using System.ComponentModel;

namespace RobotApp
{
    public enum Command
    {
        [Description("F")]
        Forward,

        [Description("L")]
        Left,

        [Description("R")]
        Right
        
    }
}
