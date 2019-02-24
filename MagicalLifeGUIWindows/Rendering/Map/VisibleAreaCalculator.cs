using MagicalLifeAPI.Components.Generic.Renderable;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Used to calculate the visible area of the camera.
    /// </summary>
    public class VisibleAreaCalculator
    {
        private Rectangle VisibleArea;
        private Rectangle CameraBounds;

        private Vector2 Tl;
        private Vector2 Tr;
        private Vector2 Bl;
        private Vector2 Br;

        private Vector2 CameraXPosition;
        private Vector2 CameraYPosition;
        private Vector2 CameraWidthHeight;

        private Vector2 Min;
        private Vector2 Max;

        public VisibleAreaCalculator()
        {
            this.VisibleArea = new Rectangle(0, 0, 0, 0);
            this.CameraBounds = new Rectangle(0, 0, 0, 0);
            this.CameraXPosition = new Vector2(0, 0);
            this.CameraYPosition = new Vector2(0, 0);
            this.CameraWidthHeight = new Vector2(0, 0);
            this.Min = new Vector2(0, 0);
            this.Max = new Vector2(0, 0);
        }

        public Rectangle CalculateVisibleArea()
        {
            this.UpdateVisibleArea();
            return this.VisibleArea;
        }

        private void UpdateVisibleArea()
        {
            this.CameraBounds.X = (int)RenderInfo.Camera2D.Position.X;
            this.CameraBounds.Y = (int)RenderInfo.Camera2D.Position.Y;
            this.CameraBounds.Width = RenderInfo.Camera2D.ViewportWidth;
            this.CameraBounds.Height = RenderInfo.Camera2D.ViewportHeight;

            Matrix inverseViewMatrix = Matrix.Invert(RenderInfo.Camera2D.TranslationMatrix);

            this.CameraXPosition.X = this.CameraBounds.X;
            this.CameraYPosition.Y = this.CameraBounds.Y;
            this.CameraWidthHeight.X = this.CameraBounds.Width;
            this.CameraWidthHeight.Y = this.CameraBounds.Height;

            this.Tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            this.Tr = Vector2.Transform(this.CameraXPosition, inverseViewMatrix);
            this.Bl = Vector2.Transform(this.CameraYPosition, inverseViewMatrix);
            this.Br = Vector2.Transform(this.CameraWidthHeight, inverseViewMatrix);

            this.Min.X = MathHelper.Min(this.Tl.X, MathHelper.Min(this.Tr.X, MathHelper.Min(this.Bl.X, this.Br.X)));
            this.Min.Y = MathHelper.Min(this.Tl.Y, MathHelper.Min(this.Tr.Y, MathHelper.Min(this.Bl.Y, this.Br.Y)));

            this.Max.X = MathHelper.Max(this.Tl.X, MathHelper.Max(this.Tr.X, MathHelper.Max(this.Bl.X, this.Br.X)));
            this.Max.Y = MathHelper.Max(this.Tl.Y, MathHelper.Max(this.Tr.Y, MathHelper.Max(this.Bl.Y, this.Br.Y)));

            this.VisibleArea.X = (int)this.Min.X;
            this.VisibleArea.Y = (int)this.Min.Y;
            this.VisibleArea.Width = (int)(this.Max.X - this.Min.X);
            this.VisibleArea.Height = (int)(this.Max.Y - this.Min.Y);
        }
    }
}