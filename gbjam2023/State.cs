using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023;

public abstract class State {
    protected Texture2D bg_texture;
    public DependencyContainer dependents;

    public Button[] buttons;

    protected State(DependencyContainer _d) {
        dependents = _d;
    }

    //public abstract void Initialise();
    //public abstract void LoadContent();
    public abstract void Update(GameTime _gt);

    public abstract void drawUI();
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