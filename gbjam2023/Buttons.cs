using Microsoft.Xna.Framework;

namespace gbjam2023; 

public class nextButton : Button{
    public nextButton(Vector2 _p, State _newState, DependencyContainer _dc) 
        : base(_p, _dc.LoadTexture2D("next_button_A"), _newState, _dc) {
        selected_texture = dependant.LoadTexture2D("next_button_B");
    }

    protected override void ButtonAction() {
        throw new System.NotImplementedException();
    }
}

public class exitButton : Button {
    public exitButton(Vector2 _p, DependencyContainer _dc)
        : base(_p, _dc.LoadTexture2D("exit_button_A"), null, _dc) {
    }

    protected override void ButtonAction() {
        dependant.exitgame = true;
    }
}

public class creditsButton : Button {
    public creditsButton(Vector2 _p, DependencyContainer _dc) 
        : base(_p, _dc.LoadTexture2D("credits_button_A"), new CreditsState(_dc), _dc) {
        selected_texture = dependant.LoadTexture2D("credits_button_B");
    }

    protected override void ButtonAction() {
        throw new System.NotImplementedException();
    }
}