using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public static class MathsUtil {
    // put sin, cos etc quick definintions here - more efficient than just calculating each frame
}
    
public class DependencyContainer {
    private readonly ContentManager _content;
    public readonly SpriteBatch _spriteBatch;
    public bool exit_game = false;
    
    public bool state_changed = false;
    public bool level_won = false;

    public DateTime timeLastPressed;

    //public State new_state;
    public int new_state_ID;
    
    public DependencyContainer(ContentManager _c, SpriteBatch _sp) {
        _content = _c;
        _spriteBatch = _sp;
        timeLastPressed = DateTime.Now;
    }

    public bool hasInputBufferTimePassed() {
        if (DateTime.Now > timeLastPressed.AddSeconds(0.2)) {
            return true;
        }

        return false;
    }
    
    public void updateState(int state) {
        new_state_ID = state;
        state_changed = true;
    }

    public Texture2D LoadTexture2D(string filename) {
        return _content.Load<Texture2D>(filename);
    }
}