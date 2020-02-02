using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models;
using AutoFixture;

namespace Agl.Puzzle.Service.Tests
{
    [TestFixture]
    public class PersonPetReadServiceTest
    {
        private IFixture _fixture;
        private IPetApiClient _petApiClient;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _petApiClient = _fixture.Freeze<IPetApiClient>();
            
        }

        [Test]
        public void GetCategorisePetsTest()
        {            
            var personPetReadService = _fixture.Create<PersonPetReadService>();
            var temp = personPetReadService.GetCategorisePets();
            Assert.AreEqual(temp.Count, 2);
            Assert.AreEqual(temp.Count(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Male)), 1);
            Assert.AreEqual(temp.Count(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Female)), 1);
            Assert.AreEqual(temp.Where(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Male)).SelectMany(q=>q.Pets).Count(), 4);
            Assert.AreEqual(temp.Where(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Female)).SelectMany(q => q.Pets).Count(), 3);
        }
    }
}
