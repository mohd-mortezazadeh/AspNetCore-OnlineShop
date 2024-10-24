using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace Infrastructure.Utils
{
    public static class NumberUtils
    {
        public static int GetFirstLackNumber(List<int> listNumber)
        {
            int number=1;
            int index=0;
            if (listNumber.Count>0)
            {
                while(number ==listNumber[index] || listNumber.Where(s=>s==number).Count()>0)
                {
                    number++;
                    index++;
                }
            }

            return number;
        }

        public static string GetFirstLackNumberStr(List<string> listNumber)
        {
            int number = 1;
            int index = 0;

            if (listNumber.Count > 0)
            {
                while (
                        index < listNumber.Count &&
                       (number.ToString() == listNumber[index] || listNumber.Where(s => s == number.ToString()).Count() > 0)
                    )
                {
                    number++;
                    index++;
                }
            }

            return number.ToString();
        }
        public static int RandomNumber(int firstNumber,int lastNumber )
        {
            int number;

            Random rnd = new Random();
            number = rnd.Next(firstNumber, lastNumber);  // creates a number between firstNumber and lastNumber

            return number;
        }

    }
}