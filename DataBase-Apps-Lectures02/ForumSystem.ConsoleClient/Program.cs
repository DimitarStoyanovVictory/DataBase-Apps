using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    public class ArrayStack<T>
    {
        private T[] elements;
        private int count = 0;
        public int Count
        {
            get { return count; }
            private set { count = value; }

        }
        private const int InitialCapacity = 16;
        public ArrayStack(int capacity = InitialCapacity)
        {
            // T[] temp = new T[capacity];
            elements = new T[capacity];
        }
        public void Push(T element)
        {

            if (count == elements.Length)
            {
                Grow();
                elements[count] = element;
                count++;
            }
            else
            {

                elements[count] = element;
                count++;

            }
        }

        public T Pop() { count--; return elements[count]; }
        public T[] ToArray()
        {
            T[] sub = new T[count];
            for (int i = 0; i < sub.Length; i++)
            { sub[i] = elements[i]; }
            return sub;

        }
        private void Grow()
        {
            T[] newElements = new T[2 * count];
            for (int i = 0; i < count / 2; i++)
            {
                newElements[i] = elements[i];
            }
            elements = newElements;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> st = new ArrayStack<int>();
            st.Push(1);
            st.Push(2);
            st.Push(100);
            Console.WriteLine(st.Count);
            Console.Write("length {0}", st.ToArray().Length);
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Pop());
            Console.Write(st.ToArray().Length);
        }
    }
}

