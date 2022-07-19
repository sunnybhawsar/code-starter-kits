using BowlingBall.Stores;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private IGame _game;
        private IStore _store;

        /// <summary>
        /// One time initializer
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // Arange
            _store = new ListStore();
            _game = new Game(_store);
        }

        /// <summary>
        /// Reset game after each test case
        /// </summary>
        [TestCleanup]
        public void ResetGame()
        {
            _game.Reset();
        }

        #region Testcases

        /// <summary>
        /// #1: Rolls with no pin drop
        /// </summary>
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            // Act
            Roll(0, 20);

            // Assert
            Assert.AreEqual(0, _game.GetScore());
        }

        /// <summary>
        /// #2: Rolls with 1 spare
        /// </summary>
        [DataTestMethod]
        [DataRow(5, 5, 10)]
        [DataRow(2, 8, 10)]
        public void GameWithOneSpareTest(int firstRoll, int secondRoll, int finalScore)
        {
            // Act
            RollSpare(firstRoll, secondRoll);
            Roll(0, 18);

            // Assert
            Assert.AreEqual(finalScore, _game.GetScore());
        }

        /// <summary>
        /// #3: Rolls with 1 strike
        /// </summary>
        [TestMethod]
        public void GameWithOneStrikeTest()
        {
            // Act
            Roll(0, 9);
            RollStrike();
            Roll(0, 10);

            // Assert
            Assert.AreEqual(10, _game.GetScore());
        }

        /// <summary>
        /// #4: Rolls with 1 strike and 1 spare
        /// </summary>
        [TestMethod]
        public void GameWithOneStrikeAndOneSpareTest()
        {
            // Act
            Roll(0, 9);
            RollStrike();
            RollSpare(5, 5);
            Roll(0, 8);

            // Assert
            Assert.AreEqual(25, _game.GetScore());
        }

        /// <summary>
        /// #5: Rolls with random pins drop and 1 strike
        /// </summary>
        [TestMethod]
        public void GameWithRandomRollsAndOneStrikeTest()
        {
            // Act
            _game.Roll(3);
            _game.Roll(5);
            _game.Roll(4);
            _game.Roll(5);
            _game.Roll(2);
            _game.Roll(4);
            _game.Roll(6);
            _game.Roll(1);
            RollStrike();

            // Assert
            Assert.AreEqual(40, _game.GetScore());
        }

        /// <summary>
        /// #6: Rolls with all strikes
        /// </summary>
        [TestMethod]
        public void GameWithAllStrikesTest()
        {
            // Act
            for(int i = 1; i <= 10; i++)
                RollStrike();

            // Assert
            Assert.AreEqual(270, _game.GetScore());
        }

        /// <summary>
        /// #7: Rolls with all spares
        /// </summary>
        [DataTestMethod]
        [DataRow(5, 5, 145)]
        [DataRow(2, 8, 118)]
        public void GameWithAllSparesTest(int firstRoll, int secondRoll, int finalScore)
        {
            // Act
            for (int i = 1; i <= 10; i++)
                RollSpare(firstRoll, secondRoll);

            // Assert
            Assert.AreEqual(finalScore, _game.GetScore());
        }

        /// <summary>
        /// #8: Rolls with random pins drop
        /// </summary>
        [TestMethod]
        public void GameWithRandomRollsTest()
        {
            // Arrange
            int[] pinsDrop = { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 };

            // Act
            foreach (int pins in pinsDrop)
                _game.Roll(pins);

            // Assert
            Assert.AreEqual(131, _game.GetScore());
        }

        #endregion

        #region Common

        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void RollSpare(int firstRoll, int secondRoll)
        {
            _game.Roll(firstRoll);
            _game.Roll(secondRoll);
        }

        /// <summary>
        /// Rolls the ball with number of pins dropped
        /// </summary>
        /// <param name="pins"></param>
        /// <param name="times"></param>
        private void Roll(int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }

        #endregion
    }
}
