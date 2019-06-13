namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var instance = (BlackBoxInteger)Activator.CreateInstance(type, true);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] args = input.Split("_");
                string method = args[0];
                int value = int.Parse(args[1]);

                //MethodInfo currentMethod = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(m => m.Name == method);
                var currentMethod = type.GetMethod(method, (BindingFlags)62);
                currentMethod.Invoke(instance, new object[] { value });

                var field = type.GetField("innerValue", (BindingFlags)62).GetValue(instance);
                //int fieldValue = (int)field.GetValue(instance);
                Console.WriteLine(field);
            }
        }
    }
}
