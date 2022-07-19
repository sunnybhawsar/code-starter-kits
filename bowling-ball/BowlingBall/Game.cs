using BowlingBall.Calculations;
using BowlingBall.Stores;

namespace BowlingBall
{
    public class Game : IGame
    {
        private readonly IStore _store;
        private readonly ScoreCalculator _scoreCalculator;

        public Game(IStore store)
        {
            _store = store;
            _scoreCalculator = ScoreCalculator.Instance(_store);
        }

        public void Roll(int pins)
        {
            _store.AddRoll(pins);
        }

        public int GetScore()
        {
            return _scoreCalculator.FinalScore();
        }

        public void Reset()
        {
            _store.Clear();
            _scoreCalculator.Reset();
        }
    }
}
