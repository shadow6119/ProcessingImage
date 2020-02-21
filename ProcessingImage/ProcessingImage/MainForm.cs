using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessingImage
{
    public partial class MainForm : Form
    {
        Bitmap img;

        public MainForm()
        {
            InitializeComponent();
        }

        //画像選択
        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            String path = SelectFile();
            if (path == null) return;

            img = new Bitmap(path);

            ImageData imgData = new ImageData(img);
           
            img = imgData.GenerateBitmap();

            pictureBox.Image = img;
        }
        //画像保存
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine(sfd.FileName);

                    pictureBox.Image.Save(sfd.FileName);
                }
            }
        }

        //ファイルのpath渡し用のメソッド
        private String SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return null;
            }
        }

        private void GrayScaleBrightness_Click(object sender, EventArgs e)
        {
            ImageData imgData = new ImageData(img);
            imgData.BrightnessGray();
            img = imgData.GenerateBitmap();
            pictureBox.Image = img;
        }

        private void GrayScaleLuminunce_Click(object sender, EventArgs e)
        {
            ImageData imgData = new ImageData(img);
            imgData.LuminanceGray();
            img = imgData.GenerateBitmap();
            pictureBox.Image = img;
        }

        private void Binarization_Click(object sender, EventArgs e)
        {

        }
    }
}
