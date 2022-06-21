using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using TestRating.Exceptions;
using TestRating.Interfaces;
using TestRating.Models;
using TestRating.Services;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {

        //In real project _healthPolicyService, _lifePolicyService, _travelPolicyService could be injected with IoC container.
        HealthPolicyService _healthPolicyService;
        LifePolicyService _lifePolicyService;
        TravelPolicyService _travelPolicyService;
        public RatingEngine(HealthPolicyService healthPolicyService, LifePolicyService lifePolicyService, TravelPolicyService travelPolicyService)
        {
            _healthPolicyService = healthPolicyService;
            _lifePolicyService = lifePolicyService;
            _travelPolicyService = travelPolicyService;
        }

        public decimal Rating { get; set; }

        public void Rate()
        {
            // log start rating
            Console.WriteLine("Starting rate.");

            Console.WriteLine("Loading policy.");

            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");

            Policy policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());


            switch (policy.Type)
            {
                case PolicyType.Health:
                    Rating = _healthPolicyService.CalculatePolicy(policy);
                    break;

                case PolicyType.Travel:
                    Rating = _travelPolicyService.CalculatePolicy(policy);
                    break;

                case PolicyType.Life:
                    Rating = _lifePolicyService.CalculatePolicy(policy);
                    break;

                default:
                    Console.WriteLine("Unknown policy type");
                    break;
            }

            Console.WriteLine("Rating completed.");
        }


    }
}
