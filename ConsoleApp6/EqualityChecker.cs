using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class EqualityChecker<T> where T : class //struct // class for string values // nothing for everything
    {//method overloading?
        //public bool CheckEquality(int a, int b)
        //{
        //    return a.Equals(b);
        //}

        //public bool CheckEquality(string a, string b)
        //{
        //    return a.Equals(b);
        //}

        /*
         * problems with object is
         *      1.  typesafety
         *      2.  unwanted boxing and unboxing
         *      
         *      
         *      conversion of a value type to a reference type is called boxing
         *      conversion of referencetype to a value type is called unboxing
         */

        public bool CheckEquality(object a, object b)
        {// object type indicates parent of all of the types. so you can pass any derived type parameters
            return a.Equals(b);
        }


        public bool CheckEquality<T>(T a, T b)
        {//<t> stands for Type. so written this way you must have the same type in order to use the method.
            return a.Equals(b);
        }
    }
}
