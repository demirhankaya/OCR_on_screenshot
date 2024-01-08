using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR_on_screenshot
{
    public partial class FormEkranYakala : Form
    {

        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;
        public Bitmap screenshot;

        bool start = false;


        public FormEkranYakala()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = 0;
            this.Left = 0;



        }

        private void FormEkranYakala_Load(object sender, EventArgs e)
        {
            this.Hide();

            Bitmap printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(printScreen as Image);

            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);


            using (MemoryStream s = new MemoryStream())
            {
                printScreen.Save(s, ImageFormat.Bmp);
                pbEkranGoruntusu.Size = new System.Drawing.Size(this.Width, this.Height);

                pbEkranGoruntusu.Image = Image.FromStream(s);
            }

            this.Show();

            Cursor = Cursors.Cross;
        }

        private void pbEkranGoruntusu_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Blue, 5);
                    selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                }

                pbEkranGoruntusu.Refresh();

                start = true;
            }
        }

        private void pbEkranGoruntusu_MouseMove(object sender, MouseEventArgs e)
        {
            if (pbEkranGoruntusu.Image == null)
            {
                return;
            }

            if (start)
            {
                pbEkranGoruntusu.Refresh();

                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;

                pbEkranGoruntusu.CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pbEkranGoruntusu.CreateGraphics().DrawRectangle(selectPen, selectX,selectY,selectWidth,selectHeight);


            }

        }

        private void pbEkranGoruntusu_MouseUp(object sender, MouseEventArgs e)
        {
            if (pbEkranGoruntusu.Image == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                pbEkranGoruntusu.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                pbEkranGoruntusu.CreateGraphics().DrawRectangle(selectPen, selectX, selectY, selectWidth, selectHeight);

            }

            start = false;

            disaAktar();
        }

        private void disaAktar()
        {
            if (selectWidth > 0)
            {
                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);

                Bitmap gercekGorsel = new Bitmap(pbEkranGoruntusu.Image, pbEkranGoruntusu.Width, pbEkranGoruntusu.Height);

                Bitmap _img = new Bitmap(selectWidth, selectHeight);

                Graphics g = Graphics.FromImage(_img);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(gercekGorsel, 0, 0, rect, GraphicsUnit.Pixel);

                Clipboard.SetImage(_img);
            }
            this.Close();
        }
    }
}
