using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public class HelpScene : BaseScene
    {
        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.DarkRed);
            Buffer.Graphics.DrawString("HELP", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 300, 75);
            Buffer.Graphics.DrawString("Controls", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 250, 150);
            Buffer.Graphics.DrawString("UP key - ship move up", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 175);
            Buffer.Graphics.DrawString("DOWN key - ship move down", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 200);
            Buffer.Graphics.DrawString("Ctrl key - fire", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 225);

            Buffer.Graphics.DrawString("Game rules", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 250, 275);
            Buffer.Graphics.DrawString("*5 game levels", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 300);
            Buffer.Graphics.DrawString("*1 killed asteroid = 2 ammo", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 325);
            Buffer.Graphics.DrawString("*1 aidkit for game line", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 350);
            Buffer.Graphics.DrawString("press \"1\" - back to Menu", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 450);
            Buffer.Graphics.DrawString("press \"0\" - Exit", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular), Brushes.White, 250, 500);
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
                        .Init<MenuScene>(_form)
                        .Draw();
            }
        }
    }
}
