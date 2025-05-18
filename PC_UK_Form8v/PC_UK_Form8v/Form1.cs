using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using PC_UK_DatabaseDLL;

namespace PC_UK_Form8v
{

    public partial class Form1 : Form
    {
        private Image backgroundImage;

        DB_Tinkering db_t = new DB_Tinkering();

        public Form1()
        {
            InitializeComponent();



            backgroundImage = Image.FromFile("thumb-1920-853895.png"); // Загрузить заднік 
            this.DoubleBuffered = true; // щоб не мерехтіло

            BackColor = Color.Gray;

            this.Text = "ParentsControl UltimateKiller";

            Program_list.DataSource = db_t.DB_GetAllData(); // отображать сразу ДБ

            //===========================
            //Кароче,якщо нада буде,то в лівому стовпчику можна зробить топ прог,по к-сті заходів
            //================================

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


            /*this.Size = new System.Drawing.Size(900, 560);*/ //встановити розмір
        }

        public void RefreshGrid() // Функція для оновлення данних в сітці
        {
            Program_list.DataSource = null; //Очищає Сітку 
            Program_list.DataSource = db_t.DB_GetAllData(); // Додає данні до сітки
        }

        public void ClearGrid()
        {
            using var db = new DB_Context();
            db.Database.ExecuteSqlRaw("DELETE FROM Programs"); // Видаляє всі данні
            db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name = 'Programs'"); // скидує Id лічильник до 0

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
            Form2 secondForm = new Form2(this); // Це получається ми створюємо якби фрагмент другої форми і this вказує на того хто запрашує команди

            secondForm.ShowDialog(); // в данному випадку саме ця форма просить відкрити другу,
                                     // і тим самим завдяки деяким параметрам в другій формі можна (узагальнюючи)
                                     // можна впливати з на першу форму через другу
                                     // (використовувати клас який змінює першу форму в данному випадку)
                                     


            //DialogResult result = secondForm.ShowDialog();//Модальне вікно(коли воно відкрите,то основне вікно афк)

            //if (result == DialogResult.OK)//перевірка чи запустилось вікно
            //{

            //    string path = secondForm.path_result; // бере інформацію з іншого вікна і передає цьому
            //    string name = secondForm.name_result;

            //    if (db_t.DB_AddData(name, path))
            //    {
            //        RefreshGrid();
            //        MessageBox1.MessageBox(IntPtr.Zero, $"{name} Успішно доданий до БД", "Success", 0); //повідомлення успіху
            //    }
            //    else
            //    {
            //        MessageBox1.MessageBox(IntPtr.Zero, "Така програма вже існує", "Err_AlrExist", 0); //Error message
            //    }
            //}



            //secondForm.Dispose(); // Закриваємо

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose(); //закрить вікно
        }



        private void Delete_Click(object sender, EventArgs e)
        {

            Delition_Form3 delitionForm = new Delition_Form3(this);

            delitionForm.ShowDialog();



            //===========================================================================================

            //Delition_Form3 delitionForm = new Delition_Form3();

            //DialogResult result = delitionForm.ShowDialog();//Модальне вікно(коли воно відкрите,то основне вікно афк)

            //if (result == DialogResult.OK)//перевірка чи запустилось вікно
            //{

            //    string path = delitionForm.Path; // бере інформацію з іншого вікна і передає цьому
            //    string name = delitionForm.Name;

            //    if (db_t.DB_DeleteData(name, path))
            //    {
            //        RefreshGrid();
            //        MessageBox1.MessageBox(IntPtr.Zero, $"{name} Успішно видалений", "Success", 0); //повідомлення успіху
            //    }
            //    else
            //    {
            //        MessageBox1.MessageBox(IntPtr.Zero, "Сталася помилка. Скоріш за все такого об'єкту не існує", "Err_Obj_Null", 0); //Error message
            //    }

            //}
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearGrid();
            RefreshGrid();
        }
    }


    public class MessageBox1 // клас для виведення повіомлень
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    }
}
