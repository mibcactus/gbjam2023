using Microsoft.Xna.Framework;

namespace gbjam2023; 

public class MenuState : State {
    protected exitButton _exitButton;
    private int counter = 0;
    private int update_test = 0;
    
    public MenuState(DependencyContainer _d) : base(_d) {
        SetBackground(dependents.LoadTexture2D("menu_bg"));
        _exitButton = new exitButton(new Vector2(50, 50), dependents);
    }

    public override void Update(GameTime _gt) {
    }

    public override void drawUI() {
        _exitButton.Draw();
    }

    public override void Draw(GameTime _gt) {
        dependents._spriteBatch.Draw(GetBackground(), Vector2.Zero, Color.White);
        drawUI();
    }
}