using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gbjam2023;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private RenderTarget2D _nativeRenderTarget;
    private SpriteBatch _spriteBatch;
    private Rectangle _actualScreenRectangle;
    
    private int screenWidth = 160;
    private int screenHeight = 144;
    private int scaleSize = 5;


    // disgusting test code, to be removed eventually
    private Texture2D testsmile;
    private Vector2 testposition;
    private int updateX = 1;

    private Texture2D testbg;
    
    public Game1()
    {
        // Creates the window that displays the actual game, but the graphics are first rendered
        // to _actualScreenRectangle first then upscaled to _graphics
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = screenWidth * scaleSize;
        _graphics.PreferredBackBufferHeight = screenHeight *  scaleSize;

        // where graphics are initally rendered to
        _actualScreenRectangle = new Rectangle(0, 0, screenWidth * scaleSize, screenHeight * scaleSize);
        
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _nativeRenderTarget = new RenderTarget2D(GraphicsDevice, screenWidth, screenHeight);
        
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        
        // this is how you load any file, no need for the file type at the end, make sure you've loaded 
        // it into MGCB first :)
        testsmile = Content.Load<Texture2D>("testsmile");
        testbg = Content.Load<Texture2D>("testbg");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        testposition.X += updateX;
        if(testposition.X >= screenWidth - testsmile.Width) {
            updateX = -1;
        } else if (testposition.X <= 0) {
            updateX = 1;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        
        // have to draw sprites in batches otherwise it crashes
        // otherwise drawn in order specififed
        _spriteBatch.Begin();
        _spriteBatch.Draw(testbg, Vector2.Zero, Color.White);
        _spriteBatch.Draw(testsmile, testposition, Color.White);
        _spriteBatch.End();
        
        base.Draw(gameTime);
        
        
        
        // this block of code upscales the image by the scale size
        // see more here https://community.monogame.net/t/solved-scaling-zooming-game-window/7824/5
        
        GraphicsDevice.SetRenderTarget(null);
        // RenderTarget2D inherits from Texture2D so we can render it just like a texture

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_nativeRenderTarget, _actualScreenRectangle, Color.White);
        _spriteBatch.End();
    }
}