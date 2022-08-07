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
            else
            {
                if (index >= size || index < 0)
                {
                    Console.WriteLine("Заданный индекс больше или равен размеру списка");
                    return;
                }
                GetNode(index).Next = null;
                GetNode(index - 1).Next = GetNode(index + 1);
                size--;
            }

        }
        public void Switch(int firstIndex, int secondIndex)
        {
            {
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
                if (firstIndex == secondIndex)
                {
                    Console.WriteLine("Заданные индексы не могут быть равны");
                }
            }
            Node node = GetNode(firstIndex);

            GetNode(firstIndex - 1).Next = GetNode(secondIndex);
            GetNode(firstIndex).Next = GetNode(firstIndex + 1);

            GetNode(secondIndex - 1).Next = node;
            GetNode(secondIndex).Next = GetNode(secondIndex + 1);
        }
    }
}
