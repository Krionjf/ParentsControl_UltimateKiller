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
    public partial class Form2 : Form
    {
        DB_Tinkering db_t = new DB_Tinkering();
        private Image backgroundImage2;
        //public string path_result { get; set; } = string.Empty; // Публічна властивість для зберігання результату
        //public string name_result { get; set; } = string.Empty;

        private Form1 _form1; // зберігає посилання на перший форм
        public Form2(Form1 form1) // коли ми викликаємо другу форму як новий клас в першій на місці Form1 form1 стає this який вказує на посилання до форми
        {
            InitializeComponent();

            backgroundImage2 = Image.FromFile("images_2.png"); // Загрузить заднік 
            this.DoubleBuffered = true; //Щоб не мігало

            BackColor = Color.Gray;

            this.Text = ""; //назву убираєм

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // робим розмір окна статичним
            this.MaximizeBox = false;
            _form1 = form1; // передає посилання на форму приватній змінній
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

        private void button2_Click(object sender, EventArgs e) // При натиснені додає данні які були введені до БД
        {

            string path = path_text.Text;
            string name = name_text.Text;

            if (db_t.DB_AddData(name, path))
            {
                _form1.RefreshGrid(); 
                MessageBox1.MessageBox(IntPtr.Zero, $"{name} Успішно доданий до БД", "Success", 0); //повідомлення успіху
                this.Close();
            }
            else
            {
                MessageBox1.MessageBox(IntPtr.Zero, "Така програма вже існує", "Err_AlrExist", 0); //Error message
            }


            //path_result = path_text.Text; //Отримуємо шлях до .ехе
            //name_result = name_text.Text; //Отримуємо шлях до .ехе
            //this.DialogResult = DialogResult.OK; // Встановлюємо DialogResult
            //this.Dispose(); // Закриваємо модальне вікно
        }
    }
}
