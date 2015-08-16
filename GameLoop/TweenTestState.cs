using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class TweenTestState : IGameObject
    {
        Tween _tween = new Tween(0, 256, 5);
        Tween _alphaTween = new Tween(0, 1, 5, Tween.EaseInCirc);
        Color _color = new Color(1, 1, 1, 0);


        sprite _sprite = new sprite();
        Renderer _renderer = new Renderer();
        public TweenTestState(TextureManager textureManager)
        {
            _sprite.Texture = textureManager.Get("face");
           

            for (int i = 0; i < 10; i++)
            {
                _sprite.SetRotation(i);
            }
            
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_sprite);
            _renderer.Render();

        }

        public void Update(double elapsedTime)
        {
            if (_tween.IsFinished() != true)
            {
                _tween.Update(elapsedTime);
                _sprite.SetWidth((float)_tween.Value());
                _sprite.SetHeight((float)_tween.Value());
            }

            // This additional alpha tween has been added.
            if (_alphaTween.IsFinished() != true)
            {
                _alphaTween.Update(elapsedTime);
                _color.Alpha = (float)_alphaTween.Value();
                _sprite.SetColor(_color);
            }
        }



    }
}
