using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> data;
        private int classIndex;

        public ListyIterator()
        {
            this.data = new List<T>();
            classIndex = 0;
        }

        public ListyIterator(IList<T> input)
        {
            this.data = new List<T>(input);
        }

        public bool Move()
        {
            if (this.classIndex < this.data.Count - 1)
            {
                this.classIndex++;
                return true;

            }
            return false;

        }

        public T Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            return this.data[this.classIndex];
        }

        public bool HasNext()
        {
            return this.classIndex < this.data.Count - 1;
        }

        public void PrintAll()
        {
            foreach (var item in this.data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return new ListyIteratorEnumerator<T>(data);

            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private class ListyIteratorEnumerator<T> : IEnumerator<T>
        {
            private IList<T> data;
            private int currentIndex;

            public ListyIteratorEnumerator(IList<T> input)
            {
                this.Reset();
                this.data = input;
            }

            public T Current => this.data[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++this.currentIndex < this.data.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
