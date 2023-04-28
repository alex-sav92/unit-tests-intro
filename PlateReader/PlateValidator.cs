using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateReader
{
    public class PlateValidator
    {
        public bool IsValid(string plate)
        {
            var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var counties = new string[] { "BC", "IS", "CT", "BT", "B" };

            if (plate.IndexOfAny(numbers) < 0)
            {
                return false;
            }

            var firstDigit = plate.IndexOfAny(numbers);
            var lastDigit = plate.LastIndexOfAny(numbers);

            var number = plate.Substring(firstDigit, lastDigit - firstDigit + 1);
            if (!int.TryParse(number, out int num))
            {
                return false;
            }

            var county = plate.Substring(0, firstDigit);
            var custom = plate.Substring(lastDigit + 1);

            if (custom.Length != 3)
            {
                return false;
            }
            if (custom.Any(c => !c.IsLetter()))
            {
                return false;
            }

            if (!counties.Any(c => c == county)) 
            {
                return false; 
            }
            if (number.Length != 2)
            {
                if (county == "B" && number.Length == 3)
                { 
                    return true; 
                }

                return false;
            }

            return true;
        }
    }

    public static class Utils
    {
        public static bool IsLetter(this char c) 
        {
            var alf = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alf.Contains(c);
        }
    }
}
