using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class MenuScene : BaseScene
    {
        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawString("THE ASTEROIDS", new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular), Brushes.White, 100, 10);
            Buffer.Graphics.DrawString("Menu", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 300, 125);
            Buffer.Graphics.DrawString("press \"1\" - Play", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), Brushes.White, 250, 200);
            Buffer.Graphics.DrawString("press \"2\" - Help", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), Brushes.White, 250, 250);
            Buffer.Graphics.DrawString("press \"0\" - Exit", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), Brushes.White, 250, 500);
            Buffer.Render();
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0)
            {
                _form.Close();
            }
            if (e.KeyCode == Keys.D1)
            {
                SceneManager
                        .Get()
                        .Init<Game>(_form)
                        .Draw();
            }
            if (e.KeyCode == Keys.D2)
            {
                SceneManager
                        .Get()
                        .Init<HelpScene>(_form)
                        .Draw();
            }
        }
    }
}
