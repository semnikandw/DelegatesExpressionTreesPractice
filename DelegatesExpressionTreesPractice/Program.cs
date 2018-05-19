using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExpressionTreesPractice
{
    class Program
    {
        delegate int Operation(int x, int y);

        static void Main(string[] args)
        {
            // присваивание адреса метода через контруктор
            Operation del = new Operation(Add); // делегат указывает на метод Add
            int result = del.Invoke(4, 5);
            Console.WriteLine(result);

            del = Multiply; // теперь делегат указывает на метод Multiply, присваивание such us old
            result = del.Invoke(4, 5);
            Console.WriteLine(result);

            Console.Read();
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
