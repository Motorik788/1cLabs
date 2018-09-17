using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp2
{
    public static class ArrayRndExt
    {
        public static void FillRnd(this int[] vs, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = random.Next(min, max);
            }
        }
    }


    class Program
    {       
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }


        static long Segment(int[] arr, int segCount)
        {
            long summ = 0;
            var lenSeg = arr.Length / segCount;
            var indexPartStart = 0;
            for (int i = 1; i <= segCount; i++)
            {
                summ += summPart(i, indexPartStart);
                indexPartStart += lenSeg;
            }

            return summ;

            long summPart(int segment, int indexStart)
            {
                long sumPart = 0;
                var indexEnd = indexStart + lenSeg;
                var len = segment == segCount && arr.Length - indexEnd > 0 ? indexEnd + (arr.Length - indexEnd) : indexEnd;
                for (int i = indexStart; i < len; i++)
                    sumPart += arr[i];

                return sumPart;
            }
        }

        static long Simple(int[] arr)
        {
            long summ = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                summ += arr[i];
            }

            return summ;
        }


        static long Pyramid(int[] arr)
        {
            long PyramPart(int a, int b)
            {

                if (b - a > 1)
                {
                    var r1 = PyramPart(a, (a + b) / 2);
                    var r2 = PyramPart((a + b) / 2, b);
                    return r1 + r2;
                }

                return arr[a];
            }

            return PyramPart(0, arr.Length);
        }

        static long Group(int[] arr)
        {
            long summ = 0;

            return summ;
        }



        static void Main(string[] args)
        {


            var arr = new int[10000];
            arr.FillRnd(1, 10);
            // PrintArray(arr);
            Console.WriteLine(Simple(arr));
            Console.WriteLine(Segment(arr, 4));
            Console.WriteLine(Pyramid(arr));

            
            Console.ReadKey();
        }
    }

}
