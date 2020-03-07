using System;
using System.ComponentModel;
using System.Linq;

namespace RobotApp
{
    public static  class Extensions
    {

        /// <summary>
        /// Get enum description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionFromEnumValue(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

    }
}
