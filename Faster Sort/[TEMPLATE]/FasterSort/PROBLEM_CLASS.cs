using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE 

        //Your Code is Here:
        //==================
        /// <summary>
        /// Sort the given array in ascending order
        /// At least, should beat the default sorting algorithm of the C# (Array.Sort())
        /// </summary>
        /// <param name="arr"> array to be sorted in ascending order </param>
        /// <param name="N"> array size </param>
        /// <returns> sorted array </returns>
        /// 

        public static void insertSort(float[] arr, int b, int e)
        {
            for (int i = b + 1; i < e; ++i)
            {
                float val = arr[i];
                int j = i - 1;
                while (arr[j] > val && j > b)
                {
                    arr[j + 1] = arr[j];
                    --j;
                }
                if (j == b && arr[j] > val)
                {
                    arr[j + 1] = arr[j];
                    arr[j] = val;
                }
                else
                    arr[j + 1] = val;
            }
        }

        static float[] tmp;
        static void quickSort(float[] arr, int l, int r)
        {
            Stack<int> stk = new Stack<int>();
            int b, e;
            b = l;
            e = r;
            while (true)
            {
                int s = e - b;
                if (s <= 30)
                {
                    while (true)
                    {
                        if (e - b <= 16)
                            insertSort(arr, b, e);
                        else
                            Array.Sort(arr, b, e - b);
                        b = e;
                        if (stk.Count == 0)
                            return;
                        e = stk.Pop();
                    }
                }

                int pivot = b + (s - 1) * 2 / 5 + 4397 % (s / 3) - 1212 % (s / 5);
                float val = arr[pivot];
                float t = 0;
                int i = b, j = e - 1;

                while (true)
                {
                    while (arr[i] < val)
                        ++i;
                    while (arr[j] > val)
                        --j;
                    if (j > i)
                    {
                        if (arr[i] == arr[j])
                        {
                            ++i;
                            continue;
                        }
                        t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;

                        continue;
                    }
                    pivot = j;
                    break;

                }
                if (pivot + 2 < e)
                {
                    stk.Push(e);
                }
                e = pivot;
            }

        }

        static int fi(float[] arr, int b, int e)
        {
            for (int i = b + 1; i < e; ++i)
                if (arr[i] < arr[i - 1])
                    return i;
            return e;
        }

        static Boolean mergeSort(float[] arr, int b, int e, int d = 0, int fii = -1)
        {
            if (fii <= b)
                fii = fi(arr, b, e);
            if (fii >= e)
                return false;

            if (e - b < 2)
                return false;
            if (d > 2)
            {
                quickSort(arr, b, e);
                return false;
            }
            int m = (b + e) / 2;
            ++d;

            Parallel.Invoke(
                () =>
                {
                    if (fii < m)
                        mergeSort(arr, b, m, d, fii);
                },
                () =>
                {
                    mergeSort(arr, m, e, d, fii);
                }
                );
            int p1 = b, p2 = m;
            int i = b;

            while (true)
            {
                if (arr[p1] < arr[p2])
                {
                    tmp[i] = arr[p1];
                    ++i;
                    ++p1;
                    if (p1 == m)
                        break;
                }
                else
                {
                    tmp[i] = arr[p2];
                    ++i;
                    ++p2;
                    if (p2 == e)
                        break;
                }
            }
            while (p1 < m)
            {
                tmp[i] = arr[p1];
                ++p1;
                ++i;
            }
            while (p2 < e)
            {
                tmp[i] = arr[p2];
                ++p2;
                ++i;
            }
            if (d != 1)
                Array.Copy(tmp, b, arr, b, e - b);
            return true;
        }

        static public float[] RequiredFuntion(float[] arr, int N)
        {
            tmp = new float[N];
            if (mergeSort(arr, 0, N))
                return tmp;
            return arr;
        }
        #endregion
    }
}
