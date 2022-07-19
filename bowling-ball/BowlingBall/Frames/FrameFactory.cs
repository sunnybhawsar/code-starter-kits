using BowlingBall.Stores;
using BowlingBall.Utilities;
using System.Collections.Generic;

namespace BowlingBall.Frames
{
    internal class FrameFactory
    {
        private static FrameFactory _instance;
        private readonly IStore _store;
        private IDictionary<FrameType, Frame> _frames;

        /// <summary>
        /// Singleton, Keeps the instance of all the concrete frames
        /// </summary>
        /// <param name="store"></param>
        private FrameFactory(IStore store)
        {
            _store = store;
            _frames = new Dictionary<FrameType, Frame>();

            _frames.Add(StrikeFrame.frameType, new StrikeFrame(_store));
            _frames.Add(SpareFrame.frameType, new SpareFrame(_store));
            _frames.Add(NormalFrame.frameType, new NormalFrame(_store));
        }

        /// <summary>
        /// Keeps only one instance
        /// </summary>
        /// <param name="store"></param>
        /// <returns>Singleton instance of the FrameFactory</returns>
        internal static FrameFactory Instance(IStore store)
        {
            return _instance ?? (_instance = new FrameFactory(store));
        }

        /// <summary>
        /// Gets the Concrete Frame based on FrameType from the factory
        /// </summary>
        /// <param name="frameType"></param>
        /// <returns>Instance of the Frame</returns>
        internal Frame GetCurrentFrame(FrameType frameType) => _frames[frameType];

        /// <summary>
        /// Sets the instance to null to accomodate new store
        /// </summary>
        internal void Reset()
        {
            _instance = null;
        }
    }
}
