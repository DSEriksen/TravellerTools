using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversion.Models
{
    internal static class Modifiers
    {
        public static List<KeyValuePair<char, short>> StarportClasses
        {
            get
            {
                return new List<KeyValuePair<char, short>>
                    {
                        new('A', 2),
                        new('B', 1),
                        new('C', 0),
                        new('D', 0),
                        new('E', -1),
                        new('X', -3),
                    };
            }
        }

        public static List<KeyValuePair<string,short>> PopulationClasses
        {
            get
            {
                return new List<KeyValuePair<string, short>>
                {
                    new("1 or less", -4),
                    new("2-5", 0),
                    new("6-7", 2),
                    new("8 or more", 4)
                };
            }
        }

        public static List<KeyValuePair<string,short>> TechLevelClasses
        {
            get
            {
                return new List<KeyValuePair<string, short>>
                {
                    new("6 or less", -1),
                    new("7-8", 0),
                    new("9 or more", 2)
                };
            }
        }

        public static List<KeyValuePair<string, short>> SecurityZoneClasses
        {
            get
            {
                return new List<KeyValuePair<string, short>>
                {
                    new("Green", 0),
                    new("Amber", -2),
                    new("Red", -6)
                };
            }
        }
    }
}
