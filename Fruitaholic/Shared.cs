/* Shared.cs
 * Static variables shared between classes
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Fruitaholic
{
    internal class Shared
    {
        internal static Game game;
        internal static Vector2 stage;
        internal static SpriteBatch spriteBatch;
        internal static SpriteFont regularFont;
        internal static SpriteFont hilightFont;
        internal static string path = Path.GetFullPath("record.txt");

        internal static Basket basket;
    }
}
