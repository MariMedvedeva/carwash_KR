using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace carwash 
{
    public partial class EnlargedForm : Form
    {
        public EnlargedForm(System.Drawing.Image image)
        {
            InitializeComponent();
            // Установка изображения в PictureBox на форме
            EnlargedPictureBox.Image = image;
        }

        private void EnlargedPictureBox_Click(object sender, EventArgs e)
        {
            // Закрытие формы при клике на увеличенное изображение
            this.Close();
        }
    }

}
