using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.RunningMedian
{
    public class Solution
    {
        public List<double> RunningMedian(int[] numbers)
        {
            var resultList = new List<double>();
            var list = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                list.Insert(0, numbers[i]);
                MaxHeapify(list, 0, list.Count - 1);
                var end = list.Count - 1;
                for (int j = 0; j <= list.Count / 2; j++)
                {
                    swap(list, 0, end);
                    end--;
                    MaxHeap(list, 0, end);
                }

                if (list.Count % 2 == 0)
                {
                    double result = (list[list.Count / 2 - 1] + list[list.Count / 2]) / 2.0;
                    resultList.Add(result);
                }
                else
                {
                    double result = list[(list.Count / 2)]/1.0;
                    resultList.Add(result);
                }
            }
            return resultList;
        }
        //private void MinHeapify(List<int> numbers, int start, int end)
        //{
        //    for (int i = (start + end) / 2; i >=0 ; i--)
        //    {
        //        MinHeap(numbers, i, end);
        //    }
        //}

        //private void MinHeap(List<int> numbers, int start, int end)
        //{
        //    int left = (2 * start) + 1;
        //    int right = (2 * start) + 2;
        //    int minElementIndex = start;
        //    if (left <= end && numbers[minElementIndex] > numbers[left])
        //        minElementIndex = left;
        //    if (right <= end && numbers[minElementIndex] > numbers[right])
        //        minElementIndex = right;

        //    if (minElementIndex != start)
        //    {
        //        swap(numbers, minElementIndex, start);
        //        MinHeap(numbers, minElementIndex, end);
        //    }
        //}

        private void MaxHeapify(List<int> numbers, int start, int end)
        {
            for (int i = (int)Math.Ceiling((start + end) / 2.0); i >= 0; i--)
            {
                MaxHeap(numbers, i, end);
            }
        }
        private void MaxHeap(List<int> numbers, int start, int end)
        {
            int left = (2 * start) + 1;
            int right = (2 * start) + 2;
            int largest = start;
            if (left <= end && numbers[largest] < numbers[left])
                largest = left;
            if (right <= end && numbers[largest] < numbers[right])
                largest = right;

            if (largest != start)
            {
                swap(numbers, largest, start);
                MaxHeap(numbers, largest, end);
            }
        }
        private void swap(List<int> numbers, int i, int j)
        {
            var temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
