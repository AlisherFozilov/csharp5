using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1,2,3,4,5};
      
            Console.WriteLine("array is");
            print(array);
            var lastElement = ArrayHelper.Pop(ref array);
            Console.WriteLine($"last element is: {lastElement}");
            Console.WriteLine("array is");
            print(array);

            var newSize = ArrayHelper.Push(ref array, 123);
            Console.WriteLine($"new size is {newSize}");
            Console.WriteLine("array is");
            print(array);

            var firstElement = ArrayHelper.Shift(ref array);
            Console.WriteLine($"new size is {array.Length}");
            Console.WriteLine("array is");
            print(array);

            newSize = ArrayHelper.UnShift(ref array, 321);
            Console.WriteLine($"new size is {array.Length}");
            Console.WriteLine("array is");
            print(array);
        }

        static void print<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        

        static class ArrayHelper
        {
            static public T Pop<T>(ref T[] array)
            {
                if (array.Length < 1) {
                    throw new ArgumentException();
                }
                var newSize = array.Length-1;
                var newArray = new T[newSize];
                var lastElement = array[array.Length-1];
                
                Array.Copy(array, newArray, newSize);
                array = newArray;
                return lastElement;
            }

            static public int Push<T>(ref T[] array, T elem)
            {
                var newSize = array.Length+1;
                var newArray = new T[newSize];
                Array.Copy(array, newArray, array.Length);
                
                newArray[newSize-1] = elem;
                array = newArray;
                return newSize;
            }

            static public T Shift<T>(ref T[] array)
            {
                if (array.Length < 1) {
                    throw new ArgumentException();
                }
                var newSize = array.Length-1;
                var newArray = new T[newSize];
                var firstElement = array[0];
                
                Array.Copy(array, 1, newArray, 0, newSize);
                array = newArray;
                return firstElement;
            }

            static public int UnShift<T>(ref T[] array, T elem)
            {
                if (array.Length < 1) {
                    throw new ArgumentException();
                }
                var newSize = array.Length+1;
                var newArray = new T[newSize];
                
                newArray[0] = elem;
                Array.Copy(array, 0, newArray, 1, array.Length);
                array = newArray;
                return newSize;
            }
        }
    }
}
