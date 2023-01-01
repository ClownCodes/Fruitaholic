/* GameScene.cs
 * Child of DrawableGameComponent, parent of all scenes
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fruitaholic
{
    /// <summary>
    /// draws all the DrawableGameComponents in the scene
    /// </summary>
    internal abstract class GameScene : DrawableGameComponent
    {
        internal List<GameComponent> components { get; set; }

        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        protected GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
            Shared.regularFont = game.Content.Load<SpriteFont>("fonts/regularFont");
            Shared.hilightFont = game.Content.Load<SpriteFont>("fonts/highlightFont");
        }
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime) //Where is it called?
        {
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                
                }
            }

            base.Draw(gameTime);
        }
    }
}
