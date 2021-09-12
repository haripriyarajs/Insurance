using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Model
{
    public class OccupationList
    {
        public List<Occupations> Items { get; set; }
    }
    public class Occupations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
    }
}
