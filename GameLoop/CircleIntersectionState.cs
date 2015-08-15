using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class CircleIntersectionState : IGameObject
    {
        Circle _circle = new Circle(Vector.Zero, 200);

        public CircleIntersectionState()
        {
            Gl.glLineWidth(3);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        #region IGameObject Members
        public void Render()
        {
            _circle.Draw();
        }
        public void Update(double elapsedTime)
        {
        }

        
        #endregion

    }
}