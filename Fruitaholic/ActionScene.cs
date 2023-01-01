/* ActionScene.cs
 * The base scene for Appetizer, the parent of BombScene
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;

namespace Fruitaholic
{
    /// <summary>
    /// initializes the basket, the score, and the fruits; updates the HighestScore
    /// </summary>
    internal class ActionScene : GameScene
    {
        protected Fruit fruit;
        protected Score score;
        protected int fruitDelayCounter;
        protected int delay = 60;

        public ActionScene(Game game) : base(game)
        {
            if (Shared.basket == null) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                Shared.basket = new Basket(game); 
            }
            this.components.Add(Shared.basket);

            score = new Score(game);
            this.components.Add(score);
        }
        public override void Update(GameTime gameTime)
        {
            fruitDelayCounter++;
            if (fruitDelayCounter >= delay)
            {
                fruit = new Fruit(Shared.game);
                this.components.Add(fruit);

                fruitDelayCounter = 0;
            }

            if (Score.CurrentScore > Score.HighestScore)
            {
                Score.HighestScore = Score.CurrentScore;
            }

            base.Update(gameTime);
        }
    }
}
