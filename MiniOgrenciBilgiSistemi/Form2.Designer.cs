namespace MiniOgrenciBilgiSistemi
{
    partial class Form2
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
            lbl_OgrenciBilgisi = new Label();
            dgw_table = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgw_table).BeginInit();
            SuspendLayout();
            // 
            // lbl_OgrenciBilgisi
            // 
            lbl_OgrenciBilgisi.AutoSize = true;
            lbl_OgrenciBilgisi.Location = new Point(44, 55);
            lbl_OgrenciBilgisi.Name = "lbl_OgrenciBilgisi";
            lbl_OgrenciBilgisi.Size = new Size(38, 15);
            lbl_OgrenciBilgisi.TabIndex = 0;
            lbl_OgrenciBilgisi.Text = "label1";
            // 
            // dgw_table
            // 
            dgw_table.AllowUserToAddRows = false;
            dgw_table.AllowUserToDeleteRows = false;
            dgw_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgw_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgw_table.Location = new Point(44, 100);
            dgw_table.Name = "dgw_table";
            dgw_table.ReadOnly = true;
            dgw_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw_table.Size = new Size(656, 256);
            dgw_table.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(278, 380);
            button1.Name = "button1";
            button1.Size = new Size(124, 48);
            button1.TabIndex = 2;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dgw_table);
            Controls.Add(lbl_OgrenciBilgisi);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgw_table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_OgrenciBilgisi;
        private DataGridView dgw_table;
        private Button button1;
    }
}