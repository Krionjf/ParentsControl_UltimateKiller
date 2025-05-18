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



            backgroundImage = Image.FromFile("thumb-1920-853895.png"); // ��������� ����� 
            this.DoubleBuffered = true; // ��� �� ��������

            BackColor = Color.Gray;

            this.Text = "ParentsControl UltimateKiller";

            Program_list.DataSource = db_t.DB_GetAllData(); // ���������� ����� ��

            //===========================
            //������,���� ���� ����,�� � ����� ��������� ����� ������� ��� ����,�� �-�� ������
            //================================

            /*
            DataGridViewColumn info_column = new DataGridViewTextBoxColumn(); 
            // ����� ��������� ��� ����,����� � ������ ��� ������
            info_column.Name = "Top ";
            info_column.HeaderText = "Name"; // ��������� �������
            info_column.DataPropertyName = "name"; // ��������,������ ��� ����

            // ������ �������� � DataGridView
            Info_list.Columns.Add(info_column);

            DataGridViewColumn time_column = new DataGridViewTextBoxColumn();
            time_column.Name = "Top ";
            time_column.HeaderText = "Times";
            time_column.DataPropertyName = "times";

            // ������ �������� � DataGridView
            Info_list.Columns.Add(time_column);

            // ������������ ������� ����� ��� DataGridView
            Info_list.DataSource = programs;
            */

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // ����� ����� ���� ���������
            this.MaximizeBox = false;


            /*this.Size = new System.Drawing.Size(900, 560);*/ //���������� �����
        }

        public void RefreshGrid() // ������� ��� ��������� ������ � ����
        {
            Program_list.DataSource = null; //����� ѳ��� 
            Program_list.DataSource = db_t.DB_GetAllData(); // ���� ���� �� ����
        }

        public void ClearGrid()
        {
            using var db = new DB_Context();
            db.Database.ExecuteSqlRaw("DELETE FROM Programs"); // ������� �� ����
            db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name = 'Programs'"); // ����� Id �������� �� 0

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage != null)
            {
                Rectangle imageRect = new Rectangle(174, -1, 662, 331); // ��������� ����� ������������ ������
                e.Graphics.DrawImage(backgroundImage, imageRect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2(this); // �� ���������� �� ��������� ���� �������� ����� ����� � this ����� �� ���� ��� ������� �������

            secondForm.ShowDialog(); // � ������� ������� ���� �� ����� ������� ������� �����,
                                     // � ��� ����� ������� ������ ���������� � ����� ���� ����� (������������)
                                     // ����� �������� � �� ����� ����� ����� �����
                                     // (��������������� ���� ���� ����� ����� ����� � ������� �������)
                                     


            //DialogResult result = secondForm.ShowDialog();//�������� ����(���� ���� �������,�� ������� ���� ���)

            //if (result == DialogResult.OK)//�������� �� ����������� ����
            //{

            //    string path = secondForm.path_result; // ���� ���������� � ������ ���� � ������ �����
            //    string name = secondForm.name_result;

            //    if (db_t.DB_AddData(name, path))
            //    {
            //        RefreshGrid();
            //        MessageBox1.MessageBox(IntPtr.Zero, $"{name} ������ ������� �� ��", "Success", 0); //����������� �����
            //    }
            //    else
            //    {
            //        MessageBox1.MessageBox(IntPtr.Zero, "���� �������� ��� ����", "Err_AlrExist", 0); //Error message
            //    }
            //}



            //secondForm.Dispose(); // ���������

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose(); //������� ����
        }



        private void Delete_Click(object sender, EventArgs e)
        {

            Delition_Form3 delitionForm = new Delition_Form3(this);

            delitionForm.ShowDialog();



            //===========================================================================================

            //Delition_Form3 delitionForm = new Delition_Form3();

            //DialogResult result = delitionForm.ShowDialog();//�������� ����(���� ���� �������,�� ������� ���� ���)

            //if (result == DialogResult.OK)//�������� �� ����������� ����
            //{

            //    string path = delitionForm.Path; // ���� ���������� � ������ ���� � ������ �����
            //    string name = delitionForm.Name;

            //    if (db_t.DB_DeleteData(name, path))
            //    {
            //        RefreshGrid();
            //        MessageBox1.MessageBox(IntPtr.Zero, $"{name} ������ ���������", "Success", 0); //����������� �����
            //    }
            //    else
            //    {
            //        MessageBox1.MessageBox(IntPtr.Zero, "������� �������. ����� �� ��� ������ ��'���� �� ����", "Err_Obj_Null", 0); //Error message
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


    public class MessageBox1 // ���� ��� ��������� ���������
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    }
}
