using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public abstract class BaseScene : IScene, IDisposable
    {
        protected BufferedGraphicsContext context;
        protected Form _form;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public virtual void Init(Form form)
        {
            _form = form;
            
            context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            if (Width > 0 && Width < 1000)
                Width = Width;
            else
                throw new ArgumentOutOfRangeException("Width", "Width must be between 0 and 1000");
            if (Height > 0 && Height < 1000)
                Height = Height;
            else
                throw new ArgumentOutOfRangeException("Heigth", "Heigth must be between 0 and 1000");

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));            

            _form.KeyDown += SceneKeyDown;
        }

        public virtual void SceneKeyDown(object sender, KeyEventArgs e) { }

        public virtual void Draw() { }

        public virtual void Dispose()
        {
            Buffer = null;
            context = null;
            _form.KeyDown -= SceneKeyDown;
        }
    }
  
}
