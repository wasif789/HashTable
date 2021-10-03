using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to HashTable Program!");
            //Create object for MyMapNode
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(5);
            //Given string input
            string[] line = { "to", "be", "or", "not", "to", "be" };
            int count = 1;
            foreach (string i in line)
            {
                count = myMapNode.CheckHash(i);
                if (count > 1)
                {
                    myMapNode.Add(i, count);
                }
                else
                {
                    myMapNode.Add(i, 1);
                }
            }

            IEnumerable<string> uniqueItems = line.Distinct<string>();
            foreach (var i in uniqueItems)
            {
                myMapNode.Display(i);
            }

        }
    }
}
