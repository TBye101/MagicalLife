using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Rendering.Map;
using Microsoft.Xna.Framework;

public class Camera
{
    // Centered Position of the Camera in pixels.
    public Vector2 Position { get; private set; }

    // Current Zoom level with 1.0f being standard
    public float Zoom { get; private set; }

    // Current Rotation amount with 0.0f being standard orientation
    private float Rotation { get; set; } = 0;

    // Height and width of the viewport window which we need to adjust
    // any time the player resizes the game window.
    public int ViewportWidth { get; set; }

    public int ViewportHeight { get; set; }

    public int Dimension { get; set; } = -1;

    /// <summary>
    /// The width of the dimension in tiles.
    /// </summary>
    public int DimensionWidth { get; set; }

    /// <summary>
    /// The height of the dimension in tiles.
    /// </summary>
    public int DimensionHeight { get; set; }

    // Center of the Viewport which does not account for scale
    public Vector2 ViewportCenter
    {
        get
        {
            return new Vector2(this.ViewportWidth * 0.5f, this.ViewportHeight * 0.5f);
        }
    }

    // Create a matrix for the camera to offset everything we draw,
    // the map and our objects. since the camera coordinates are where
    // the camera is, we offset everything by the negative of that to simulate
    // a camera moving. We also cast to integers to avoid filtering artifacts.
    public Matrix TranslationMatrix
    {
        get
        {
            return Matrix.CreateTranslation(-(int)this.Position.X,
               -(int)this.Position.Y, 0) *
               Matrix.CreateRotationZ(this.Rotation) *
               Matrix.CreateScale(new Vector3(this.Zoom, this.Zoom, 1)) *
               Matrix.CreateTranslation(new Vector3(this.ViewportCenter, 0));
        }
    }

    // Construct a new Camera class with standard zoom (no scaling)
    public Camera()
    {
        this.Zoom = 1.0f;
        World.ChangeCameraDimension += this.World_ChangeCameraDimension;
    }

    private void World_ChangeCameraDimension(object sender, int e)
    {
        this.InitializeForDimension(e);
    }

    public void InitializeForDimension(int dimension)
    {
        this.Dimension = dimension;
        this.DimensionWidth = World.Dimensions[dimension].Width;
        this.DimensionHeight = World.Dimensions[dimension].Height;
    }

    // Call this method with negative values to zoom out
    // or positive values to zoom in. It looks at the current zoom
    // and adjusts it by the specified amount. If we were at a 1.0f
    // zoom level and specified -0.5f amount it would leave us with
    // 1.0f - 0.5f = 0.5f so everything would be drawn at half size.
    internal void AdjustZoom(float amount)
    {
        this.Zoom += amount;
        if (this.Zoom < 0.25f)
        {
            this.Zoom = 0.25f;
        }
        if (this.Zoom > 4f)
        {
            this.Zoom = 4f;
        }
    }

    /// <summary>
    /// Move the camera in an X and Y amount based on the <paramref name="cameraMovement"/> parameter.
    /// If <paramref name="clampToMap"/> is true the camera will try not to pan outside of the bounds of the map.
    /// </summary>
    /// <param name="cameraMovement"></param>
    /// <param name="clampToMap"></param>
    public void MoveCamera(Vector2 cameraMovement, bool clampToMap)
    {
        Vector2 newPosition = this.Position + cameraMovement;

        if (clampToMap)
        {
            this.Position = this.MapClampedPosition(newPosition);
        }
        else
        {
            this.Position = newPosition;
        }
    }

    public Rectangle ViewportWorldBoundry()
    {
        Vector2 viewPortCorner = this.ScreenToWorld(new Vector2(0, 0));
        Vector2 viewPortBottomCorner =
           this.ScreenToWorld(new Vector2(this.ViewportWidth, this.ViewportHeight));

        return new Rectangle((int)viewPortCorner.X,
           (int)viewPortCorner.Y,
           (int)(viewPortBottomCorner.X - viewPortCorner.X),
           (int)(viewPortBottomCorner.Y - viewPortCorner.Y));
    }

    // Center the camera on specific pixel coordinates
    public void CenterOn(Vector2 position)
    {
        this.Position = position;
    }

    // Center the camera on a specific cell in the map
    public void CenterOn(Point2D tileLocation)
    {
        this.Position = this.CenteredPosition(tileLocation, true);
    }

    private Vector2 CenteredPosition(Point2D tileLocation, bool clampToMap = false)
    {
        Vector2 cameraPosition = new Vector2(tileLocation.X * Tile.GetTileSize().X,
           tileLocation.Y * Tile.GetTileSize().Y);

        Vector2 cameraCenteredOnTilePosition = new Vector2(cameraPosition.X + Tile.GetTileSize().X / 2,
               cameraPosition.Y + Tile.GetTileSize().Y / 2);

        if (clampToMap)
        {
            return this.MapClampedPosition(cameraCenteredOnTilePosition);
        }

        return cameraCenteredOnTilePosition;
    }

    // Clamp the camera so it never leaves the visible area of the map.
    private Vector2 MapClampedPosition(Vector2 position)
    {
        Vector2 cameraMax = new Vector2(this.DimensionWidth * Tile.GetTileSize().X -
            (this.ViewportWidth / this.Zoom / 2),
            this.DimensionHeight * Tile.GetTileSize().Y -
            (this.ViewportHeight / this.Zoom / 2));

        return Vector2.Clamp(position,
           new Vector2(this.ViewportWidth / this.Zoom / 2, this.ViewportHeight / this.Zoom / 2),
           cameraMax);
    }

    public Vector2 WorldToScreen(Vector2 worldPosition)
    {
        return Vector2.Transform(worldPosition, this.TranslationMatrix);
    }

    /// <summary>
    /// Converts screen coordinates into a non scaled, non offset coordinate.
    /// </summary>
    /// <param name="screenPosition"></param>
    /// <returns></returns>
    public Vector2 ScreenToWorld(Vector2 screenPosition)
    {
        Vector2 test = Vector2.Transform(screenPosition,
            Matrix.Invert(this.TranslationMatrix));

        return test;
    }

    /// <summary>
    /// Move the camera's position based on input
    /// </summary>
    /// <param name="inputState"></param>
    internal void HandleInput(CameraMovementState inputState)
    {
        Vector2 cameraMovement = Vector2.Zero;

        switch (inputState)
        {
            case CameraMovementState.Left:
                cameraMovement.X = -1;
                break;

            case CameraMovementState.Right:
                cameraMovement.X = 1;
                break;

            case CameraMovementState.Up:
                cameraMovement.Y = -1;
                break;

            case CameraMovementState.Down:
                cameraMovement.Y = 1;
                break;

            case CameraMovementState.ZoomIn:
                this.AdjustZoom(-0.25f);
                break;

            case CameraMovementState.ZoomOut:
                this.AdjustZoom(0.25f);
                break;

            default:
                throw new UnexpectedEnumMemberException();
        }

        // When using a controller, to match the thumbstick behavior,
        // we need to normalize non-zero vectors in case the user
        // is pressing a diagonal direction.
        if (cameraMovement != Vector2.Zero)
        {
            cameraMovement.Normalize();
        }

        // scale our movement to move 25 pixels per second
        cameraMovement *= 25f;

        this.MoveCamera(cameraMovement, false);
    }
}