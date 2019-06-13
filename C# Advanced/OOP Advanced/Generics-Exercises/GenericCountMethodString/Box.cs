using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable<T>
{
    private IList<T> data;

    public Box(List<T> list)
    {
        this.data = list;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.data[firstIndex];
        data[firstIndex] = data[secondIndex];
        data[secondIndex] = firstElement;
    }

    public int Compare(T element)
    {
        int counter = 0;
        foreach (var item in this.data)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var element in this.data)
        {
            sb.AppendLine($"{element.GetType().FullName}: {element}");
        }

        return sb.ToString().TrimEnd();
    }
}