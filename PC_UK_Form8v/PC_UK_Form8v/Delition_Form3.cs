using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_UK_DatabaseDLL;


namespace PC_UK_Form8v
{


    public partial class Delition_Form3 : Form
    {

        //public string Name { get; set; } = string.Empty;
        //public string Path { get; set; } = string.Empty;

        private Form1 _form1;

        DB_Tinkering db_t = new DB_Tinkering();

        private Image backgroundImage3;
        public Delition_Form3(Form1 form1)
        {
            InitializeComponent();

            backgroundImage3 = Image.FromFile("images_2.png");

            this.DoubleBuffered = true; //Щоб не мігало

            BackColor = Color.Gray;

            this.Text = ""; //назву убираєм

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // робим розмір окна статичним
            this.MaximizeBox = false;
            _form1 = form1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage3 != null)
            {
                e.Graphics.DrawImage(backgroundImage3, this.ClientRectangle); //Виводимо заднік на все вікно
            }
        }

        private void deletion_button_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            string path = textBox1.Text;

            if (db_t.DB_DeleteData(name, path))
            {
                _form1.RefreshGrid();
                MessageBox1.MessageBox(IntPtr.Zero, $"{name} Успішно видалений", "Success", 0); //повідомлення успіху
                this.Close();
            }
            else
            {
                MessageBox1.MessageBox(IntPtr.Zero, "Сталася помилка. Скоріш за все такого об'єкту не існує", "Err_Obj_Null", 0); //Error message
            }
            //Path = textBox1.Text;
            //Name = textBox2.Text;
            //this.DialogResult = DialogResult.OK;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
