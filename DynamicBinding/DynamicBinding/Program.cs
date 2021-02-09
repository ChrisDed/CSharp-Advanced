using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = "Chris";
            //obj.GetHashCode();

            // With reflections
            MethodInfo methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            // Without the dynamic keyword, you would have to
            // use reflections to use a method that is not defined
            // within the excel object
            object excelObjectEx = "excel";
            //excelObjectEx.Optimize();

            // With dynamic
            dynamic excelObject = "excel";
            excelObject.Optimize();

            // Using dynamic, you can change types of variables
            // without any sort of casting like you would in python or JS
            dynamic name = "Chris";
            //name = 10;
            name++; // Runtime exception

            dynamic a = 10;
            dynamic b = 5;
            // since a and b are dynamic, c is converted to dynamic
            var c = a + b;

            int i = 5;
            // at runtime, d becomes a dynamic integer
            dynamic d = i;
            // l converts d to a long
            long l = d;

        }
    }
}
