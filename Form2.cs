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
    public partial class Form2 : Form
    {
        private Image backgroundImage2;
        public string way_result { get; set; } // Публічна властивість для зберігання результату
        public string name_result { get; set; }
        public Form2()
        {
            InitializeComponent();
            backgroundImage2 = Image.FromFile(@"D:\images (2).png"); // Загрузить заднік 
            this.DoubleBuffered = true; //Щоб не мігало
            BackColor = Color.Gray;
            this.Text = "";
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
            way_result = way_text.Text; //Отримуємо шлях до .ехе
            name_result = name_text.Text; //Отримуємо шлях до .ехе
            this.DialogResult = DialogResult.OK; // Встановлюємо DialogResult
            this.Close(); // Закриваємо модальне вікно
        }
    }
}
