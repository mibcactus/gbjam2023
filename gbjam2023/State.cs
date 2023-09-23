using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gbjam2023;

public abstract class State {
    protected Texture2D bg_texture;
    public DependencyContainer dependents;

    public Button[] buttons_list;
    public int selected_button = 0;

    protected State(DependencyContainer _d) {
        dependents = _d;
    }
    
    public virtual void Update(GameTime _gt) {
        if(dependents.hasInputBufferTimePassed()) {
            if (Keyboard.GetState().IsKeyDown(Keys.E)) {
                buttons_list[selected_button].pressed = true;
                dependents.timeLastPressed = DateTime.Now;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.W)) {
                buttons_list[selected_button].selected = false;
                if (selected_button >= buttons_list.Length - 1) {
                    selected_button = 0;
                }
                else {
                    selected_button++;
                }

                buttons_list[selected_button].selected = true;
                dependents.timeLastPressed = DateTime.Now;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.S)) {
                buttons_list[selected_button].selected = false;
                if (selected_button == 0) {
                    selected_button = buttons_list.Length;
                }

                selected_button--;
                buttons_list[selected_button].selected = true;
                dependents.timeLastPressed = DateTime.Now;
            }
        }

        foreach (var button in buttons_list) {
            button.Update();
        }
    }

    public virtual void drawUI() {
        foreach (var button in buttons_list) {
            button.Draw();
        }
    }
    public abstract void Draw(GameTime _gt);

    public Texture2D GetBackground() {
        return bg_texture;
    }

    public void SetBackground(Texture2D _t) {
        bg_texture = _t;
    }
}

// base state for each level
// figure out how raycasting works
public abstract class LevelState : State {
    protected LevelState(DependencyContainer _d) : base(_d) {
        
    }
    
    public void Update(GameTime _gt) {
        base.Update(_gt);
    }

    public override void Draw(GameTime _gt) {
        throw new System.NotImplementedException();
    }
}