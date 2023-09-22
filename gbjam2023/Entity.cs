using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gbjam2023;
/*
public interface IDependencyContainer {
    void Register<T>(T _dependency);
    T Get<T>();
}

public class EntityDependenceContainer : IDependencyContainer {
    private ContentManager GlobalContent;
    public void Register<T>(T _dependency) {
        GlobalContent = _dependency;
    }

    public T Get<T>() {
        throw new NotImplementedException();
    }
}
*/

public abstract class Entity {
    private Vector2 position;     // top left corner of the entity
    private Texture2D texture;    // default texture in case the animation doesn't load
    private Animation animation;  // what should ideally be drawn
    private DependencyContainer dependant;

    // https://community.monogame.net/t/passing-the-contentmanager-to-every-class-feels-wrong-is-it/10470/11
    // read up on this

    public Entity(Vector2 _p, DependencyContainer _dc) {
        position = _p;
        dependant = _dc;
    }
    
    public void SetLocation(Vector2 _v) {
        position = _v;
    }

    // only here just in case
    public void SetLocation(int _x, int _y) {
        position = new Vector2(_x, _y);
    }

    public abstract void Update();

    public abstract void Draw();
}


public class Button : Entity {
    private State new_state;
    private string label;

    // TODO: Finish button constructor
    public Button(Vector2 _p, string _l, DependencyContainer _dc) : base(_p, _dc) {
        label = _l;
    }
    
    void ButtonAction() {
        throw new System.NotImplementedException();
    }

    public override void Update() {
        throw new NotImplementedException();
    }

    public override void Draw() {
        throw new NotImplementedException();
    }
}