using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class MenuState : State {
    public MenuState(ContentManager _c) : base(_c) {
        SetBackground(Content.Load<Texture2D>("menu_bg"));
    }

    public override void Update() {
        throw new System.NotImplementedException();
    }

    public override void Draw() {
        throw new System.NotImplementedException();
    }
}