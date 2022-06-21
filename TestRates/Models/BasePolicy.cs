using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating.Models
{
    public class BasePolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
