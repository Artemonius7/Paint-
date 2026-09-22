using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        Gallery gallery = new Gallery();
        ArrayPoints arrayPoints = new ArrayPoints();
        Bitmap image = new Bitmap(100, 100);
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);

        public void SetSize()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            image = new Bitmap(rect.Width, rect.Height);
            g = Graphics.FromImage(image);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Изображения (*.jpg;*.png)|*.jpg;*.png";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                gallery.Picture = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = gallery.Picture;
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить изображение!","Ошибка загрузки изображения",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            gallery.Picture = null;
            pictureBox2.Image = gallery.Picture;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ArrayPoints.flag = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ArrayPoints.flag = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ArrayPoints.flag) return;
            arrayPoints.SetPoints(e.X, e.Y);
            if (arrayPoints.I >=2)
            {
                g.DrawLines(pen, arrayPoints.Points);
                pictureBox1.Image = image;
                arrayPoints.SetPoints(e.X, e.Y);

            }
            
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) pen.Color = colorDialog1.Color;
            else return;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Изображения (*.jpg)|*.jpg";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить изображение!", "Ошибка загрузки изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            g.Clear(pictureBox1.BackColor);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gallery.Picture = Image.FromFile(@"Images\car.jpg");
            pictureBox2.Image = gallery.Picture;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gallery.Picture = Image.FromFile(@"Images\pizza.jpg");
            pictureBox2.Image = gallery.Picture;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gallery.Picture = Image.FromFile(@"Images\pc.jpg");
            pictureBox2.Image = gallery.Picture;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            gallery.Picture = Image.FromFile(@"Images\penguin.jpg");
            pictureBox2.Image = gallery.Picture;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            gallery.Picture = Image.FromFile(@"Images\oldman.jpeg");
            pictureBox2.Image = gallery.Picture;
        }
    }
}
