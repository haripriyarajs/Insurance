using InsuranceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Helpers
{
    public interface IPremiumCalculator
    {
        Task<List<Occupations>> RetrieveOccupations();
        Task<Double> CalculatePremium(string rating, double coverAmount, int age);
    }

}
