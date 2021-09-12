using InsuranceAPI.Helpers;
using InsuranceAPI.Model;
using Microsoft.AspNetCore.Http;
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
        // GET: with params
        [HttpGet("/{age}/{rating}/{coverAmount}")]
        public async Task<string> Get(int age, string rating, double coverAmount)
        {
            var calculatedPremium = await _premiumCalculator.CalculatePremium(rating, coverAmount, age);
            return Convert.ToString(calculatedPremium);
        }


        [HttpGet("GetOccupations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Occupations>>> GetOccupations()
        {
            List<Occupations> listOfOccupations = new List<Occupations>();
            try
            {
                listOfOccupations = await _premiumCalculator.RetrieveOccupations();
                if (!listOfOccupations.Any())
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(listOfOccupations);
        }
    }
}
