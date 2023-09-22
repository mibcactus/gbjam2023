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
    public DependencyContainer(ContentManager _c, SpriteBatch _sp) {
        _content = _c;
        _spriteBatch = _sp;
    }

    public Texture2D LoadTexture2D(string filename) {
        return _content.Load<Texture2D>(filename);
    }
}