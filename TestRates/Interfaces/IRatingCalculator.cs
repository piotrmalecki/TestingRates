using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating.Models;

namespace TestRating.Interfaces
{
    public interface IRatingCalculator
    {
        decimal CalculatePolicy(Policy policy);
    }
}
