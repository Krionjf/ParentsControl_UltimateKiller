namespace PC_UK_Form8v
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Add = new Button();
            Delete = new Button();
            Exit = new Button();
            label1 = new Label();
            Program_list = new DataGridView();
            clear_button = new Button();
            ((System.ComponentModel.ISupportInitialize)Program_list).BeginInit();
            SuspendLayout();
            // 
            // Add
            // 
            Add.BackColor = Color.White;
            Add.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Add.ForeColor = Color.Black;
            Add.Location = new Point(558, 446);
            Add.Margin = new Padding(4, 3, 4, 3);
            Add.Name = "Add";
            Add.Size = new Size(233, 57);
            Add.TabIndex = 0;
            Add.Text = "Додати ";
            Add.UseVisualStyleBackColor = false;
            Add.Click += button1_Click;
            // 
            // Delete
            // 
            Delete.BackColor = Color.White;
            Delete.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Delete.Location = new Point(282, 446);
            Delete.Margin = new Padding(4, 3, 4, 3);
            Delete.Name = "Delete";
            Delete.Size = new Size(233, 57);
            Delete.TabIndex = 1;
            Delete.Text = "Видалити";
            Delete.UseVisualStyleBackColor = false;
            Delete.Click += Delete_Click;
            // 
            // Exit
            // 
            Exit.BackColor = Color.White;
            Exit.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Exit.Location = new Point(13, 445);
            Exit.Margin = new Padding(4, 3, 4, 3);
            Exit.Name = "Exit";
            Exit.Size = new Size(233, 57);
            Exit.TabIndex = 3;
            Exit.Text = "Вийти";
            Exit.UseVisualStyleBackColor = false;
            Exit.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(37, 306);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 4;
            // 
            // Program_list
            // 
            Program_list.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Program_list.Location = new Point(203, 0);
            Program_list.Margin = new Padding(4, 3, 4, 3);
            Program_list.Name = "Program_list";
            Program_list.ReadOnly = true;
            Program_list.Size = new Size(601, 254);
            Program_list.TabIndex = 5;
            Program_list.CellContentClick += dataGridView1_CellContentClick;
            // 
            // clear_button
            // 
            clear_button.Location = new Point(718, 260);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(75, 23);
            clear_button.TabIndex = 6;
            clear_button.Text = "Clear grid";
            clear_button.UseVisualStyleBackColor = true;
            clear_button.Click += clear_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 519);
            Controls.Add(clear_button);
            Controls.Add(Program_list);
            Controls.Add(label1);
            Controls.Add(Exit);
            Controls.Add(Delete);
            Controls.Add(Add);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Program_list).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Program_list;
        private Button clear_button;
    }
}
