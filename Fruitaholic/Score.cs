/* Score.cs
 * The CurrentScore and the HighestScore
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using System.IO;

namespace Fruitaholic
{
    /// <summary>
    /// reads the scores from the file and draws the CurrentScore when the ActionScene initializes it
    /// </summary>
    internal class Score : DrawableGameComponent
    {
        internal static int HighestScore { get; set; } = 0; //where to place?
        internal static int CurrentScore { get; set; } = 0;
        internal Score(Game game) : base(game)
        {
            if (File.Exists(Shared.path))
            {
                using (StreamReader sr = File.OpenText(Shared.path))
                {
                    int[] scores = new int[2];
                    while (!sr.EndOfStream)
                    {
                        for (int i = 0; i < scores.Length; i++)
                        {
                            scores[i] = int.Parse(sr.ReadLine());
                        }
                    }
                    HighestScore = scores[0];
                    CurrentScore= scores[1];
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            Shared.spriteBatch.DrawString(Shared.regularFont, $"Your fruits: {CurrentScore}", new Vector2(25, 35), Color.Red);
            Shared.spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
