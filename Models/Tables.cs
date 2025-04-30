using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversion.Models
{
    internal static class Tables
    {

        /// <summary>
        /// Lookup table for Freight Traffic. Key = Dice roll after modifiers, value = lots.
        /// Dice roll cannot be lower than 1 or higher than 20.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, int> FreightTraffic()
        {
            return new Dictionary<int, int>
                {
                    {1, 0},
                    {2, 1},
                    {3, 1},
                    {4, 2},
                    {5, 2},
                    {6, 3},
                    {7, 3},
                    {8, 3},
                    {9, 4},
                    {10, 4},
                    {11, 4},
                    {12, 5},
                    {13, 5},
                    {14, 5},
                    {15, 6},
                    {16, 6},
                    {17, 7},
                    {18, 8},
                    {19, 9},
                    {20, 10}
                };

        }

        /// <summary>
        /// Lookup table for Passage rules. Key = Parsecs travelled, value = credits earned.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, int> Passage()
        {
            return new Dictionary<int, int>
            {
                {1, 1000 },
                {2, 1600 },
                {3, 2600 },
                {4, 4400 },
                {5, 8500 },
                {6, 32000 }
            };
        }
    }
}
