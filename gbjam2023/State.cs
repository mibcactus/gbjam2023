using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023;

public abstract class State {
    protected ContentManager Content;
    protected Texture2D bg_texture;

    public State(ContentManager _c) {
        Content = _c;
    }

    //public abstract void Initialise();
    //public abstract void LoadContent();
    public abstract void Update();
    public abstract void Draw();

    public Texture2D GetBackground() {
        return bg_texture;
    }

    public void SetBackground(Texture2D _t) {
        bg_texture = _t;
    }
}