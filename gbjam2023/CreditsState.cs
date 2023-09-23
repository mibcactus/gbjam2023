using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class CreditsState : MenuState {
    public CreditsState(DependencyContainer _d) : base(_d) {
        SetBackground(dependents.LoadTexture2D("credits_bg"));
        buttons_list = new Button[] {
            new menuButton(new Vector2(20, 124), _d)
        };
    }

    public override void Draw(GameTime _gt) {
        dependents._spriteBatch.Draw(GetBackground(), Vector2.Zero, Color.White);
        base.Draw(_gt);
    }
}