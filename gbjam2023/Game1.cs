using System;
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
    private DependencyContainer _dependencyContainer;
    
    private int screenWidth = 160;
    private int screenHeight = 144;
    private int scaleSize = 5;
    
    // States
    private State state;
    
    // list of states so I don't have to keep reloading data?
    // States:
    // 0 - Menu
    // 1 - Credits
    private State[] statelist;
    

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

        //Content = GlobalContentManager.Content;
        Content.RootDirectory = "Content";

        IsMouseVisible = true;
    }

    // initialise and loadcontent are only called once
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _nativeRenderTarget = new RenderTarget2D(GraphicsDevice, screenWidth, screenHeight);
        
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here - this method is called once at the beginning when the game starts
        
        // this is how you load any file, no need for the file type at the end, make sure you've loaded 
        // it into MGCB first :)
        
        _dependencyContainer = new DependencyContainer(Content, _spriteBatch);

        // see declaration of statelist to see what each index should be
        // causes game to crash if uncommented rn, probably due to being unfinished
        //statelist = new State[] {new MenuState(_dependencyContainer), new CreditsState(_dependencyContainer)};
        Console.WriteLine("Constructing states");
        statelist = new State[] {new CreditsState(_dependencyContainer) };
        Console.WriteLine("States constructed");
        
        // change this once states are implemented
        // state = statelist[0];
        
        //testsmile = Content.Load<Texture2D>("testsmile");
        testsmile = _dependencyContainer.LoadTexture2D("testsmile");
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
        
        // TODO: implement state updates
        //state.Update(gameTime);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        
        // have to draw sprites in batches otherwise it crashes
        // otherwise drawn in order specified
        _spriteBatch.Begin();
        _spriteBatch.Draw(testbg, Vector2.Zero, Color.White);
        _spriteBatch.Draw(testsmile, testposition, Color.White);
        _spriteBatch.End();
        
        // TODO: implement state drawing
        //state.Draw(gameTime);
        
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