using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_UK_Form8v
{
    public partial class Form2 : Form
    {
        private Image backgroundImage2;
        public string path_result { get; set; } = string.Empty; // Публічна властивість для зберігання результату
        public string name_result { get; set; } = string.Empty;
        public Form2()
        {
            InitializeComponent();

            backgroundImage2 = Image.FromFile("images_2.png"); // Загрузить заднік 
            this.DoubleBuffered = true; //Щоб не мігало

            BackColor = Color.Gray;

            this.Text = ""; //назву убираєм

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // робим розмір окна статичним
            this.MaximizeBox = false;
            //this.ControlBox = false;    // Приховуємо всі кнопки керування (вірус жоска)
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage2 != null)
            {
                e.Graphics.DrawImage(backgroundImage2, this.ClientRectangle); //Виводимо заднік на все вікно
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //Просто закриває вікно
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path_result = path_text.Text; //Отримуємо шлях до .ехе
            name_result = name_text.Text; //Отримуємо шлях до .ехе
            this.DialogResult = DialogResult.OK; // Встановлюємо DialogResult
            this.Dispose(); // Закриваємо модальне вікно
        }
    }
}
