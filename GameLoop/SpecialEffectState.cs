using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class SpecialEffectState : IGameObject
    {
        Font _font;
        Text _text;
        Renderer _renderer = new Renderer();
        double _totalTime = 0;

        public SpecialEffectState(TextureManager manager)
        {
            _font = new Font(manager.Get("font"), FontParser.Parse("font.fnt"));
            _text = new Text("Hello", _font);
        }
        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_text);
            _renderer.Render();
            
        }

        public void Update(double elapsedTime)
        {
            double frequency = 7;
            //float _wavyNumber = (float)Math.Sin(_totalTime * frequency);

            //_wavyNumber = 0.5f + _wavyNumber * 0.5f;
            //_text.SetColor(new Color(1, 0, 0, _wavyNumber));
            //float _wavyNumberR = (float)Math.Sin(_totalTime * frequency);
            //float _wavyNumberG = (float)Math.Cos(_totalTime * frequency);
            //float _wavyNumberB = (float)Math.Sin(_totalTime * frequency);

            //_wavyNumberR = 0.5f + _wavyNumberR * 0.5f;
            //_wavyNumberG = 0.5f + _wavyNumberG * 0.5f;
            //_wavyNumberB = 0.5f + _wavyNumberB * 0.5f;

            //_text.SetColor(new Color(_wavyNumberR, _wavyNumberG, _wavyNumberB, 1));

            //double _wavyNumberX = Math.Sin(_totalTime * frequency) * 15;
            //double _wavyNumberY = Math.Cos(_totalTime * frequency) * 15;

            //_text.SetPosition(_wavyNumberX, _wavyNumberY);

            int xAdvance = 0;
            foreach (CharacterSprite cs in _text.CharacterSprites)
            {
                Vector position = cs.Sprite.GetPosition();
                position.Y = 0 + Math.Sin((_totalTime + xAdvance) * frequency) * 25;
                cs.Sprite.SetPosition(position);
                xAdvance++;
            }



            _totalTime += elapsedTime;
        }
    }
}
