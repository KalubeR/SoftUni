 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "HARVEST")
                {
                    break;
                }
                else if (command == "all")
                {
                    foreach (var item in fieldInfo)
                    {
                        Console.WriteLine($"{item.Attributes.ToString().ToLower().Replace("family", "protected")} {item.FieldType.Name} {item.Name}");
                    }
                }
                FieldInfo[] fieldsToPrint = fieldInfo.Where(x => x.Attributes.ToString().ToLower().Replace("family", "protected") == command).ToArray();

                foreach (var item in fieldsToPrint)
                {
                    Console.WriteLine($"{item.Attributes.ToString().ToLower().Replace("family", "protected")} {item.FieldType.Name} {item.Name}");
                }
            }
        }
    }
}
