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
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(5);
            MyMapNode<string, int> myMapNodes = new MyMapNode<string, int>(10);
            //Create object for MyMapNode
            Console.WriteLine("Enter 1-to Check Sentence Frequency");
            Console.WriteLine("Enter 2-to check Paragraph Frequency");
            Console.WriteLine("Enter 3-Remove a Particular word from HashTable");


            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
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
                    string[] Paragraphs;
                    string inputs = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                    Paragraphs = inputs.Split(' ');
                    IEnumerable<string> UpdatedPara = AddingToHashTable(Paragraphs);
                    break;

                case 3:
                    string[] Paragraph;
                    string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
                    Paragraph = input.Split(' ');
                    IEnumerable<string> UpdatedParagraph = AddingToHashTable(Paragraph);
                    Console.WriteLine("\nEnter the Word to remove from Hash Table");
                    string remove = Console.ReadLine();
                    myMapNodes.RemoveFromHashTable(remove);
                    Display(UpdatedParagraph);
                    break;

            }

            IEnumerable<string> AddingToHashTable(string[] Paragraph)
            {

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
                IEnumerable<string> uniqueItem = Paragraph.Distinct<string>();
                Display(uniqueItem);
                return uniqueItem;
            }

            void Display(IEnumerable<string> Paragraph)
            {
                Console.WriteLine("\n---------WORD FREQUENCY IN PARAGRAPH---------\n");

                foreach (var i in Paragraph)
                {
                    myMapNodes.Display(i);
                }
            }
        }
    }
}
