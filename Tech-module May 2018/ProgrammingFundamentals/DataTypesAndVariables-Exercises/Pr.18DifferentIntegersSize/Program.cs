using System;

namespace Pr._18DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            bool isLong = long.TryParse(n, out long longResult);

            if (!isLong)
            {
                Console.WriteLine($"{n} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{n} can fit in:");
                bool isSbyte = sbyte.TryParse(n, out sbyte sbyteResult);
                if (isSbyte)
                {
                    Console.WriteLine("* sbyte");
                }

                bool isByte = byte.TryParse(n, out byte byteResult);
                if (isByte)
                {
                    Console.WriteLine("* byte");
                }

                bool isShort = short.TryParse(n, out short shortResult);
                if (isShort)
                {
                    Console.WriteLine("* short");
                }

                bool isUshort = ushort.TryParse(n, out ushort ushortResult);
                if (isUshort)
                {
                    Console.WriteLine("* ushort");
                }

                bool isInt = int.TryParse(n, out int intResult);
                if (isInt)
                {
                    Console.WriteLine("* int");
                }

                bool isUint = uint.TryParse(n, out uint uintResult);
                if (isUint)
                {
                    Console.WriteLine("* uint");
                }

                if (isLong)
                {
                    Console.WriteLine("* long");
                }
            }
        }
    }
}
