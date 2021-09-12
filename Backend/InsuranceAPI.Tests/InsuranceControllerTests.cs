using InsuranceAPI.Controllers;
using InsuranceAPI.Helpers;
using InsuranceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceAPI.Tests
{
    public class InsuranceControllerTests
    {
        [Fact]
        public async Task TestGetOccupationsNoResult()
        {
            var insuranceHelperMock = new Mock<IPremiumCalculator>();
            var occupartionListMock = new Mock<List<Occupations>>();

            insuranceHelperMock.Setup(p => p.RetrieveOccupations()).ReturnsAsync((List<Occupations>)null);
            var controller = new InsuranceController(insuranceHelperMock.Object);

            var result = await controller.GetOccupations();

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task TestGetOccupationWithResult()
        {
            var insuranceHelperMock = new Mock<IPremiumCalculator>();

            var occupartionListMock = ReturnExpectedItem();

            insuranceHelperMock.Setup(p => p.RetrieveOccupations()).ReturnsAsync(occupartionListMock);
            var controller = new InsuranceController(insuranceHelperMock.Object);

            var result = await controller.GetOccupations();
           
            Assert.Equal(occupartionListMock, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value);

        }

        private List<Occupations> ReturnExpectedItem()
        {
            var list =  new List<Occupations>()
            {
                new Occupations{
                   Id=1,
                   Name ="Cleaner",
                   Rating = "LIGHT_MANUAL"
                },
                new Occupations{
                    Id =2,
                    Name =  "Doctor",
                    Rating=  "PROFESSIONAL"
                  },
                new Occupations{
                    Id = 3,
                    Name = "Author",
                    Rating = "WHITE_COLLAR"
                  },
                new Occupations{
                   Id =  4,
                   Name = "Farmer",
                    Rating = "HEAVY_MANUAL"
                  },
                new Occupations{
                    Id = 5,
                  Name = "Mechanic",
                    Rating = "HEAVY_MANUAL"
                  },
                new Occupations {
                   Id =  6,
                    Name =  "Florist",
                    Rating=  "LIGHT_MANUAL"
                  }
            };

            return list;
        }

    }
}
