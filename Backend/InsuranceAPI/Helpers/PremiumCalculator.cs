using InsuranceAPI.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var filePath = "/Occupations.json";
            List<Occupations> occupations = new List<Occupations>();
            var jsonString = ReadJsonFile(filePath);
            if (!String.IsNullOrEmpty(jsonString))
            {
                var occupationList= JsonSerializer.Deserialize<List<Occupations>>(jsonString);
                if(occupationList != null && occupationList.Any())
                {
                    occupations = occupationList;
                }
            }
            return occupations;
        }
        public async Task<Double> CalculatePremium(string rating, double coverAmount, int age)
        {
            var ratingInfo = await RetrieveRatingFactor(rating);
            var premium = (coverAmount * ratingInfo * age) / 1000 * 12;
            return premium;
        }

        public async Task<Double> RetrieveRatingFactor(string ratingName)
        {
            Double ratingFactor = 0;
            string fileName = "/OccupationRating.json";
            var jsonContentString = ReadJsonFile(fileName);

            var ratings = JsonSerializer.Deserialize<OccupationRating>(jsonContentString);
            if (ratings != null && ratings.Items.Any())
            {
                var matchingRating = ratings.Items.FirstOrDefault(x => x.RatingName == ratingName);
                await Task.Delay(100);
                ratingFactor = matchingRating != null ? matchingRating.RatingFactor : 0;
            }
            return ratingFactor;
        }

        private string ReadJsonFile(string filePath)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            var jsonContent = System.IO.File.ReadAllText(contentRootPath + filePath);
            return jsonContent;
        }
    }
}
