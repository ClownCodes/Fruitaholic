/* FruitaholicGame.cs
 * The game that organizes the scenes
 * Revision History:
 *      Dany Wang, 2022.11.23: Created
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Color = Microsoft.Xna.Framework.Color;

namespace Fruitaholic
{
    /// <summary>
    /// initializes, hides, shows all the scenes, and plays music when StartScene is active
    /// </summary>
    public class FruitaholicGame : Game
    {
        private GraphicsDeviceManager _graphics;

        private StartScene startScene;
        private ActionScene actionScene;
        private BombScene bombScene;
        private HelpScene helpScene;
        private AboutScene aboutScene;

        public FruitaholicGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Shared.game = this;
            //_graphics.ToggleFullScreen();
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            Shared.spriteBatch = new SpriteBatch(GraphicsDevice);

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            bombScene = new BombScene(this);
            this.Components.Add(bombScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);
        }

        private void hideAllScenes()
        {
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    GameScene gs = (GameScene)item;
                    gs.hide();
                    IsMouseVisible = false;
                }
            }
        }


        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.menu.selectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    actionScene.show();
                    MediaPlayer.Pause();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    IsMouseVisible = true;
                    bombScene.show();
                    MediaPlayer.Pause();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    using (StreamWriter sw = new StreamWriter(Shared.path))
                    {
                        sw.WriteLine(Score.HighestScore);
                        sw.WriteLine(Score.CurrentScore);
                    }
                    Exit();
                }
            }

            if (actionScene.Enabled || bombScene.Enabled || helpScene.Enabled || aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();

                    MediaPlayer.Resume();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}