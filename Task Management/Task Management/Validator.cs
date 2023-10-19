using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Exceptions;

namespace Task_Management
{
    public static class Validator
    {
        public static void ValidateStringRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new InvalidUserInputException(message);
            }
        }

        public static void ValidateStringNotNullOrEmpty (string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidUserInputException(message);
            }
        }

        public static void ValidateRatingNotNegative(int value, string message)
        {
            if (value <= 0)
            {
                throw new InvalidUserInputException(message);
            }
        }
    }
}
