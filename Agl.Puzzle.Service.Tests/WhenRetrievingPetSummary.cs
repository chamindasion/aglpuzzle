using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Agl.Puzzle.Data.Contracts;
using Agl.Puzzle.Models;
using Agl.Puzzle.Models.Domain;
using Agl.Puzzle.Models.Dto;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace Agl.Puzzle.Service.Tests
{
    [TestFixture]
    public class WhenRetrievingPetSummary
    {
        private IPetApiClient _petApiClient;
        private List<Person> _inputPersonPetData;

        private List<Person> GetPersonPetSourceData()
        {
            string fileString;
            var assembly = Assembly.GetExecutingAssembly();
            var jsonFileName = "Agl.Puzzle.Service.Tests.testData.json";
            using (var stream = assembly.GetManifestResourceStream(jsonFileName))
            {
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
                {
                    fileString = reader.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<List<Person>>(fileString);
        }

        [SetUp]
        public void Setup()
        {
            _petApiClient = Substitute.For<IPetApiClient>();
            _inputPersonPetData = GetPersonPetSourceData();
        }

        [Test]
        public void WhenRetrievingPetSummary_Success()
        {
            _petApiClient.GetAllPerson().Returns(_inputPersonPetData);
            var personPetReadService = new PersonPetReadService(_petApiClient);
            var summaryResult = personPetReadService.GetCategorizePets(PetType.Cat);
            Assert.IsTrue(summaryResult != null);
            Assert.AreEqual(summaryResult.Count, 2);
            Assert.AreEqual(summaryResult.Count(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Male)), 1);
            Assert.AreEqual(summaryResult.Count(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Female)), 1);
            Assert.AreEqual(summaryResult.Where(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Male)).SelectMany(q=>q.Pets).Count(), 4);
            Assert.AreEqual(summaryResult.Where(p => p.GenderType == Enum.GetName(typeof(GenderType), GenderType.Female)).SelectMany(q => q.Pets).Count(), 3);
        }

        [Test]
        public void WhenFilteringPetSummary_Success()
        {
            _petApiClient.GetAllPerson().Returns(_inputPersonPetData);
            var personPetReadService = new PersonPetReadService(_petApiClient);
            var filterResult = personPetReadService.GetFilteredDataByPetType(PetType.Cat);
            Assert.IsTrue(filterResult != null);
            var genderPetCategoryDtos = filterResult as GenderPetCategoryDto[] ?? filterResult.ToArray();
            Assert.AreEqual(genderPetCategoryDtos.ToList().Count, 2);
            Assert.AreEqual(genderPetCategoryDtos.ToList().Where(p=>p.GenderType == GenderType.Male).SelectMany(p=>p.Pets).Count(), 4);
            Assert.AreEqual(genderPetCategoryDtos.ToList().Where(p => p.GenderType == GenderType.Female).SelectMany(p => p.Pets).Count(), 3);
        }
    }
}
