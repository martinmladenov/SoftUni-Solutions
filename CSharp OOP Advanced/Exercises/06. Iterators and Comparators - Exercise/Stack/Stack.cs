namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private T[] arr;
        private int index;

        public Stack(int initialCapacity = 4)
        {
            this.arr = new T[initialCapacity];
            this.index = 0;
        }

        public void Push(T element)
        {
            if (index == arr.Length)
            {
                DoubleCapacity();
            }

            arr[index++] = element;
        }

        public T Pop()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            return arr[--index];
        }

        private void DoubleCapacity()
        {
            T[] newArr = new T[arr.Length * 2];
            Array.Copy(arr, newArr, arr.Length);

            arr = newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = index - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
