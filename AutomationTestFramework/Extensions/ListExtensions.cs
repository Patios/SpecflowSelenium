using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTestFramework.Extensions
{
    public static class ListExtensions
    {
        public static T Random<T>(this List<T> input)
        {
            return input.ElementAt(new Random().Next(input.Count));
        }
    }
}