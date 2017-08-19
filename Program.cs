using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Tetriz.Game.Scene;

namespace Tetriz
{
    public class GameWindow : OpenTK.GameWindow
    {

        private SceneManager _sceneManager;

        [STAThread]
        public static void Main(string[] args)
        {
            using (GameWindow game = new GameWindow())
            {
                game.Run();
            }
        }

        public GameWindow()
            // set window resolution, title, and default behaviour
            : base(1280, 720, GraphicsMode.Default, "Tetriz",
            GameWindowFlags.Default, DisplayDevice.Default,
            // ask for an OpenGL 3.0 forward compatible context
            3, 0, GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("gl version: " + GL.GetString(StringName.Version));
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Alt && e.Key == Key.F4)
            {
                Environment.Exit(0);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            // this is called when the window starts running
            _sceneManager = SceneManagerFactory.Produce(this);
            //_sceneManager.LoadScene("menu");
            _sceneManager.LoadScene("board");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            _sceneManager.CurrenctScene.OnUpdate();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color4.Aqua);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _sceneManager.OnRenderFrame();

            this.SwapBuffers();
        }
    }
}
