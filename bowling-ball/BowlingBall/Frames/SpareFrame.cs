using BowlingBall.Stores;
using BowlingBall.Utilities;

namespace BowlingBall.Frames
{
    internal class SpareFrame : Frame
    {
        internal static FrameType frameType { get => FrameType.Spare; }

        internal SpareFrame(IStore store) : base(store)
        {
        }

        internal override int FrameScore(int index)
        {
            int score = Constants.SpareBonus + _store.GetPinsByRollIndex(index + 2);
            return score;
        }

        internal override int FrameSize => 2;
    }
}
