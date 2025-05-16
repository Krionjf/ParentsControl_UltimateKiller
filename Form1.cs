using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentsKiller_Form
{

    public partial class Form1 : Form
    {
        private Image backgroundImage;
        public Form1()
        {
            InitializeComponent();
            backgroundImage = Image.FromFile(@"D:\thumb-1920-853895.png"); // Загрузить заднік 
            this.DoubleBuffered = true; // щоб не мерехтіло
            BackColor = Color.Gray;
            this.Text = "ParentsControl UltimateKiller";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage != null)
            {
                Rectangle imageRect = new Rectangle(174, -1, 662, 331); // Загрузить заднік опрєдільонного розміру
                e.Graphics.DrawImage(backgroundImage, imageRect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            
            DialogResult result = secondForm.ShowDialog();//Модальне вікно(коли воно відкрите,то основне вікно афк)
            
            if (result == DialogResult.OK)//провєрка на лоха + получить значення
            {
                
                string way = secondForm.way_result;
                string name = secondForm.name_result;

                
                label1.Text = way + " == " + name; //тут потом буде закидать його в БД
            }
            else
            {
                
                label1.Text = "Дія скасована"; //якщо отмінив юзєр шось
            }


            secondForm.Dispose(); // Закриваємо

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); //закрить вікно
        }

        private void result_Click(object sender, EventArgs e)
        {

        }
    }

}





