/* HelpScene.cs
 * A Scene that draws the author name
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;

namespace Fruitaholic
{
    /// <summary>
    /// draws the instruction to play the game
    /// </summary>
    internal class HelpScene : GameScene
    {
        internal HelpScene(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            Shared.spriteBatch.DrawString(Shared.regularFont, "Instruction: \n 1. Move the basket with left and right arrow keys to catch the falling fruits. " +
                "\n 2. Left click the falling bomb to see the coolest animation ever \n and gain big points. " +
                "\n 3. Be careful not to let bomb fall into your basket \n because that would blow away all your fruits. " +
                "\n\n Please email dwang6934@conestogac.on.ca if you need more help...", new Vector2(100, 100), Color.Black);
            Shared.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
