using System;
using System.Collections.Generic;
using System.Text;
using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Agl.Puzzle.Service.Tests
{
    [TestFixture]
    public class WhenRetrievingPetSummary
    {
        private IPetApiClient _petApiClient;
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _petApiClient = Substitute.For<IPetApiClient>();
            _serviceProvider = Substitute.For<IServiceProvider>();
        }

        [Test]
        public void WhenRetrievingPetSummary_Success()
        {
            _petApiClient.GetPersonPets().Returns(new List<Person>());
            var personPetReadService = new PersonPetReadService(_serviceProvider);
            var result = personPetReadService.GetCategorisePets();
            Assert.IsTrue(result != null);
        }
    }
}
