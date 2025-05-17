using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentsKiller_Form
{
    public partial class Form3 : Form
    {
        private Image backgroundImage3;
        public string delete_way { get; set; } // Публічна властивість для зберігання результату
        public Form3()
        {
            InitializeComponent();

            backgroundImage3 = Image.FromFile("images (2).png"); // Загрузить заднік 
            this.DoubleBuffered = true; //Щоб не мігало

            BackColor = Color.Gray;

            this.Text = ""; //назву убираєм

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // робим розмір окна статичним
            this.MaximizeBox = false;
            //this.ControlBox = false;    // Приховуємо всі кнопки керування (вірус жоска)
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage3 != null)
            {
                e.Graphics.DrawImage(backgroundImage3, this.ClientRectangle); //Виводимо заднік на все вікно
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            delete_way = delete_text.Text; //Отримуємо шлях до .ехе
            this.DialogResult = DialogResult.OK; // Встановлюємо DialogResult
            this.Close(); // Закриваємо модальне вікно
        }
    }
}
