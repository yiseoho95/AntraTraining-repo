using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class ArithematicOperation : IArithematicOperation
    {
        public void Addition(int a, int b)
        {
            Console.WriteLine("Addition = "+(a+b));
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Subtraction(double a, double b)
        {
            return a - b;
        }

        public double Division(double a, double b)
        {
            return a / b;
        }
    }
}
