using BowlingBall.Stores;
using BowlingBall.Utilities;

namespace BowlingBall.Frames
{
    internal class NormalFrame : Frame
    {
        internal static FrameType frameType { get => FrameType.Normal; }

        internal NormalFrame(IStore store) : base(store)
        {
        }

        internal override int FrameScore(int index)
        {
            int score = _store.GetPinsByRollIndex(index) + _store.GetPinsByRollIndex(index + 1);
            return score;
        }

        internal override int FrameSize => 2;
    }
}
