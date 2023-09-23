using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gbjam2023; 

public class MenuState : State {
    private int counter = 0;
    
    // disgusting test code, to be removed eventually
    private Texture2D testsmile;
    private Vector2 testposition;
    private int updateX = 1;
    
    

    public MenuState(DependencyContainer _d) : base(_d) {
        SetBackground(dependents.LoadTexture2D("menu_bg"));
        buttons_list = new Button[] {
            new    exitButton(new Vector2(50, 124), dependents), 
            new creditsButton(new Vector2(50, 104), dependents)
        };
        selected_button = 1;
        testsmile = dependents.LoadTexture2D("testsmile");
        testposition.Y = 80;
    }

    public override void Update(GameTime _gt) {
        if(counter % 2 == 0) {
            testposition.X += updateX;
            if (testposition.X >= 160 - testsmile.Width) {
                updateX = -1;
            }
            else if (testposition.X <= 0) {
                updateX = 1;
            }
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
            buttons_list[selected_button].pressed = true;
        } else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.W)) {
            buttons_list[selected_button].selected = false;
            if (selected_button == buttons_list.Length - 1) {
                selected_button = 0;
            }
            else {
                selected_button++;
            }
            buttons_list[selected_button].selected = true;
        } else if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.S)) {
            buttons_list[selected_button].selected = false;
            if (selected_button == 0) {
                selected_button = buttons_list.Length;
            }
            selected_button--; 
            buttons_list[selected_button].selected = true;
        }

        
    }

    public override void drawUI() {
        foreach (var button in buttons_list) {
            button.Draw();
        }
    }

    public override void Draw(GameTime _gt) {
        dependents._spriteBatch.Draw(GetBackground(), Vector2.Zero, Color.White);
        dependents._spriteBatch.Draw(testsmile, testposition, Color.Green);
        drawUI();
    }
}