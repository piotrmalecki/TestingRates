using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating.Exceptions;
using TestRating.Models;
using TestRating.Services;

namespace TestRatingUnitTests
{
    [TestClass]
    public class LifePolicyServiceTests
    {
        LifePolicyService _lifePolicyService;
        public LifePolicyServiceTests()
        {
            _lifePolicyService = new LifePolicyService();
        }

        [TestMethod()]
        public void Calculate_LifePolicy_90YearsOld_Smoker()
        {
            Policy lifePolicy = new Policy();
            lifePolicy.DateOfBirth = new DateTime(1931, 11, 5);
            lifePolicy.Amount = 100;
            lifePolicy.IsSmoker = true;

            decimal rating = _lifePolicyService.CalculatePolicy(lifePolicy);
            Assert.AreEqual(rating, 90m);
        }

        [TestMethod()]
        public void Calculate_LifePolicy_30YearsOld_Smoker()
        {
            Policy lifePolicy = new Policy();
            lifePolicy.DateOfBirth = new DateTime(1991, 11, 5);
            lifePolicy.Amount = 100;
            lifePolicy.IsSmoker = true;

            decimal rating = _lifePolicyService.CalculatePolicy(lifePolicy);
            Assert.AreEqual(rating, 30m);
        }

        [TestMethod()]
        public void Calculate_LifePolicy_30YearsOld_NonSmoker()
        {
            Policy lifePolicy = new Policy();
            lifePolicy.DateOfBirth = new DateTime(1991, 11, 5);
            lifePolicy.Amount = 100;
            lifePolicy.IsSmoker = false;

            decimal rating = _lifePolicyService.CalculatePolicy(lifePolicy);
            Assert.AreEqual(rating, 15m);
        }


        [TestMethod()]
        public void Calculate_LifePolicy_DateOfBirth_GreaterThan100_ThrowsRatingBusinessException()
        {
            Policy lifePolicy = new Policy();
            lifePolicy.DateOfBirth = new DateTime(1791, 10, 5);
            lifePolicy.Amount = 10;

            Action actual = () => _lifePolicyService.CalculatePolicy(lifePolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }


        [TestMethod()]
        public void Calculate_LifePolicy_Without_Amount_ThrowsRatingBusinessException()
        {
            Policy lifePolicy = new Policy();
            lifePolicy.DateOfBirth = new DateTime(1991,10,5);
            lifePolicy.Amount = 0;

            Action actual = () => _lifePolicyService.CalculatePolicy(lifePolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }

        [TestMethod()]
        public void Calculate_LifePolicy_Without_DatOfBirth_ThrowsRatingBusinessException()
        {
            Policy lifePolicy = new Policy();
            //lifePolicy.DateOfBirth = new DateTime(1991, 10, 5);
            lifePolicy.Amount = 10;

            Action actual = () => _lifePolicyService.CalculatePolicy(lifePolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }
    }
}