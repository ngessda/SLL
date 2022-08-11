using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL
{
    public class SingleLinkedList
    {
        private int size;
        private Node head;
        public int Count => size;
        public int this[int index]
        {
            get
            {
                int result = 0;
                if (index >= size || size < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = head;

                for (int i = 0; i < size; i++)
                {
                    if(index == i)
                    {
                        result = current.Value;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

                return result;
            }
            set
            {
                if (index >= size || size < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = head;

                for (int i = 0; i < size; i++)
                {
                    if (index == i)
                    {
                        current.Value = value;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

        public void Add(int value)
        {
             if (head == null)
            {
                head = new Node();
                {
                    head.Value = value;
                }
            }
            else
            {
                Node current = head;
                for (int i = 0; i < size; i++)
                {
                    if(current.Next == null)
                    {
                        current.Next = new Node()
                        {
                            Value = value
                        };
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            size++;
        }
        private Node GetNode(int index)
        {
            Node current = head;
            for(int i =0; i < size; i++)
            {
                if(i == index)
                {
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return current;
        }
        public void Insert(int index, int value)
        {
            if(head == null)
            {
                Console.WriteLine("Корневой узел равен null");
                return;
            }
            else
            {
                if (index >= size || index < 0)
                {
                    Console.WriteLine("Заданный индекс больше или равен размеру списка");
                    return;
                }
                Node current = new Node
                {
                    Value = value,
                    Next = GetNode(index)
                };
                GetNode(index - 1).Next = current;
                size++;
            }
        }
        public void RemoveAt(int index)
        {
            if (head == null)
            {
                Console.WriteLine("Корневой узел равен null");
                return;
            }
            if (size == 1)
            {
                head = null;
            }
            else
            {
                if (index >= size || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                GetNode(index).Next = null;
                if(index == size - 1)
                {
                    GetNode(index - 1).Next = null;
                }
                if (index == 0) // если индекс указывает на корневой узел
                {
                    Node next = GetNode(index + 1);
                    head.Next = null;
                    head = next;
                }
                else
                {
                    GetNode(index - 1).Next = GetNode(index + 1);
                }
                size--;
            }

        }
        public void Switch(int firstIndex, int secondIndex)
        {
            int first = firstIndex < secondIndex ? firstIndex : secondIndex;
            int second = firstIndex < secondIndex ? secondIndex : firstIndex;
            
            if(first < second)
            {
                Node firstNode = GetNode(firstIndex);
                Node secondNode = GetNode(secondIndex);

                Node firstPrev = first - 1 >= 0 ? GetNode(first - 1) : null;
                Node secondNext = second - 1 < size ? GetNode(second + 1) : null;

                Node firstNext = GetNode(first + 1);
                Node secondPrev = GetNode(second - 1);

                if(firstPrev == null)
                {
                    head = secondNode;
                }
                else
                {
                    firstPrev.Next = secondNode;
                }

                if (first + 1 == second)
                {
                    firstNode = secondNext;
                    secondNode = firstNode;
                }
                else
                {
                    secondPrev.Next = firstNode;
                    firstNode.Next = secondNext;
                    secondNode.Next = firstNext;
                }
            }
        }
    }
}
