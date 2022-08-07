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
                        current.Next = new Node();
                        {
                            current.Next.Value = value;
                        }
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
                Node current = new Node
                {
                    Value = value,
                    Next = GetNode(index)
                };
                GetNode(index - 1).Next = current;
            }
        }
        public void RemoveAt(int index)
        {
            Node current = head;
            if (head == null)
            {
                Console.WriteLine("Корневой узел равен null");
                return;
            }
            if (index >= size || index < 0)
            {
                Console.WriteLine("Заданный индекс больше или равен размеру списка");
                return;
            }
            for (int i = 0; i < size; i++)
            {
                if(index == i)
                {
                    for (int j = index; j < size; j++)
                    {
                        if (current.Next == null)
                        {
                            break;
                        }
                        else
                        {
                            current.Value = current.Next.Value;
                            current = current.Next;
                        }
                    }
                    size--;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
        public void Switch(int firstIndex, int secondIndex)
        {
            Node current = head;
            int valueOne = 0;
            int valueTwo = 0;
            if (head == null)
            {
                Console.WriteLine("Корневой узел равен null");
                return;
            }
            if (firstIndex >= size || secondIndex >= size || firstIndex < 0 || secondIndex < 0)
            {
                Console.WriteLine("Заданный индекс больше/меньше или равен размеру списка");
                return;
            }
            for(int i = 0; i < size; i++)
            {
                if(firstIndex == i)
                {
                    valueOne = current.Value;
                }
                if(secondIndex == i)
                {
                    valueTwo = current.Value;
                }
                if (valueOne != 0 && valueTwo != 0)
                {
                    break;
                }
                current = current.Next;
            }
            current = head;
            for (int i = 0; i < size; i++)
            {
                if (firstIndex == i)
                {
                    current.Value = valueTwo;
                }
                if (secondIndex == i)
                {
                    current.Value = valueOne;
                }
                current = current.Next;
            }
        }
    }
}
