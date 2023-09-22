using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023; 

public class Animation {
    private Texture2D spritesheet;
    private int columns, rows;
    private int current_frame = 0;
    private bool flipped = false;


    public Animation(Texture2D _t, int _c, int _r) {
        spritesheet = _t;
        columns = _c;
        rows = _r;
    }
    
    public int GetCurrentFrame() {
        return current_frame;
    }
    public void UpdateCurrentFrame(){}
    public void DrawCurrentFrame(){}
    
}