using BowlingBall.Frames;
using BowlingBall.Stores;
using BowlingBall.Utilities;

namespace BowlingBall.Calculations
{
    internal class ScoreCalculator
    {
        private static ScoreCalculator _instance;
        private readonly IStore _store;
        private readonly FrameFactory _frameFactory;

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="store"></param>
        private ScoreCalculator(IStore store)
        {
            _store = store;
            _frameFactory = FrameFactory.Instance(_store);
        }

        /// <summary>
        /// Keeps only one instance
        /// </summary>
        /// <param name="store"></param>
        /// <returns>Singleton instance of ScoreCalculator</returns>
        internal static ScoreCalculator Instance(IStore store)
        { 
            return _instance ?? (_instance = new ScoreCalculator(store)); 
        }

        /// <summary>
        /// Calculates the score based on the frames
        /// </summary>
        /// <returns>Final Score after all the rolls</returns>
        internal int FinalScore()
        {
            int index = 0, finalScore = 0;

            while (index < _store.TotalRolls)
            {
                var frame = _frameFactory.GetCurrentFrame(DeriveFrameType(index));
                finalScore += frame.FrameScore(index);
                index += frame.FrameSize;
            }

            return finalScore;
        }

        /// <summary>
        /// Derives the FrameType based on the requirements
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Type of Frame</returns>
        private FrameType DeriveFrameType(int index)
        {
            // Srike
            if (_store.GetPinsByRollIndex(index) == Constants.MaxPins)
                return FrameType.Strike;

            // Spare
            else if (_store.GetPinsByRollIndex(index) != Constants.MaxPins
                && _store.GetPinsByRollIndex(index) + _store.GetPinsByRollIndex(index + 1) == Constants.MaxPins)
                return FrameType.Spare;

            // Normal
            else
                return FrameType.Normal;
        }

        /// <summary>
        /// Sets the instance to null to accomodate new store
        /// </summary>
        internal void Reset()
        {
            _instance = null;
            _frameFactory.Reset();
        }
    }
}
