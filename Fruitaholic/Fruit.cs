/* Fruit.cs
 * For the fruits in both Appetizer and Sugar Bomb
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Fruitaholic
{
    /// <summary>
    /// handles collision with the basket
    /// </summary>
    internal class Fruit : Weight
    {
        private static Texture2D[] fruits = new Texture2D[]
        {
            Shared.game.Content.Load<Texture2D>("images/Blueberry"),
            Shared.game.Content.Load<Texture2D>("images/Cherry"),
            Shared.game.Content.Load<Texture2D>("images/Cranberry"),
            Shared.game.Content.Load<Texture2D>("images/Kiwi"),
            Shared.game.Content.Load<Texture2D>("images/Lemon"),
            Shared.game.Content.Load<Texture2D>("images/Orange"),
            Shared.game.Content.Load<Texture2D>("images/Pear"),
            Shared.game.Content.Load<Texture2D>("images/Plum"),
            Shared.game.Content.Load<Texture2D>("images/Pomegranate"),
            Shared.game.Content.Load<Texture2D>("images/Raspberry"),
            Shared.game.Content.Load<Texture2D>("images/Watermelon")
        };

        private Texture2D tex = fruits[random.Next(fruits.Length)];

        protected override Texture2D Tex { get => tex; }
        protected override SoundEffect PointGainedEffect { get => Shared.game.Content.Load<SoundEffect>("sound/point"); }

        internal Fruit(Game game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle basketRect = Shared.basket.getBounds();
            if (this.getBounds().Intersects(basketRect))
            {
                PointGainedEffect.Play();
                Score.CurrentScore++;
                Remove();
            }

            base.Update(gameTime);
        }

    }
}
