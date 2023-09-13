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
            panel2 = new Panel();
            dGV_main = new DataGridView();
            dGV_submain = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_main).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGV_submain).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dGV_main);
            panel1.Location = new Point(12, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 429);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dGV_submain);
            panel2.Location = new Point(607, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 429);
            panel2.TabIndex = 1;
            // 
            // dGV_main
            // 
            dGV_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_main.Location = new Point(3, 43);
            dGV_main.Name = "dGV_main";
            dGV_main.RowTemplate.Height = 25;
            dGV_main.Size = new Size(583, 383);
            dGV_main.TabIndex = 0;
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
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_main).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGV_submain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dGV_main;
        private Panel panel2;
        private DataGridView dGV_submain;
    }
}