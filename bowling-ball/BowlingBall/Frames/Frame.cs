using BowlingBall.Stores;

namespace BowlingBall.Frames
{
    internal abstract class Frame
    {
        protected readonly IStore _store;

        internal Frame(IStore store)
        {
            _store = store;
        }

        internal abstract int FrameScore(int index);

        internal abstract int FrameSize { get; }
    }
}
