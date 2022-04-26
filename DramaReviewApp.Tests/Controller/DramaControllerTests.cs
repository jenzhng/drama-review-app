using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using DramaReviewApp.Controllers;
using DramaReviewApp.Dto;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DramaReviewApp.Tests.Controller
{
    public class DramaControllerTests
    {
        private readonly IDramaRepository _dramaRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public DramaControllerTests()
        {
            _dramaRepository = A.Fake<IDramaRepository>();
            _reviewRepository = A.Fake<IReviewRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void DramaController_GetDramas_ReturnOK()
        {
            //Arrange
            var dramas = A.Fake<ICollection<DramaDto>>();
            var dramaList = A.Fake<List<DramaDto>>();
            A.CallTo(() => _mapper.Map<List<DramaDto>>(dramas)).Returns(dramaList);
            var controller = new DramaController(_dramaRepository, _reviewRepository, _mapper);

            //Act
            var result = controller.GetDramas();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DramaController_CreateDrama_ReturnOK()
        {
            //Arrange
            int ownerId = 1;
            int catId = 2;
            var dramaMap = A.Fake<Drama>();
            var drama = A.Fake<Drama>();
            var dramaCreate = A.Fake<DramaDto>();
            var dramas = A.Fake<ICollection<DramaDto>>();
            var dramaList = A.Fake<IList<DramaDto>>();
            A.CallTo(() => _dramaRepository.GetDramaTrimToUpper(dramaCreate)).Returns(drama);
            A.CallTo(() => _mapper.Map<Drama>(dramaCreate)).Returns(drama);
            A.CallTo(() => _dramaRepository.CreateDrama(ownerId, catId, dramaMap)).Returns(true);
            var controller = new DramaController(_dramaRepository, _reviewRepository, _mapper);

            //Act
            var result = controller.CreateDrama(ownerId, catId, dramaCreate);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
