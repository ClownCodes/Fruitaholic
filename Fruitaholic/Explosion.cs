/* Explosion.cs
 * Initialized by a bomb after click
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fruitaholic
{
    /// <summary>
    /// draws the explosion animation
    /// </summary>
    internal class Explosion : DrawableGameComponent
    {
        private const int ROWS = 2;
        private const int COLS1 = 5;
        private const int COLS2 = 4;
        private const int Num = COLS1 + COLS2;

        private static Texture2D tex = Shared.game.Content.Load<Texture2D>("images/ExplosionSprite");
        private Vector2 dimension1 = new Vector2(tex.Width / COLS1, tex.Height / ROWS);
        private Vector2 dimension2 = new Vector2(tex.Width / COLS2, tex.Height / ROWS);
        private int delay = 3;
        private List<Rectangle> frames = new List<Rectangle>();
        private int frameIndex = -1;
        private Rectangle destinationRec;
        private int delayCounter;

        internal Explosion(Game game,
            Rectangle destinationRec) : base(game)
        {
            this.destinationRec = destinationRec;

            for (int i = 0; i < COLS1; i++)
            {
                Rectangle r = new Rectangle(i * (int)dimension1.X, 0,
                    (int)dimension1.X, (int)dimension1.Y);
                frames.Add(r);
            }
            for (int i = 0; i < COLS2; i++)
            {
                Rectangle r = new Rectangle(i * (int)dimension2.X, (int)dimension2.Y,
                    (int)dimension2.X, (int)dimension2.Y);
                frames.Add(r);
            }
        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > Num - 1)
                {
                    Shared.game.Components.Remove(this);
                }

                delayCounter = 0;
            }


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.spriteBatch.Begin();
            if (frameIndex >= 0)
            {
                //frames.ElementAt(frameIndex);
                Shared.spriteBatch.Draw(tex, destinationRec, frames[frameIndex], Color.White);
            }
            Shared.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
