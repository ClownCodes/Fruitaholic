/* Weight.cs
 * The parent of Fruit and Bomb
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fruitaholic
{
    /// <summary>
    /// defines randomly falling fruit or bomb and its tranfromation
    /// </summary>
    internal abstract class Weight : DrawableGameComponent
    {
        internal static Random random = new Random();
        protected static int widthMargin = 50;
        protected Vector2 position = new Vector2(random.Next((int)Shared.stage.X - widthMargin), 0);
        protected Vector2 displacement = new Vector2(0, random.Next(2, 4));

        protected abstract Texture2D Tex { get; }
        protected abstract SoundEffect PointGainedEffect { get; }

        protected Weight(Game game) : base(game)
        {
        }

        protected Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, Tex.Width, Tex.Height);
        }
        protected void Remove()
        {
            //Shared.game.Components.Remove(this);
            this.Enabled = false;
            this.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            position += displacement;
            if (position.Y >= Shared.stage.Y)
            {
                Shared.game.Components.Remove(this);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            Shared.spriteBatch.Draw(Tex, position, Color.White);
            Shared.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
