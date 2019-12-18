using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_07_TDD_Collections
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());
            int num4 = Convert.ToInt32(Console.ReadLine());
            int num5 = Convert.ToInt32(Console.ReadLine());
            */
            
        }
    }

    public class Array_List_Dictionary
    {   


        public static int GetTotal(int a, int b, int c, int d, int e)
        {
            
            int[] myArray = { a + 5, b + 5, c + 5, d + 5, e + 5 };
            List<int> myList = new List<int>();
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            int result = 0;

            for (int i = 0; i < 5; i++) 
            {
                myArray[i] = myArray[i] * myArray[i];
                myList.Add(myArray[i]);
                myDictionary.Add(i + 1, myList[i] - 10);
            }

            foreach (var item in myDictionary)
            {
                result = myDictionary.Sum(x => x.Value);
            }
            
            return result;
        }
    }


}
