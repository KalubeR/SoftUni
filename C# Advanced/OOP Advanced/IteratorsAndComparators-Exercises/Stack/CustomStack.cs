using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private IList<T> data;

        public CustomStack(IList<T> input)
        {
            this.data = new List<T>(input);
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }

        public T Pop()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T lastElement = this.data.Last();
            this.data.Remove(this.data.Last());
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
