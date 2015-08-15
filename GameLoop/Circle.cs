using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    public class Circle
    {
        Vector Position { get; set; }
        double Radius { get; set; }
        Color _color = new Color(1, 1, 1, 1);
        
        public Circle()
        {
            Position = Vector.Zero;
            Radius = 1;
        }

        public Circle(Vector position, double radius)
        {
            Position = position;
            Radius = radius;
        }

        public void Draw()
        {
            Gl.glColor3f(_color.Red, _color.Green, _color.Blue);

            // roundness
            int vertexAmount = 10;
            double twoPI = 2.0 * Math.PI;

            //make a loop.
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                for (int i = 0; i <= vertexAmount; i++)
                {
                    double xPos = Position.X + Radius * Math.Cos(i * twoPI / vertexAmount);
                    double yPos = Position.Y + Radius * Math.Sin(i * twoPI / vertexAmount);
                    Gl.glVertex2d(xPos, yPos);
                }
            }
            Gl.glEnd();
        }
    }

}
