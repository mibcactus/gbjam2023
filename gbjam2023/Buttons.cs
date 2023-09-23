using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public abstract class Button : Entity {
    //protected State new_state;
    protected int new_state_ID;
    protected Texture2D selected_texture;
    public bool selected = false;
    public bool pressed = false;

    // TODO: Finish button constructor
    protected Button(Vector2 _p, Texture2D _t, int _newState , DependencyContainer _dc) : base(_p, _t, _dc) {
        new_state_ID = _newState;
    }

    //public void SetSelected() { selected = !selected; }

    public bool isSelected() {
        return selected;
    }

    protected virtual void ButtonAction() {
        dependant.updateState(new_state_ID);
    }


    public override void Update() {
        if (pressed) {
            ButtonAction();
            this.pressed = false; //releases the button once done
        }
    }

    public override void Draw() {
        if (selected) {
            dependant._spriteBatch.Draw(selected_texture, position, Color.White);
        } else {
            dependant._spriteBatch.Draw(texture, position, Color.White);
        }
        
        
    }
}
public class nextButton : Button{
    public nextButton(Vector2 _p, int _newState, DependencyContainer _dc) 
        : base(_p, _dc.LoadTexture2D("next_button_A"), _newState, _dc) {
        selected_texture = dependant.LoadTexture2D("next_button_B");
    }

    protected override void ButtonAction() {
    }
}

public class menuButton : Button {
    public menuButton(Vector2 _p, DependencyContainer _dc) : base(_p, _dc.LoadTexture2D("menu_button_A"), 0, _dc) {
        selected_texture = dependant.LoadTexture2D("menu_button_B");
    }
}

public class exitButton : Button {
    public exitButton(Vector2 _p, DependencyContainer _dc) : base(_p, _dc.LoadTexture2D("exit_button_A"), 0, _dc) {
        selected_texture = dependant.LoadTexture2D("exit_button_B");
    }

    protected override void ButtonAction() {
        dependant.exit_game = true;
    }
}


public class creditsButton : Button {
    public creditsButton(Vector2 _p, DependencyContainer _dc) 
        : base(_p, _dc.LoadTexture2D("credits_button_A"), 1, _dc) {
        selected_texture = dependant.LoadTexture2D("credits_button_B");
    }

    protected override void ButtonAction() {
        dependant.updateState(1); //1 is for credits
    }
}
