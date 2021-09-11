using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Model
{

    public class OccupationRating
    {
        public List<Insurance> Items { get; set; }
    }
    public class Insurance
    {
        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public Double RatingFactor { get; set; }
    }

}
