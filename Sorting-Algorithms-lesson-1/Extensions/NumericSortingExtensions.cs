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
        public static void BubbleSort<T>(this T[] array) where T : INumber<T>
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

        public static async Task MergeSortParallel<T>(this T[] array) where T : INumber<T>
        {
            if (array == null || array.Length <= 1)
                return;

            int mid = array.Length / 2;                 // Выделяем центр для разделения массива

            /*          Запускаем в разных потоках из пула          */
            await Task.WhenAll(
                Task.Run(() => Separation(array, 0, mid - 1)),
                Task.Run(() => Separation(array, mid, array.Length - 1)));

            Merge<T>(array, 0, mid, array.Length - 1);  // И запускаем последнюю "сортировку"
        }

        private static void Separation<T>(T[] array, int left, int right) where T : INumber<T>
        {
            /*          Базовый случай рекурсии         */
            if (left >= right)
            {
                return;
            }

            int mid = left + (right - left) / 2;    // В каждом фрейме делим пополам

            /*          Рекурсивный случай          */
            Separation(array, left, mid);
            Separation(array, mid + 1, right);

            /*          Запускаем "сортировку"        */
            Merge<T>(array, left, mid, right);
        }

        private static void Merge<T>(T[] array, int left, int mid, int right) where T : INumber<T>
        {
            int i = left;       // Указатель левой части
            int j = mid + 1;    // Указатель правой части
            T[] allocator = new T[right - left + 1];    // Массив - временное хранилище
            int indexAllocator = 0;                     // Указатель этого массива

            /*          Собственно слияние          */
            while (i <= mid && j <= right)
            {
                if (array[i] > array[j])
                    allocator[indexAllocator++] = array[j++];
                else
                    allocator[indexAllocator++] = array[i++];
            }

            /*          Пропущенные элементы добавляем в конец хранилища            */
            while (i <= mid)
                allocator[indexAllocator++] = array[i++];

            while (j <= right)
                allocator[indexAllocator++] = array[j++];

            /*          Возвращаем отсортированную последовательность в изначальный массив          */
            for (i = 0; i < allocator.Length; i++)
                array[left + i] = allocator[i];
        }


        public static void QuickSort<T>(this T[] array) where T : INumber<T>
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length < 2) return;

            Divide(array, 0, array.Length - 1);
        }

        private static void Divide<T>(T[] array, int left, int right) where T : INumber<T>
        {
            /*          Базовый случай рекурсии          */
            if (left >= right)
                return; 

            /*          Указатели и pivot           */
            int i = left;
            int j = right;
            T pivot = array[left + ((right - left) >> 1)];

            /*          Разделение по Хоару         */
            while (i <= j)
            {
                /*          Двигаем указатели при "правильном" расположении элементов           */
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);    // Меняем местами элементы относительно                                             
                    i++;                                            // pivot (мЕньшие - слева, бОльшие - справа)
                    j--;
                }
            }

            /*          Рекурсивный случай          */
            Divide(array, left, j);
            Divide(array, i, right);
        }
    }
}
