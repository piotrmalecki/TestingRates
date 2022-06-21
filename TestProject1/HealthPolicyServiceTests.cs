using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating.Exceptions;
using TestRating.Models;
using TestRating.Services;

namespace TestRatingUnitTests
{
    [TestClass]
    public class HealthPolicyServiceTests
    {
        HealthPolicyService _healthPolicyService;
        public HealthPolicyServiceTests()
        {
            _healthPolicyService = new HealthPolicyService();
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Male_With_Small_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 100;
            healthPolicy.Gender = "Male";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 1000m);
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Female_With_Small_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 100;
            healthPolicy.Gender = "Female";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 1100m);
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Male_With_Large_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 2000;
            healthPolicy.Gender = "Male";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 900m);
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Female_With_Large_Deductible()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 2000;
            healthPolicy.Gender = "Female";

            decimal rating = _healthPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 1000m);
        }

        [TestMethod()]
        public void Calculate_HealthPolicy_Without_Gender_ThrowsRatingBusinessException()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Deductible = 2000;
            //  healthPolicy.Gender = "Female";

            Action actual = () => _healthPolicyService.CalculatePolicy(healthPolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }
    }
}