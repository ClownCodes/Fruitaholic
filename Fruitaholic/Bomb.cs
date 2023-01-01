/* Bomb.cs
 * For the bombs in Sugar Bomb
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Fruitaholic
{
    /// <summary>
    /// handles collision with the basket and click
    /// </summary>
    internal class Bomb : Weight
    {
        private SoundEffect failureEffect = Shared.game.Content.Load<SoundEffect>("sound/failure");

        //private Rectangle fruitRec = new Rectangle((int)position.X, (int)position.Y, fruitTex.Width, fruitTex.Height);
        internal Bomb(Game game) : base(game)
        {
        }

        protected override Texture2D Tex => Shared.game.Content.Load<Texture2D>("images/Bomb");

        protected override SoundEffect PointGainedEffect => Shared.game.Content.Load<SoundEffect>("sound/points");

        public override void Update(GameTime gameTime)
        {
            Rectangle basketRect = Shared.basket.getBounds();
            if (this.getBounds().Intersects(basketRect))
            {
                failureEffect.Play();
                Score.CurrentScore = 0;
                Remove();
            }

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && this.getBounds().Contains(ms.X, ms.Y))
            {
                Rectangle rectangle = this.getBounds();
                rectangle.Width *= 2;
                rectangle.Height *= 2;
                Explosion exp = new Explosion(Shared.game, rectangle);
                Shared.game.Components.Add(exp);

                PointGainedEffect.Play();
                Score.CurrentScore += 10;
                Remove();
            }
            base.Update(gameTime);
        }
    }

}
