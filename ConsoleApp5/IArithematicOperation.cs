using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    /*
     * Interface provides the contract which must be implemented by the derived class
     * By default all the methods inside an interface are PUBLIC AND ABSTRACT
     * interface support multiple inheritance
     * interface cannot have any constructor
     * interface cannot be instantiated
     * interface cannot have variables
     */
    interface IArithematicOperation
    {
        void Addition(int a, int b);
        int Multiply(int a, int b);

        double Subtraction(double a, double b);

        double Division(double a, double b);
    }
}
