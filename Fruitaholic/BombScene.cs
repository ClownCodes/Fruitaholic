/* BombScene.cs
 * The child of ActionScene for Sugar Bomb
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;

namespace Fruitaholic
{
    /// <summary>
    /// adds bombs to the scene
    /// </summary>
    internal class BombScene : ActionScene
    {
        private Bomb bomb;
        private int bombDelayCounter;

        internal BombScene(Game game) : base(game)
        {
        }
        public override void Update(GameTime gameTime)
        {
            bombDelayCounter++;
            if (bombDelayCounter >= delay * 10)
            {
                bomb = new Bomb(Shared.game);
                this.components.Add(bomb);

                bombDelayCounter = 0;
            }

            base.Update(gameTime);
        }
    }
}
