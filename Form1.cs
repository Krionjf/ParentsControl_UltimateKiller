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
            new Programs{name = "GTA", way_result = "C:|asdasd.exe", times = 4},
            new Programs{name = "DOTA 3", way_result = "C:|hui.exe", times = 17}
        };
  
        public Form1()
        {
            InitializeComponent();

            //Program_list.AutoGenerateColumns = false; // Відключаємо автоматичну генерацію стовпців
            Info_list.AutoGenerateColumns = false;

            backgroundImage = Image.FromFile("thumb-1920-853895.png"); // Загрузить заднік 
            this.DoubleBuffered = true; // щоб не мерехтіло

            BackColor = Color.Gray;

            this.Text = "ParentsControl UltimateKiller";

            Program_list.DataSource = programs; // отображать сразу ДБ

            //===========================
            //Кароче,якщо нада буде,то в лівому стовпчику можна зробить топ прог,по к-сті заходів
            //================================
            Info_list.Visible = false; //пока інвіз,а там подиввимось
            /*
            DataGridViewColumn info_column = new DataGridViewTextBoxColumn(); 
            // робим стовпчики для топа,назва і скільки раз зайшов
            info_column.Name = "Top ";
            info_column.HeaderText = "Name"; // Заголовок стовпця
            info_column.DataPropertyName = "name"; // привязка,просто так нада

            // Додаємо стовпець в DataGridView
            Info_list.Columns.Add(info_column);

            DataGridViewColumn time_column = new DataGridViewTextBoxColumn();
            time_column.Name = "Top ";
            time_column.HeaderText = "Times";
            time_column.DataPropertyName = "times";

            // Додаємо стовпець в DataGridView
            Info_list.Columns.Add(time_column);

            // Встановлюємо джерело даних для DataGridView
            Info_list.DataSource = programs;
            */

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // робим розмір окна статичним
            this.MaximizeBox = false;
            //this.ControlBox = false;    // Приховуємо всі кнопки керування (вірус жоска)

            this.Size = new System.Drawing.Size(800, 600); //встановити розмір
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
                if (name != "" && way != "")
                {
                    programs.Add(new Programs { name = name, way_result = way });
                    Program_list.DataSource = null;
                    Program_list.DataSource = programs;
                }
                else
                {
                    MessageBox1.MessageBox(IntPtr.Zero, "ТІ аут", "ERROR 42", 0); //Error message
                }
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
                Program_list.DataSource = null; // обновить список,так нада
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

        private void Info_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Programs // клас-заглушка для ліста прогрвам
    {
        public string name { get; set; }
        public string way_result { get; set; }
        public int times { get; set; }
    }
    public class MessageBox1 // клас для виведення повіомлень
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    }

}





