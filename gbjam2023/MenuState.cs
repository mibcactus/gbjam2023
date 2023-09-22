using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class MenuState : State {
    public MenuState(DependencyContainer _d) : base(_d) {
        //SetBackground(Content.Load<Texture2D>("menu_bg"));
        //SetBackground(dependents.LoadTexture2D("menu_bg"));
        //dependents.Content.Load<Texture2D>("menu_bg");
    }

    public override void Update(GameTime _gt) {
        throw new System.NotImplementedException();
    }

    public override void Draw(GameTime _gt) {
        dependents._spriteBatch.Draw(GetBackground(), Vector2.Zero, Color.White);
    }
}