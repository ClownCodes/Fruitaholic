/* StartScene.cs
 * The Scene that first shows
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Fruitaholic
{
    /// <summary>
    /// initializes the menu
    /// </summary>
    internal class StartScene : GameScene
    {
        internal Menu menu { get; set; }
        string[] menuItems = {"Appetizer", "Sugar Bomb", "Help", "About", "Quit" };

        internal StartScene(Game game) : base(game)
        {
            menu = new Menu(game, menuItems);
            this.components.Add(menu);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume= 0.1f;
            MediaPlayer.Play(Shared.game.Content.Load<Song>("sound/cute"));
        }
    }
}
