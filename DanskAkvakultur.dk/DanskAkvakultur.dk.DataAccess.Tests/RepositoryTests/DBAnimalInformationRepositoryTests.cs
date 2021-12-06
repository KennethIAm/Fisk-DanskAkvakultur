using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
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
            _moqRepository = UnitTestUtilities.SetupRepositoryTest(nameof(IAnimalInformationRepository)) as IAnimalInformationRepository;

            // Assert
            Assert.IsNotNull(_moqRepository, $"While attempting to setup test. {nameof(_moqRepository)} was null.");
            Assert.IsInstanceOf<IAnimalInformationRepository>(_moqRepository, $"Repository was not instance of {nameof(IAnimalInformationRepository)}.");
        }

        [TestCase("Eel")]
        public void GetByNameAsync_ValidParameters_ShouldReturnAnimalInformation(string animalName)
        {
            // Arrange

            // Act
            AnimalInformation actInfo = null;

            // Assert
            Assert.That(async () =>
            {
                actInfo = await _moqRepository.GetByNameAsync(animalName);
            }, Throws.Nothing);

            Assert.IsNotNull(actInfo);
            Assert.AreNotSame(actInfo.Animal.Name, "");
            Assert.IsNotEmpty(actInfo.Animal.Name);
            Assert.AreEqual("Ål", actInfo.Animal.Name);
            Assert.Pass($"Animal information was returned for {actInfo.Animal.Name}.");
        }

        [Test]
        public void GetByNameAsync_InvalidNameIsEmpty_ShouldThrowArgumentException()
        {
            // Arrange
            string animalName = string.Empty;

            // Act
            AnimalInformation actInfo = null;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                actInfo = await _moqRepository.GetByNameAsync(animalName);
            });

            Assert.IsNull(actInfo);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }

        [Test]
        public void GetByNameAsync_InvalidNameIsNull_ShouldThrowArgumentException()
        {
            // Arrange
            string animalName = null;

            // Act
            AnimalInformation actInfo = null;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                actInfo = await _moqRepository.GetByNameAsync(animalName);
            });

            Assert.IsNull(actInfo);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }
    }
}
