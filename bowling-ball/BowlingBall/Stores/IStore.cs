namespace BowlingBall.Stores
{
    public interface IStore
    {
        /// <summary>
        /// To get total number of rolls for the final score
        /// </summary>
        int TotalRolls { get; }

        /// <summary>
        /// Adds the number of pins dropped after each roll
        /// </summary>
        /// <param name="pins"></param>
        void AddRoll(int pins);

        /// <summary>
        /// Number of pins dropped on the particular roll
        /// </summary>
        /// <param name="rollIndex"></param>
        /// <returns>Number of pins</returns>
        int GetPinsByRollIndex(int rollIndex);

        /// <summary>
        /// To reset the store
        /// </summary>
        void Clear();
    }
}
