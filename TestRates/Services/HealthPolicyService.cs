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
    public class HealthPolicyService : IRatingCalculator
    {

        public decimal CalculatePolicy(Policy policy)
        {
            decimal result = 0;
            Console.WriteLine("Rating HEALTH policy...");

            this.ValidateHealthPolicy(policy);

            if (policy.Gender == "Male")
            {
                if (policy.Deductible < 500)
                {
                    result = 1000m;
                }
                // I added else here otherwise condition 'policy.Deductible < 500' does not make sense
                else result = 900m;
            }
            else
            {
                if (policy.Deductible < 800)
                {
                    result = 1100m;
                }
                // I added else here otherwise condition 'policy.Deductible < 800' does not make sense
                else result = 1000m;
            }
            return result;

        }


        private void ValidateHealthPolicy(Policy policy)
        {
            Console.WriteLine("Validating policy.");
            if (String.IsNullOrEmpty(policy.Gender))
            {
                throw new RatingBusinessException("Health policy must specify Gender.");
            }
        }

    }
}
