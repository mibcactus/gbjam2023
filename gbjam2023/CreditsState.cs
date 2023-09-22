using System;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class CreditsState : MenuState {
    public CreditsState(DependencyContainer _d) : base(_d) {
        Console.WriteLine("Constructing credits state");
        //SetBackground(dependents.LoadTexture2D("credits_bg"));
        //SetBackground(dependents._content.Load<Texture2D>("test_bg"));
        Console.WriteLine("Background set successfully");
    }
    
}