using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            SingleLinkedList singleLinkedList = new SingleLinkedList();
            for (int i = 0; i < 5; i++)
            {
                singleLinkedList.Add(rand.Next(0, 25));
            }
            ShowList(singleLinkedList);
            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\");
            singleLinkedList.Switch(1, 3);
            ShowList(singleLinkedList);
            Console.ReadKey();
        }
        static void ShowList(SingleLinkedList sll)
        {
            for (int i = 0; i < sll.Count; i++)
            {
                Console.WriteLine(sll[i]);
            }
        }
    }
}
