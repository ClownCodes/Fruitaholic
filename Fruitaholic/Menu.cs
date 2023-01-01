/* Menu.cs
 * The menu on the StartScene
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fruitaholic
{
    /// <summary>
    /// draws the menu on the StartScene and handles selection 
    /// </summary>
    internal class Menu : DrawableGameComponent
    {
        private List<string> menuItems;
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color hilightColor = Color.Red;
        internal int selectedIndex { get; set; }

        private KeyboardState oldState;

        internal Menu(Game game,
            string[] menus) : base(game)
        {
            menuItems = menus.ToList<string>();
            position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count )
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex  == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;

            Shared.spriteBatch.Begin();
            Shared.spriteBatch.DrawString(Shared.regularFont, $"Your Highest Score: {Score.HighestScore}", new Vector2(150, 150), Color.Red);

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    Shared.spriteBatch.DrawString(Shared.hilightFont, menuItems[i], 
                        tempPos, hilightColor);
                    tempPos.Y += Shared.hilightFont.LineSpacing;
                }
                else
                {
                    Shared.spriteBatch.DrawString(Shared.regularFont, menuItems[i],
                        tempPos, regularColor);
                    tempPos.Y += Shared.regularFont.LineSpacing;
                }
            }
            Shared.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
