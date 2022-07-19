using BowlingBall.Stores;
using BowlingBall.Utilities;

namespace BowlingBall.Frames
{
    internal class StrikeFrame : Frame
    {
        internal static FrameType frameType { get => FrameType.Strike; }

        internal StrikeFrame(IStore store) : base(store)
        {
        }

        internal override int FrameScore(int index)
        {
            int score = Constants.StrikeBonus + _store.GetPinsByRollIndex(index + 1) + _store.GetPinsByRollIndex(index + 2);
            return score;
        }

        internal override int FrameSize => 1;
    }
}
