using System;
using System.Collections.Generic;
using System.Text;

namespace WeekendWork
{
    class ArrayExample
    {
        public void Demo()
        {
            string[] studentCollection = new string[5];
            studentCollection[0] = "Matthew";
            studentCollection[1] = "Jianshu";
            studentCollection[2] = "Seo Ho";
            studentCollection[3] = "Shuang";
            studentCollection[4] = "Wenqing";

            Array.Sort(studentCollection);

            int length = studentCollection.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(studentCollection[i]);
            }
        }
    }
}
