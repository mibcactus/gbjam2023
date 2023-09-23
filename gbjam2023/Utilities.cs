using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public static class MathsUtil {
    // put sin, cos etc quick definintions here - more efficient than just calculating each frame
}
    
public class DependencyContainer {
    private readonly ContentManager _content;
    public readonly SpriteBatch _spriteBatch;
    public bool exitgame = false;
    
    public bool state_changed = false;
    public bool level_won = false;

    //public State new_state;
    public int new_state_ID;
    
    public DependencyContainer(ContentManager _c, SpriteBatch _sp) {
        _content = _c;
        _spriteBatch = _sp;
    }

    
    public void updateState(int state) {
        new_state_ID = state;
        state_changed = true;
    }

    public Texture2D LoadTexture2D(string filename) {
        return _content.Load<Texture2D>(filename);
    }
}