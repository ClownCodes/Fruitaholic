/* Basket.cs
 * For the only basket in both Appetizer and Sugar Bomb
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fruitaholic
{
    /// <summary>
    /// moves
    /// </summary>
    internal class Basket : DrawableGameComponent
    {
        private static Texture2D basketTex = Shared.game.Content.Load<Texture2D>("images/Basket");
        private Vector2 position = new Vector2(Shared.stage.X / 2 - basketTex.Width / 2, Shared.stage.Y - basketTex.Height);
        private Vector2 displacement = new Vector2(8, 0);
        internal Rectangle getBounds()
        {
            return new Rectangle((int)position.X + basketTex.Width / 4, (int)position.Y + basketTex.Height / 2, basketTex.Width / 2, basketTex.Height / 8);
        }

        internal Basket(Game game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= displacement;
                if (position.X < 0)
                {
                    position = new Vector2(0, position.Y);
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += displacement;
                if (position.X > Shared.stage.X - basketTex.Width)
                {
                    this.position = new Vector2(Shared.stage.X - basketTex.Width, position.Y);
                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            Shared.spriteBatch.Draw(basketTex, position, Color.White);
            Shared.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
