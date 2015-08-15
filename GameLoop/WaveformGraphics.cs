﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class WaveformGraphics : IGameObject
    {
        double _xPosition = -100;
        double _yPosition = -100;
        double _xLength = 200;
        double _yLength = 200;
        double _sampleSize = 100;
        double _frequency = 2;

        public delegate double WaveFunction (double value);

        public WaveformGraphics()
        {
            Gl.glLineWidth(3);
            Gl.glDisable(Gl.GL_TEXTURE_2D);

        }

        public void DrawAxis()
        {
            Gl.glColor3f(1, 1, 1);
            Gl.glBegin(Gl.GL_LINES);
            {
                //x 
                Gl.glVertex2d(_xPosition, _yPosition);
                Gl.glVertex2d(_xPosition + _xLength, _yPosition);

                //y

                Gl.glVertex2d(_xPosition, _yPosition);
                Gl.glVertex2d(_xPosition, _yPosition + _yLength);
            }
            Gl.glEnd();
        }

        public void DrawGraph(WaveFunction waveFunction, Color color)
        {
            double xIncrement = _xLength / _sampleSize;
            double previousX = _xPosition;
            double previousY = _yPosition + (0.5 * _yLength);
            Gl.glColor3f(color.Red, color.Green, color.Blue);
            Gl.glBegin(Gl.GL_LINES);
            {
                for (int i = 0; i < _sampleSize; i++)
                {
                    //new x and y pos
                    double newX = previousX + xIncrement;

                    double percentDone = (i / _sampleSize);
                    double percentRadians = percentDone * (Math.PI * _frequency);

                    double newY = _yPosition + waveFunction(percentRadians) * (_yLength / 2);


                    if (i > 1)
                    {
                        Gl.glVertex2d(previousX, previousY);
                        Gl.glVertex2d(newX, newY);
                    }

                    //store previous
                    previousX = newX;
                    previousY = newY;
                }
            }
            Gl.glEnd();

        }
        public void Render()
        {
            DrawAxis();
            //DrawGraph(Math.Sin, new Color(1, 0, 0, 1));
            //DrawGraph(Math.Cos, new Color(0, 0.5f, 0.5f, 1));
            DrawGraph(delegate (double value) { return (Math.Sin(value) + Math.Sin(value + value)) * 0.5; }, new Color(1, 0, 0, 1));


        }

        void IGameObject.Update(double elapsedTime)
        {
        }
    }
}
