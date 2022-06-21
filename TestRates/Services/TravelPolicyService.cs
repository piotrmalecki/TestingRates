using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating.Exceptions;
using TestRating.Interfaces;
using TestRating.Models;

namespace TestRating.Services
{
    public class TravelPolicyService : IRatingCalculator
    {

        public decimal CalculatePolicy(Policy policy)
        {
            decimal result = 0;
            Console.WriteLine("Rating TRAVEL policy...");

            this.ValidateTravelPolicy(policy);

            result = policy.Days * 2.5m;
            if (policy.Country == "Italy")
            {
                result *= 3;
            }
            return result;
        }

        private void ValidateTravelPolicy(Policy policy)
        {
            Console.WriteLine("Validating policy.");
            if (policy.Days <= 0)
            {
                throw new RatingBusinessException("Travel policy must specify Days.");
            }
            if (policy.Days > 180)
            {
                throw new RatingBusinessException("Travel policy cannot be more then 180 Days.");
            }
            if (String.IsNullOrEmpty(policy.Country))
            {
                throw new RatingBusinessException("Travel policy must specify country.");
            }
        }

    }
}
