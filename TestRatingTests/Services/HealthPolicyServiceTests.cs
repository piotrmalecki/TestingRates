using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRating.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating.Models;

namespace TestRating.Services.Tests
{
    public class HealthPolicyServiceTests
    {
        HealthPolicyService _healthPolicyService;
        public HealthPolicyServiceTests()
        {
            _healthPolicyService = new HealthPolicyService();
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Male_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 100;
            healthPolicy.Gender = "Male";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 1000m);
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Female_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 100;
            healthPolicy.Gender = "Female";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 1000m);
        }
    }
}