using System;
using System.Linq;
using System.Collections.Generic;

namespace randomTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] a = new int[] { };
            // a = a.Concat(new int[] { 1, 3, 0, 10, 7, 25 }).ToArray();
            int nb = 1000000;
            List<int> unsortedListInteger = new List<int>();
            Random rnd = new Random();
            System.Diagnostics.Stopwatch dog = new System.Diagnostics.Stopwatch();
            dog.Start();
            for (int j = 0; j < nb; j++)
            {
                unsortedListInteger.Add(rnd.Next( 0, 100));
            }
            unsortedListInteger = MergeSort(unsortedListInteger);
            dog.Stop();

           
            //Console.WriteLine(string.Join((char)32, unsortedListInteger ));
            
            Console.WriteLine("Elapsed time in ms :: " + dog.ElapsedMilliseconds);
            dog.Reset();
            dog.Start();
            List<double> unsortedListDouble = new List<double>();
           
            for(int j = 0; j<nb; j++)
            {
                unsortedListDouble.Add(rnd.NextDouble() * 100);
            }
            unsortedListDouble = Merge2(unsortedListDouble);
            dog.Stop();
            //Console.WriteLine(string.Join((char)32, unsortedListDouble));
            
            Console.WriteLine("Elapsed time in ms :: " + dog.ElapsedMilliseconds);
        }



            private static List<int> MergeSort(List<int> unsorted)
            {
                if (unsorted.Count <= 1)
                    return unsorted;

                List<int> left = new List<int>();
                List<int> right = new List<int>();

                int middle = unsorted.Count / 2;
                for (int i = 0; i < middle; i++)  //Dividing the unsorted list
                {
                    left.Add(unsorted[i]);
                }
                for (int i = middle; i < unsorted.Count; i++)
                {
                    right.Add(unsorted[i]);
                }

                left = MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);
            }

            private static List<int> Merge(List<int> left, List<int> right)
            {
                List<int> result = new List<int>();

                while (left.Count > 0 || right.Count > 0)
                {
                    if (left.Count > 0 && right.Count > 0)
                    {
                        if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                        {
                            result.Add(left.First());
                            left.Remove(left.First());      //Rest of the list minus the first element
                        }
                        else
                        {
                            result.Add(right.First());
                            right.Remove(right.First());
                        }
                    }
                    else if (left.Count > 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else if (right.Count > 0)
                    {
                        result.Add(right.First());

                        right.Remove(right.First());
                    }
                }
                return result;
            }


        private static List<double> Merge2(List<double> unsorted)
        {
            List<double> left = new List<double>();
            List<double> right = new List<double>();

            if(unsorted.Count <=1)
            {
                return unsorted;
            }
            int n = unsorted.Count;
            int middle = n / 2;

            for(int i = 0; i<middle; i++)
            {
                left.Add(unsorted[i]);
                right.Add(unsorted[n - i - 1]);
            }
            left = Merge2(left);
            right = Merge2(right);
            
            return MergeSort2(left, right);


        }

        private static List<double> MergeSort2(List<double> left, List<double> right)
        {
            List<double> result = new List<double>();

            while(left.Count >=1 || right.Count >= 1)
            {
                if(left.Count>=1 && right.Count >= 1)
                {
                    if (left[0] < right[0]) { result.Add(left[0]); left.Remove(left[0]); }
                    else { result.Add(right[0]); right.Remove(right[0]); }
                }

               else if (left.Count >= 1)
                {
                    result.Add(left[0]); left.Remove(left[0]);
                }
                else if(right.Count >= 1)
                {
                        result.Add(right[0]); right.Remove(right[0]);
                }



            }

            return result;
        }


}
}
