using InsuranceAPI.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Helpers
{
    public class PremiumCalculator:IPremiumCalculator
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public PremiumCalculator(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<List<Occupations>> RetrieveOccupations()
        {
            return new List<Occupations>();
        }
        public async Task<Double> CalculatePremium(string rating, double coverAmount, int age)
        {
            return 0;
        }

        public async Task<Double> RetrieveRatingFactor(string ratingName)
        {
            Double ratingFactor = 0;
          
            return ratingFactor;
        }
    }
}
