using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentsKiller_Form
{

    public partial class Form1 : Form
    {
        private Image backgroundImage;

        private ProcessTracker tracker = new ProcessTracker();

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


        public class ProcessTracker
        {
            private List<string> trackedProcesses = new List<string>();  // Список процесів, які потрібно відстежувати
            private Thread trackingThread;
            private bool isRunning = false;
            public event EventHandler<ProcessEventArgs> ProcessStarted;
            public event EventHandler<ProcessEventArgs> ProcessStopped;

            public ProcessTracker() { }

            // Додає назву процесу (без розширення .exe) до списку відстежуваних
            public void AddTrackedProcess(string processName)
            {
                if (!trackedProcesses.Contains(processName))
                {
                    trackedProcesses.Add(processName);
                }
            }

            // Видаляє назву процесу зі списку відстежуваних
            public void RemoveTrackedProcess(string processName)
            {
                trackedProcesses.Remove(processName);
            }

            // Запускає відстеження процесів
            public void StartTracking()
            {
                if (!isRunning)
                {
                    isRunning = true;
                    trackingThread = new Thread(TrackProcesses);
                    trackingThread.IsBackground = true; // Важливо!  Щоб програма завершувалась, навіть якщо цей потік працює
                    trackingThread.Start();
                }
            }

            // Зупиняє відстеження процесів
            public void StopTracking()
            {
                isRunning = false;
                if (trackingThread != null && trackingThread.IsAlive)
                {
                    trackingThread.Join(); // Дочекатися завершення потоку
                }
            }

            private void TrackProcesses()
            {
                List<string> currentlyRunning = new List<string>();

                while (isRunning)
                {
                    Process[] processes = Process.GetProcesses();
                    List<string> newRunning = new List<string>();

                    foreach (Process process in processes)
                    {
                        try
                        {
                            // Важливо!  Перевіряємо, чи process.ProcessName є NULL або порожнім, щоб уникнути винятків.
                            if (!string.IsNullOrEmpty(process.ProcessName) && trackedProcesses.Contains(process.ProcessName))
                            {
                                newRunning.Add(process.ProcessName);

                                // Якщо процес щойно запустився
                            if (!currentlyRunning.Contains(process.ProcessName))
                                {
                                    OnProcessStarted(process.ProcessName, process.Id);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Обробка винятків, пов'язаних з доступом до інформації про процес.
                            // Наприклад, недостатньо прав.
                            Console.WriteLine($"Error accessing process {process.ProcessName}: {ex.Message}");
                        }
                    }

                    // Перевіряємо, які процеси зупинилися
                    foreach (string processName in currentlyRunning.Except(newRunning))
                    {
                        OnProcessStopped(processName);
                    }

                    currentlyRunning = newRunning; // Оновлюємо список запущених процесів
                    Thread.Sleep(1000); // Перевіряємо кожну секунду
                }
            }

            // Метод для виклику події ProcessStarted
            protected virtual void OnProcessStarted(string processName, int processId)
            {
                ProcessStarted?.Invoke(this, new ProcessEventArgs(processName, processId));
            }

            // Метод для виклику події ProcessStopped
            protected virtual void OnProcessStopped(string processName)
            {
                ProcessStopped?.Invoke(this, new ProcessEventArgs(processName));
            }
        }

        // Клас для передачі інформації про процес з подією
        public class ProcessEventArgs : EventArgs
        {
            public string ProcessName { get; }
            public int ProcessId { get; }

            public ProcessEventArgs(string processName, int processId)
            {
                ProcessName = processName;
                ProcessId = processId;
            }

            public ProcessEventArgs(string processName)
            {
                ProcessName = processName;
                ProcessId = -1;  // Вказуємо, що ID невідомий
            }
        }
    }







