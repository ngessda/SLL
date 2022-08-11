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
                    throw new IndexOutOfRangeException();
                }
                GetNode(index).Next = null;
                if(index == size - 1)
                {
                    GetNode(index - 1).Next = null;
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
            
            if (head == null)
            {
                Console.WriteLine("Корневой узел равен null");
                return;
            }
            if (firstIndex >= size || secondIndex >= size || firstIndex < 0 || secondIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (firstIndex == secondIndex)
            {
                Console.WriteLine("Заданные индексы не могут быть равны");
                return;
            }
            
            Node counter;
            if (firstIndex == 0)
            {
                counter = new Node()
                {
                    Value = head.Value,
                    Next = GetNode(secondIndex + 1)
                };
                head = new Node()
                {
                    Value = GetNode(secondIndex).Value,
                    Next = GetNode(firstIndex + 1)
                };
                GetNode(secondIndex - 1).Next = counter;
            }
            else if (secondIndex == 0)
            {
                counter = new Node()
                {
                    Value = head.Value,
                    Next = GetNode(firstIndex + 1)
                };
                head = new Node()
                {
                    Value = GetNode(firstIndex).Value,
                    Next = GetNode(secondIndex + 1)
                };
                GetNode(firstIndex - 1).Next = counter;
            }
            else if(secondIndex == size - 1)
            {
                counter = new Node()
                {
                    Value = GetNode(secondIndex).Value,
                };
                GetNode(secondIndex - 1).Next = GetNode(firstIndex);
                counter.Next = GetNode(firstIndex + 1);
                GetNode(firstIndex - 1).Next = counter;
            }
            else if(firstIndex == size - 1)
            {
                counter = new Node()
                {
                    Value = GetNode(firstIndex).Value,
                };
                GetNode(firstIndex - 1).Next = GetNode(secondIndex);
                counter.Next = GetNode(secondIndex + 1);
                GetNode(secondIndex - 1).Next = counter;
            }
            else
            {
                counter = new Node()
                {
                    Value = GetNode(firstIndex).Value,
                    Next = GetNode(firstIndex).Next
                };
                GetNode(firstIndex - 1).Next = GetNode(secondIndex);
                GetNode(secondIndex - 1).Next = counter;

                counter.Next = GetNode(secondIndex + 1);
                GetNode(secondIndex).Next = GetNode(firstIndex + 1);
            }
        }
    }
}
