namespace CityWithStreet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            b_mdelete = new Button();
            dGV_main = new DataGridView();
            panel2 = new Panel();
            dGV_submain = new DataGridView();
            b_msave = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_main).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_submain).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(b_msave);
            panel1.Controls.Add(b_mdelete);
            panel1.Controls.Add(dGV_main);
            panel1.Location = new Point(12, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 429);
            panel1.TabIndex = 0;
            // 
            // b_mdelete
            // 
            b_mdelete.Location = new Point(511, 14);
            b_mdelete.Name = "b_mdelete";
            b_mdelete.Size = new Size(75, 23);
            b_mdelete.TabIndex = 1;
            b_mdelete.Text = "Удалить";
            b_mdelete.UseVisualStyleBackColor = true;
            b_mdelete.Click += b_mdelete_Click;
            // 
            // dGV_main
            // 
            dGV_main.AllowUserToOrderColumns = true;
            dGV_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_main.Location = new Point(3, 43);
            dGV_main.Name = "dGV_main";
            dGV_main.RowTemplate.Height = 25;
            dGV_main.Size = new Size(583, 383);
            dGV_main.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dGV_submain);
            panel2.Location = new Point(607, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 429);
            panel2.TabIndex = 1;
            // 
            // dGV_submain
            // 
            dGV_submain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_submain.Location = new Point(3, 43);
            dGV_submain.Name = "dGV_submain";
            dGV_submain.RowTemplate.Height = 25;
            dGV_submain.Size = new Size(514, 383);
            dGV_submain.TabIndex = 0;
            // 
            // b_msave
            // 
            b_msave.Location = new Point(430, 14);
            b_msave.Name = "b_msave";
            b_msave.Size = new Size(75, 23);
            b_msave.TabIndex = 2;
            b_msave.Text = "Сохранить";
            b_msave.UseVisualStyleBackColor = true;
            b_msave.Click += b_msave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 486);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_main).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_submain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dGV_main;
        private Panel panel2;
        private DataGridView dGV_submain;
        private Button b_mdelete;
        private Button b_msave;
    }
}