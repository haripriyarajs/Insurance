using InsuranceAPI.Helpers;
using InsuranceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IPremiumCalculator _premiumCalculator;
        public InsuranceController(IPremiumCalculator premium)
        {
            _premiumCalculator = premium;
        }
        // GET: api/<InsuranceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InsuranceController>/5
        [HttpGet]
        public IEnumerable<Occupations> GetOccupations()
        {
            return null;
        }
    }
}
