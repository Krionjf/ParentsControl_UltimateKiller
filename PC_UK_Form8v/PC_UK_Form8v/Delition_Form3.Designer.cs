namespace PC_UK_Form8v
{
    partial class Delition_Form3
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            exit_button = new Button();
            deletion_button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 117);
            label1.Name = "label1";
            label1.Size = new Size(173, 30);
            label1.TabIndex = 0;
            label1.Text = "Шлях до файлу";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 199);
            label2.Name = "label2";
            label2.Size = new Size(196, 30);
            label2.TabIndex = 1;
            label2.Text = "Назва файлу в БД";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(257, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(257, 208);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 23);
            textBox2.TabIndex = 3;
            // 
            // exit_button
            // 
            exit_button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            exit_button.Location = new Point(14, 292);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(165, 37);
            exit_button.TabIndex = 4;
            exit_button.Text = "Скасувати";
            exit_button.UseVisualStyleBackColor = true;
            exit_button.Click += exit_button_Click;
            // 
            // deletion_button
            // 
            deletion_button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deletion_button.Location = new Point(301, 292);
            deletion_button.Name = "deletion_button";
            deletion_button.Size = new Size(165, 37);
            deletion_button.TabIndex = 5;
            deletion_button.Text = "Видалити";
            deletion_button.UseVisualStyleBackColor = true;
            deletion_button.Click += deletion_button_Click;
            // 
            // Delition_Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 368);
            Controls.Add(deletion_button);
            Controls.Add(exit_button);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Delition_Form3";
            Text = "Delition_Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button exit_button;
        private Button deletion_button;
    }
}