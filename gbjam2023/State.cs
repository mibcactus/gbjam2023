using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023;

public abstract class State {
    //protected ContentManager Content;
    protected Texture2D bg_texture;
    //protected SpriteBatch _spriteBatch;

    public DependencyContainer dependents;

    public State(DependencyContainer _d) {
        dependents = _d;
    }

    //public abstract void Initialise();
    //public abstract void LoadContent();
    public abstract void Update(GameTime _gt);
    public abstract void Draw(GameTime _gt);

    public Texture2D GetBackground() {
        return bg_texture;
    }

    public void SetBackground(Texture2D _t) {
        bg_texture = _t;
    }
}

// base state for each level
// figure out how raycasting works
public abstract class LevelState : State {
    protected LevelState(DependencyContainer _d) : base(_d) {
        
    }
    
    public override void Update(GameTime _gt) {
        throw new System.NotImplementedException();
    }

    public override void Draw(GameTime _gt) {
        throw new System.NotImplementedException();
    }
}