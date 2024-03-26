namespace WindowsFormsApplication2
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHD = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.panel_body = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.btnHD);
            this.panel1.Controls.Add(this.btnSP);
            this.panel1.Controls.Add(this.btnNV);
            this.panel1.Controls.Add(this.btnKH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 443);
            this.panel1.TabIndex = 0;
            // 
            // btnHD
            // 
            this.btnHD.BackColor = System.Drawing.Color.Aqua;
            this.btnHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHD.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHD.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnHD.Location = new System.Drawing.Point(0, 224);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(142, 45);
            this.btnHD.TabIndex = 0;
            this.btnHD.Text = "Hóa Đơn";
            this.btnHD.UseVisualStyleBackColor = false;
            this.btnHD.Click += new System.EventHandler(this.btnHD_Click);
            // 
            // btnSP
            // 
            this.btnSP.BackColor = System.Drawing.Color.Aqua;
            this.btnSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSP.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSP.Location = new System.Drawing.Point(0, 183);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(142, 45);
            this.btnSP.TabIndex = 0;
            this.btnSP.Text = "SP Bảo Hành";
            this.btnSP.UseVisualStyleBackColor = false;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnNV
            // 
            this.btnNV.BackColor = System.Drawing.Color.Aqua;
            this.btnNV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnNV.Location = new System.Drawing.Point(0, 141);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(142, 45);
            this.btnNV.TabIndex = 0;
            this.btnNV.Text = "Nhân Viên";
            this.btnNV.UseVisualStyleBackColor = false;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnKH
            // 
            this.btnKH.BackColor = System.Drawing.Color.Aqua;
            this.btnKH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKH.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnKH.Location = new System.Drawing.Point(0, 100);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(142, 45);
            this.btnKH.TabIndex = 0;
            this.btnKH.Text = "Khách Hàng";
            this.btnKH.UseVisualStyleBackColor = false;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // panel_body
            // 
            this.panel_body.AutoSize = true;
            this.panel_body.BackColor = System.Drawing.Color.Orange;
            this.panel_body.Controls.Add(this.label1);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(142, 0);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(699, 443);
            this.panel_body.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(228, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Bảo Hành";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 443);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Quản Lý Bảo Hành";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Label label1;
    }
}