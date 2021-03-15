using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            IArithematicOperation arithematicOperation = new ArithematicOperation();
            arithematicOperation.Addition(10, 20);
            int multiply = arithematicOperation.Multiply(23, 18);
            Console.WriteLine("Multiplicaiton = " +multiply);
            double subtract = arithematicOperation.Subtraction(200, 185);
            Console.WriteLine("Subtraction = "+subtract);

            double divide = arithematicOperation.Division(300, 4);
            Console.WriteLine("Division = "+divide);
        }
    }
}
