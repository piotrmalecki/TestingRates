using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating.Exceptions;
using TestRating.Models;
using TestRating.Services;

namespace TestRatingUnitTests
{
    [TestClass]
    public class TravelPolicyServiceTests
    {
        TravelPolicyService _travelPolicyService;
        public TravelPolicyServiceTests()
        {
            _travelPolicyService = new TravelPolicyService();
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_10Days_Italy()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 10;
            healthPolicy.Country = "Italy";

            decimal rating = _travelPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 75);
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_10Days_NonItaly()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 10;
            healthPolicy.Country = "Spain";

            decimal rating = _travelPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 25);
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_21Days_NonItaly()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 21;
            healthPolicy.Country = "Spain";

            decimal rating = _travelPolicyService.CalculatePolicy(healthPolicy);
            Assert.AreEqual(rating, 52.5m);
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_190Days_ThrowsRatingBusinessException()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 190;
            healthPolicy.Country = "Spain";

            Action actual = () => _travelPolicyService.CalculatePolicy(healthPolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_0Days_ThrowsRatingBusinessException()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 0;
            healthPolicy.Country = "USA";

            Action actual = () => _travelPolicyService.CalculatePolicy(healthPolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }

        [TestMethod()]
        public void Calculate_TravelPolicy_Without_Country_ThrowsRatingBusinessException()
        {
            Policy healthPolicy = new Policy();
            healthPolicy.Days = 5;
           // healthPolicy.Country = "USA";

            Action actual = () => _travelPolicyService.CalculatePolicy(healthPolicy);

            Assert.ThrowsException<RatingBusinessException>(actual);
        }
    }
}