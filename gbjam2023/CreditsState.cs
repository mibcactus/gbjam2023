using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class CreditsState : MenuState {
    public CreditsState(ContentManager _c) : base(_c) {
        SetBackground(Content.Load<Texture2D>("credits_bg"));
    }

    public override void Update() {
        base.Update();
    }

    public override void Draw() {
        base.Draw();
    }
}