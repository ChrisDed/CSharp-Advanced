using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<DateTime> date = null;
            DateTime? dayte = null; // shorter way to write nullable

            Console.WriteLine("GetValueOrDefault: " + date.GetValueOrDefault());
            Console.WriteLine("HasValue: " + date.HasValue);
            //Console.WriteLine("Value: " + date.Value); // Throws exception

            DateTime? realDate = new DateTime(2014, 1, 1);
            DateTime date2 = realDate.GetValueOrDefault();
            Console.WriteLine(date2);

            DateTime? date3 = date2;
            Console.WriteLine(date3.GetValueOrDefault());

            DateTime? date4 = null;
            DateTime date5;

            // This can be shortened with null coalescing operator
            if (date4 != null)
                date5 = date4.GetValueOrDefault();
            else
                date5 = DateTime.Today;

            Console.WriteLine(date5);

            // Null Coalescing Operator
            DateTime? date10 = null;
            DateTime date11 = date10 ?? DateTime.Today;
            // Similiar to tetriary operator
            DateTime date12 = (date10 != null) ? date10.GetValueOrDefault()
                : DateTime.Today;

            Console.WriteLine(date11);

        }
    }
}
