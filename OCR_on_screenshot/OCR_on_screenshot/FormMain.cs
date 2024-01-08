using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR_on_screenshot
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        FormEkranYakala formEkranYakala = new FormEkranYakala();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Thread.Sleep(200);

            formEkranYakala.ShowDialog();

            Image tempImage = Clipboard.GetImage();

            pbEkranGoruntusu.Image = tempImage;

            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg File|*.jpg";
            saveFileDialog.FileName = "Adsız";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                if (pbEkranGoruntusu.Image != null)
                {
                    pbEkranGoruntusu.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);

                    MessageBox.Show("Kaydedildi");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata kayıt başarısız");
            }
        }
    }
}
