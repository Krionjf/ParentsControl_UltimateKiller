namespace ParentsKiller_Form
{
    partial class Form3
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
            this.delete_label = new System.Windows.Forms.Label();
            this.delete_text = new System.Windows.Forms.TextBox();
            this.exit_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delete_label
            // 
            this.delete_label.AutoSize = true;
            this.delete_label.BackColor = System.Drawing.Color.White;
            this.delete_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_label.Location = new System.Drawing.Point(169, 9);
            this.delete_label.Name = "delete_label";
            this.delete_label.Size = new System.Drawing.Size(129, 19);
            this.delete_label.TabIndex = 6;
            this.delete_label.Text = "Назву файла .ехе";
            // 
            // delete_text
            // 
            this.delete_text.Location = new System.Drawing.Point(119, 62);
            this.delete_text.Name = "delete_text";
            this.delete_text.Size = new System.Drawing.Size(220, 20);
            this.delete_text.TabIndex = 5;
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.White;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.Location = new System.Drawing.Point(12, 188);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(200, 49);
            this.exit_button.TabIndex = 8;
            this.exit_button.Text = "Вийти";
            this.exit_button.UseVisualStyleBackColor = false;
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.Color.White;
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_button.Location = new System.Drawing.Point(250, 188);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(200, 49);
            this.delete_button.TabIndex = 7;
            this.delete_button.Text = "Видалити";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 248);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.delete_label);
            this.Controls.Add(this.delete_text);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label delete_label;
        private System.Windows.Forms.TextBox delete_text;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button delete_button;
    }
}