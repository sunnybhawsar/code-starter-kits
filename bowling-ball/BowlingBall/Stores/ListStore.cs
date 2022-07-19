using BowlingBall.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall.Stores
{
    public class ListStore : IStore
    {
        private IList<int> _rolls = new List<int>(Constants.MaxRolls);

        public int TotalRolls => _rolls.Count;

        public void AddRoll(int pins)
        {
            _rolls.Add(pins);
        }

        public int GetPinsByRollIndex(int rollIndex)
        {
            if(rollIndex >= 0 && rollIndex < TotalRolls)
                return _rolls[rollIndex];

            return 0;
        }
        
        public void Clear()
        {
            _rolls.Clear();
        }
    }
}
