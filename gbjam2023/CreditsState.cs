using System;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class CreditsState : MenuState {
    public CreditsState(DependencyContainer _d) : base(_d) {
        SetBackground(dependents.LoadTexture2D("credits_bg"));
    }
    
}