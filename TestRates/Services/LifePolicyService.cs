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
    public class LifePolicyService : IRatingCalculator
    {

        public decimal CalculatePolicy(Policy policy)
        {
            Console.WriteLine("Rating LIFE policy...");


            this.ValidatingLifePolicy(policy);

            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;

            return policy.IsSmoker ? baseRate * 2 : baseRate;

        }

        private void ValidatingLifePolicy(Policy policy)
        {
            Console.WriteLine("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                throw new RatingBusinessException("Life policy must include Date of Birth.");

            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                throw new RatingBusinessException("Max eligible age for coverage is 100 years.");
            }
            if (policy.Amount == 0)
            {
                throw new RatingBusinessException("Life policy must include an Amount.");
            }
        }

    }
}
