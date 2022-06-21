using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating.Exceptions
{
    public class RatingBusinessException: Exception
    {
        public RatingBusinessException() { }

        public RatingBusinessException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
