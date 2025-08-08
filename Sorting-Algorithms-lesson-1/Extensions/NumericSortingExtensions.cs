using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms_lesson_1.Extensions
{
    public static class NumericSortingExtensions
    {
        static void BubbleSort<T>(this T[] array)  where T : INumber<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                { 
                    if (array[j] > array[j + 1])
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}
