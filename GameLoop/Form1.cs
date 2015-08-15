using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.DevIl;

namespace GameLoop
{
    
    public partial class Form1 : Form
    {
        FastLoop _fastLoop;
        StateSystem _system = new StateSystem();
        Input _input = new Input();

        bool _fullscreen = false;
        TextureManager _textureManager = new TextureManager();
       
        public Form1()
        {
            _fastLoop = new FastLoop(GameLoop);

            InitializeComponent();
            _openGLControl.InitializeContexts();

            // Initialize DevIL
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            //Load textures

            _textureManager.LoadTexture("font", "font.tga");
            

            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
                ClientSize = new Size(1280, 720);

           
            _system.AddState("text_state", new TextTestState(_textureManager));
            _system.AddState("frame_state", new FramesTestState(_textureManager));
            _system.AddState("wrap_state", new TextWrapTest(_textureManager));
            _system.AddState("trig_draw", new WaveformGraphics());
            _system.AddState("special_effect", new SpecialEffectState(_textureManager));
            _system.AddState("circle_state", new CircleIntersectionState(_input));


            //start state
            _system.ChangeState("circle_state");
        }

      

        void GameLoop(double elapsedTime)
        {
            _system.Update(elapsedTime);
            _system.Render();
            _openGLControl.Refresh();
            UpdateInput();

        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
           

        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        private void UpdateInput()
        {
            System.Drawing.Point mousePos = Cursor.Position;
            mousePos = _openGLControl.PointToClient(mousePos);

            // Now use our point definition, 
            Point adjustedMousePoint = new Point();
            adjustedMousePoint.X = (float)mousePos.X - ((float)ClientSize.Width / 2);
            adjustedMousePoint.Y = ((float)ClientSize.Height / 2) - (float)mousePos.Y;
            _input.MousePosition = adjustedMousePoint;
        }


    }
}
