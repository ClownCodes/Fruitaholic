/* AboutScene.cs
 * A Scene that draws the author name
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;

namespace Fruitaholic
{
    /// <summary>
    /// A Scene that draws the author name
    /// </summary>
    internal class AboutScene : GameScene
    {
        internal AboutScene(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            Shared.spriteBatch.DrawString(Shared.regularFont, "Author: Dany Wang", new Vector2(100, 100), Color.Black);
            Shared.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
