using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            return $"System.String: {this.element}";
        }
    }
}
