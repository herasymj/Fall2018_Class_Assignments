/*
 * Assignment 1
 * CS 350
 * Jennifer Herasymuik
 * 200352062
 * 
 * The purpose of this application is to implement the quicksort
 *      both recursively and iteratively.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    class Program
    {
        /*
         * Main functions that will run both sorts and return results to console.
         * Will call both the iterative quick sort and the recursive one.
         */
        static void Main(string[] args)
        {
            //set the list to 100 random numbers
            List<int> numList = resetList();
            System.Console.WriteLine("Welcome to Jennifer Herasymuik's Assignment 1.");
            System.Console.WriteLine("Here we will use quicksort both recursively, and iteratively.");
            System.Console.WriteLine("");
            System.Console.WriteLine("Randomizing list with 100 random integers...");

            //print out the list values
            System.Console.WriteLine("Values: ");
            print(numList);

            //quicksort the recursive way
            System.Console.WriteLine("Sorting recursively...");
            recursiveQuickSort(numList, 0, 99);

            //print newly sorted list
            System.Console.WriteLine("Recursively sorted list: ");
            print(numList);

            //reset list to another 100 random numbers
            System.Console.WriteLine("Randomizing list with another 100 random integers...");
            System.Console.WriteLine("New list: ");
            numList = resetList();
            print(numList);

            //quicksort iteratively
            System.Console.WriteLine("Sorting iteratively.");
            iterativeQuickSort(numList);

            //print new list of integers
            System.Console.WriteLine("Sorted list:");
            print(numList);

            //tell user to insert any value to quit
            System.Console.WriteLine("Type in any values to quit...");
            Console.ReadKey();
        }

        /*
         * Prints out the list
         */
        public static void print(List<int> list){
            foreach (var item in list)
            {
                System.Console.Write(" " + item + " ");
            }

            System.Console.WriteLine(" ");
        }

        /*
         * listReset
         * 
         * Resets all of the values of the list to random numbers
         */
        public static List<int> resetList()
        {
            var newList = new List<int>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                newList.Add(random.Next(0, 1000));
            }

            return newList;
        }

        /*
         * recursiveQuickSort
         * 
         * Purpose: The prupose of this function is to implement the quicksort
         *      algorithm recursively.
         * Inputs:
         *      list: an array of unsorted integers
         * Returns: returns an integer array of sorted integers
         * 
         * Algorithm adapted from http://snipd.net/quicksort-in-c 
         */
        public static void recursiveQuickSort(List<int> list, int lowVal, int highVal)
        {
            int left = lowVal;
            int right = highVal;
            int pivot = list[(lowVal + highVal) / 2];

            while (left <= right)
            {
                while (list[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (list[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    int temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;

                    left++;
                    right--;
                }
            }

            if (lowVal < right)
            {
                recursiveQuickSort(list, lowVal, right);
            }

            if (left < highVal)
            {
                recursiveQuickSort(list, left, highVal);
            }
        }


        /*
         * iterativeQuickSort
         * 
         * Purpose: The prupose of this function is to implement the quicksort
         *      algorithm iteratively.
         * Inputs:
         *      list: an array of unsorted integers
         * Returns: returns an integer array of sorted integers
         * 
         * Algortihm adapted from https://javarevisited.blogspot.com/2016/09/iterative-quicksort-example-in-java-without-recursion.html
         */
        public static void iterativeQuickSort(List<int> list)
        {
            Stack<int> sortStack = new Stack<int>();
            int right = 99;
            int left = 0;
            sortStack.Push(left);
            sortStack.Push(right);

            while (sortStack.Count != 0)
            {
                right = sortStack.Pop();
                left = sortStack.Pop();

                //partition
                int partition = 0;
                int temp = 0;
                int index = left - 1;
                int pivot = list[right];
                for (int i = left; i <= right - 1; i++)
                {
                    if (list[i] <= pivot)
                    {
                        index++;
                        temp = list[index];
                        list[index] = list[i];
                        list[i] = temp;
                    }
                }

                //swap
                partition = index + 1;
                temp = list[partition];
                list[partition] = list[right];
                list[right] = temp;

                if (partition - 1 > left)
                {
                    sortStack.Push(left);
                    sortStack.Push(partition - 1);
                }
                if (partition + 1 < right)
                {
                    sortStack.Push(partition + 1);
                    sortStack.Push(right);
                }
            }
        }
    }
}
