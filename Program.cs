using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to HashTable Program!");
                //Create object for MyMapNode
                Console.WriteLine("Enter 1-to Check Sentence Frequency");
                Console.WriteLine("Enter 2-to check Paragraph Frequency");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(5);
                        string[] line = new string[] { "to", "be", "or", "not", "to", "be" };
                        //Given string input

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
                        Console.WriteLine("\n---------WORD FREQUENCY IN SENTENCE--------\n");
                        IEnumerable<string> uniqueItems = line.Distinct<string>();
                        foreach (var i in uniqueItems)
                        {
                            myMapNode.Display(i);
                        }
                        break;


                    case 2:
                        MyMapNode<string, int> myMapNodes = new MyMapNode<string, int>(10);
                        string[] Paragraph;
                        string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                        Paragraph = input.Split(' ');
                        //Given string input

                        int counts = 1;
                        foreach (string i in Paragraph)
                        {
                            counts = myMapNodes.CheckHash(i);
                            if (counts > 1)
                            {
                                myMapNodes.Add(i, counts);
                            }
                            else
                            {
                                myMapNodes.Add(i, 1);
                            }
                        }
                        Console.WriteLine("\n---------WORD FREQUENCY IN PARAGRAPH---------\n");
                        IEnumerable<string> uniqueItem = Paragraph.Distinct<string>();
                        foreach (var i in uniqueItem)
                        {
                            myMapNodes.Display(i);
                        }

                        break;

                }
            }
    }
}
