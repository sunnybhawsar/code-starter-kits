namespace BowlingBall
{
    public interface IGame
    {
        /// <summary>
        /// Keeps the track of pins dropped after each roll
        /// </summary>
        /// <param name="pins"></param>
        void Roll(int pins);

        /// <summary>
        /// Calculates the score based on the rolls
        /// </summary>
        /// <returns>Returns the final score of the game</returns>
        int GetScore();

        /// <summary>
        /// Resets the game
        /// </summary>
        void Reset();
    }
}
