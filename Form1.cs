using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentsKiller_Form
{

    public partial class Form1 : Form
    {
        private Image backgroundImage;

        public List<Programs> programs = new List<Programs>
        {
            new Programs{name = "GTA", way_result = "C:|asdasd.exe"},
            new Programs{name = "DOTA 3", way_result = "C:|hui.exe"}
        };
  
        public Form1()
        {
            InitializeComponent();
            backgroundImage = Image.FromFile("thumb-1920-853895.png"); // Загрузить заднік 
            this.DoubleBuffered = true; // щоб не мерехтіло
            BackColor = Color.Gray;
            this.Text = "ParentsControl UltimateKiller";
            Program_list.DataSource = programs; // отображать сразу ДБ
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
                
                string way = secondForm.way_result; // добавлєніє інфи в ДБ + обнова його
                string name = secondForm.name_result;
                programs.Add(new Programs { name = name, way_result = way });
                Program_list.DataSource = null;
                Program_list.DataSource = programs;

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

        private void Delete_Click(object sender, EventArgs e)
        {
            if (programs.Count() != 0)// провєрка на дібіла
            {
                programs.Remove(programs[0]); //удалить перший слот
                Program_list.DataSource = null;
                Program_list.DataSource = programs;
            }
            else
            {
                MessageBox1.MessageBox(IntPtr.Zero, "ТІ даун йобані", "ERROR 52", 0); //Error message
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Programs // клас-заглушка для ліста прогрвам
    {
        public string name { get; set; }
        public string way_result { get; set; }
    }
    public class MessageBox1 // клас для виведення повіомлень
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    }

}





