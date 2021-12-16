using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.Shared.Models.Score;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Tests.RepositoryTests
{
    public class DbScoreRepositoryTests
    {
        private IScoreRepository _moqRepository;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _moqRepository = UnitTestUtilities.SetupRepositoryTest(nameof(IScoreRepository)) as IScoreRepository;
            _random = new Random(DateTime.Now.GetHashCode());

            // Assert
            Assert.IsNotNull(_moqRepository, $"While attempting to setup test. {nameof(_moqRepository)} was null.");
            Assert.IsInstanceOf<IScoreRepository>(_moqRepository, $"Repository was not instance of {nameof(IScoreRepository)}.");

            Assert.IsNotNull(_random);
            Assert.IsInstanceOf<Random>(_random);
        }

        [TestCase]
        public void GetByIdAsync_ValidParamters_ShouldReturnScoreFromLeaderboard()
        {
            // Arrange
            Guid moqId = Guid.NewGuid();
            decimal rndScore = 1 + ((decimal)_random.NextDouble() * (3000 - 1));
            DateTime moqDate = DateTime.Now;

            IScore moqScore = new ScoreModel
            {
                ClientId = moqId,
                Score = rndScore,
                ScoreRegistered = moqDate
            };

            // Act 
            IScore actualScore = null;

            // Assert 
            Assert.DoesNotThrowAsync(async () =>
            {
                Guid createdScore = await _moqRepository.CreateAsync(moqScore);
                actualScore = await _moqRepository.GetByIdAsync(createdScore);
            });

            Assert.IsNotNull(moqScore);
            Assert.AreNotEqual(Guid.Empty, actualScore);
            Assert.AreEqual(moqScore.ClientId, actualScore);
        }

        [TestCase(1, 3000, 10)]
        public void GetAllAsync_NotNullOrEmpty_ShouldGetCollectionOfData(decimal minScore, decimal maxScore, int iterations)
        {
            // Arrange
            // A collection of created scores, used to validating the result.
            Guid[] createdScores = new Guid[iterations];
            Guid[] filteredScores = new Guid[iterations];

            // Act
            IEnumerable<IScore> actualScores = new List<IScore>();

            // Assert
            Assert.DoesNotThrowAsync(async () =>
            {
                for (int i = 0; i < iterations; i++)
                {
                    IScore moqScore = new ScoreModel
                    {
                        ClientId = Guid.NewGuid(),
                        Score = minScore + ((decimal)_random.NextDouble() * (maxScore - minScore)),
                        ScoreRegistered = DateTime.Now
                    };

                    var score = await _moqRepository.CreateAsync(moqScore);
                    createdScores[i] = score;
                }
            });

            Assert.DoesNotThrowAsync(async () =>
            {
                actualScores = await _moqRepository.GetAllAsync();                
            });

            Assert.IsNotNull(actualScores);
            Assert.IsNotEmpty(filteredScores);

            // Filter the actual scores, from the created scores.
            filteredScores = actualScores
                .Where(x => createdScores
                .Any(y => y.Equals(x.ClientId)))
                .Select(x => x.ClientId)
                .ToArray();

            Assert.IsNotNull(filteredScores);
            Assert.IsNotEmpty(filteredScores);
            Assert.AreEqual(createdScores.Length, filteredScores.Length);
            Assert.Pass($"Collection is valid. Created {iterations} scores, then filtered the created scores from the actual dataset.");
        }

        [TestCase(1, 3000)]
        public void CreateScoreAsync_ValidParameters_ShouldCreateScoreToLeaderboard(decimal minScore, decimal maxScore)
        {
            // Arrange
            Guid moqId = Guid.NewGuid();
            decimal rndScore = minScore + ((decimal)_random.NextDouble() * (maxScore - minScore));
            DateTime dateNow = DateTime.Now;

            // Act
            IScore moqScore = new ScoreModel
            {
                ClientId = moqId,
                Score = rndScore,
                ScoreRegistered = dateNow
            };

            Guid act = Guid.Empty;

            // Assert
            Assert.That(async () =>
            {
                act = await _moqRepository.CreateAsync(moqScore);
            }, Throws.Nothing);

            Assert.IsNotNull(act);
            Assert.AreNotSame(act, Guid.Empty);
            Assert.IsNotEmpty(act.ToString());
            Assert.AreEqual(moqId, act);
            Assert.Pass($"Score was created using moq id {moqId}.");
        }

        [Test]
        public void CreateScoreAsync_NullParameter_ShouldThrownArgumentException()
        {
            // Arrange

            // Act
            IScore moqObj = null;

            Guid act = Guid.Empty;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                act = await _moqRepository.CreateAsync(moqObj);
            });

            Assert.IsNotNull(act);
            Assert.AreEqual(Guid.Empty, act);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }

        [Test]
        public void CreateScoreAsync_InvalidClientId_ShouldThrowArgumentException()
        {
            // Arrange
            Guid moqId = Guid.Empty;

            // Act
            IScore moqObj = new ScoreModel
            {
                ClientId = moqId,
                Score = 0,
                ScoreRegistered = default
            };

            Guid act = Guid.Empty;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                act = await _moqRepository.CreateAsync(moqObj);
            });

            Assert.IsNotNull(act);
            Assert.AreEqual(moqId, act);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }

        [Test]
        public void CreateScoreAsync_InvalidScoreIsZero_ShouldThrowArgumentException()
        {
            // Arrange
            Guid moqId = Guid.NewGuid();
            decimal moqZeroScore = decimal.Zero;
            DateTime moqDate = DateTime.Now;

            // Act
            IScore moqObj = new ScoreModel
            {
                ClientId = moqId,
                Score = moqZeroScore,
                ScoreRegistered = moqDate
            };

            Guid act = Guid.Empty;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                act = await _moqRepository.CreateAsync(moqObj);
            });

            Assert.IsNotNull(act);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }

        [Test]
        public void CreateScoreAsync_InvalidScoreIsNegative_ShowuldThrownArgumentException()
        {
            // Arrange
            Guid moqId = Guid.NewGuid();
            decimal moqNegativeScore = -decimal.One;
            DateTime moqDate = DateTime.Now;

            // Act
            IScore moqObj = new ScoreModel
            {
                ClientId = moqId,
                Score = moqNegativeScore,
                ScoreRegistered = moqDate
            };

            Guid act = Guid.Empty;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                act = await _moqRepository.CreateAsync(moqObj);
            });

            Assert.IsNotNull(act);
            Assert.AreEqual(Guid.Empty, act);
            Assert.Negative(moqNegativeScore);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }

        [Test]
        public void CreateScoreAsync_InvalidRegistrationDateIsDefault_ShouldThrownArgumentException()
        {
            // Arrange
            Guid moqId = Guid.NewGuid();
            decimal moqScore = 20;
            DateTime moqDate = default;

            // Act
            IScore moqObj = new ScoreModel
            {
                ClientId = moqId,
                Score = moqScore,
                ScoreRegistered = moqDate
            };

            Guid act = Guid.Empty;

            // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                act = await _moqRepository.CreateAsync(moqObj);
            });

            Assert.IsNotNull(act);
            Assert.AreEqual(Guid.Empty, act);
            Assert.AreEqual(default(DateTime), moqDate);
            Assert.IsNotNull(ex);
            Assert.IsNotEmpty(ex.Message);
            Assert.Pass(ex.Message);
        }
    }
}
