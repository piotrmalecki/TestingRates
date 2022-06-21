using System;
using TestRating.Services;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");

            var engine = new RatingEngine( new HealthPolicyService(), new LifePolicyService(), new TravelPolicyService() );
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
