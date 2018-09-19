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
            recursiveQuickSort(numList, numList[0], numList[99]);

            //print newly sorted list
            System.Console.WriteLine("Recursively sorted list: ");
            print(numList);

            //reset list to another 100 random numbers
            System.Console.WriteLine("Randomizing list with another 100 random integers...");
            System.Console.WriteLine("New list: ");
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
         * Algorithm adapted from https://www.geeksforgeeks.org/quick-sort/
         */
        public static List<int> recursiveQuickSort(List<int> list, int lowVal, int highVal)
        {
            if (lowVal < highVal)
            {
                int partitionIndex = recursiveHelper(list, lowVal, highVal);

                recursiveQuickSort(list, lowVal, partitionIndex - 1);
                recursiveQuickSort(list, partitionIndex + 1, highVal);
            }

            return list;
        }
        public static int recursiveHelper(List<int> list, int lowVal, int highVal)
        {
            int pivotVal = list[highVal];
 
            int index = (lowVal - 1);
            for (int i = lowVal; i < highVal; i++)
            {
                if (list[i] <= pivotVal)
                {
                    i++;
                    int temp = list[index];
                    list[index] = list[i];
                    list[i] = temp;
                }
            }
            int temp1 = list[index + 1];
            list[index + 1] = list[highVal];
            list[highVal] = temp1;

            return index + 1; 
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
         * Adapted using algorithm from https://www.geeksforgeeks.org/iterative-quick-sort/
         */
        public static List<int> iterativeQuickSort(List<int> list)
        {

        }
    }
}
