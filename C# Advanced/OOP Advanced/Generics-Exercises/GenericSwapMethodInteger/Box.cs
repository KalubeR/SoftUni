using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        private IList<T> data;

        public Box(List<T> messages)
        {
            this.data = messages;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T firstElement = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.data)
            {
                sb.AppendLine($"System.Int32: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
