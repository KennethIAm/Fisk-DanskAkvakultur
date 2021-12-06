using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.DataAccess.Repositories;
using DanskAkvakultur.dk.Shared.Models.Information;
using NUnit.Framework;
using System;

namespace DanskAkvakultur.dk.DataAccess.Tests.RepositoryTests
{
    class DBAnimalInformationRepositoryTests
    {

        private IAnimalInformationRepository _moqRepository;

        [SetUp]
        public void SetUp()
        {
            // Assert
            _moqRepository = UnitTestUtilities.SetupAnimalRepositoryTest(nameof(IAnimalInformationRepository)) as IAnimalInformationRepository;
        }

        [Test]
        public void GetByNameAsync_ValidParametres_ShouldReturnSpecifiedAnimal()
        {
            // Arrange
            string animalName = "Ål";
            AnimalInformation info;

            // Act
            info = _moqRepository.GetByNameAsync(animalName).Result;

            // Assert
            Assert.IsNotNull(info);
            Assert.AreEqual(animalName, info.Animal);
            Assert.IsNotNull(info.BriefDescription);
        }

        [Test]
        public void GetByNameAsync_InvalidParametres_ShouldNotReturnSpecifiedAnimal()
        {
            // Arrange
            string animalName = "Abe";
            AnimalInformation info;

            // Act
            info = _moqRepository.GetByNameAsync(animalName).Result;

            // Assert
            Assert.IsNull(info);
        }
    }
}
