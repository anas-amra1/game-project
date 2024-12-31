using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool right, left, space;
        int score;

        void game_result()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls)
                {
                    if (j is PictureBox && j.Tag == "bullet1")
                    {
                        if(i is PictureBox && i.Tag == "enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                i.Top = -100;
                                score++;
                                label1.Text = score.ToString();
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
            if(player.Bounds.IntersectsWith(enemy1.Bounds)||player.Bounds.IntersectsWith(enemy2.Bounds)||player.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Stop();
                label2.Visible = true;
            }
        } 
        void enemymove()
        {
            Random random = new Random();
            int x, y, z;
            if (enemy1.Top >= 500)
            {
                x=random.Next(0, 300);
                enemy1.Location = new Point(x, 0);
            }
            if (enemy2.Top >= 500)
            {
                y=random.Next(0, 300);
                enemy2.Location = new Point(y, 0);
            }
            if (enemy3.Top >= 500)
            {
                z=random.Next(0, 300);
                enemy3.Location = new Point(z, 0);
            }
            enemy1.Top +=15;
            enemy2.Top +=20;
            enemy3.Top +=10;
        }

            void add_bulle()
        {
            PictureBox bullet1 = new PictureBox();
            bullet1.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet1.Size = new Size(15, 15);
            bullet1.Image = Properties.Resources.bullet1;
            bullet1.BackColor= Color.Transparent;
            bullet1.Tag = "bullet1";
            bullet1.Left = player.Left +15;
            bullet1.Top = player.Top - 30;
            this.Controls.Add(bullet1);
            bullet1.BringToFront();
        }
        void bullet1_move()
        {
            foreach (Control f in this.Controls )
            {
                if( f is PictureBox && f.Tag == "bullet1")
                {
                    f.Top -= 10;
                    if( f.Top <100)
                        this.Controls.Remove(f);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Player_move();
            bullet1_move();
            enemymove();
            game_result();
        }

        void Player_move()
        {
            if (right == true)
            {
                if (player.Left < 425)
                {
                    player.Left += 20;
                }
            }
            if (left == true)
            {
                if (player.Left > 10)
                {
                    player.Left -= 20;
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                right = true;
            if(e.KeyCode == Keys.Left)
                left = true;
            if(e.KeyCode == Keys.Space)
            {
                space = true;
                add_bulle();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                right = false;
            if (e.KeyCode == Keys.Left)
                left = false;


        }
    }
}
