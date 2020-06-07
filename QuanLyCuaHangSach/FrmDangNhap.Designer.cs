namespace QuanLyCuaHangSach
{
    partial class FrmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdn = new System.Windows.Forms.TextBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.btndnn = new System.Windows.Forms.Button();
            this.btnthoatt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(408, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(408, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtdn
            // 
            this.txtdn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdn.Location = new System.Drawing.Point(551, 130);
            this.txtdn.Name = "txtdn";
            this.txtdn.Size = new System.Drawing.Size(162, 29);
            this.txtdn.TabIndex = 2;
            // 
            // txtmk
            // 
            this.txtmk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk.Location = new System.Drawing.Point(551, 181);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(162, 29);
            this.txtmk.TabIndex = 3;
            // 
            // btndnn
            // 
            this.btndnn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btndnn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndnn.Location = new System.Drawing.Point(505, 236);
            this.btndnn.Name = "btndnn";
            this.btndnn.Size = new System.Drawing.Size(152, 40);
            this.btndnn.TabIndex = 4;
            this.btndnn.Text = "Đăng nhập";
            this.btndnn.UseVisualStyleBackColor = false;
            this.btndnn.Click += new System.EventHandler(this.btndnn_Click);
            // 
            // btnthoatt
            // 
            this.btnthoatt.BackColor = System.Drawing.Color.Silver;
            this.btnthoatt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoatt.Location = new System.Drawing.Point(505, 291);
            this.btnthoatt.Name = "btnthoatt";
            this.btnthoatt.Size = new System.Drawing.Size(152, 40);
            this.btnthoatt.TabIndex = 6;
            this.btnthoatt.Text = "Thoát";
            this.btnthoatt.UseVisualStyleBackColor = false;
            this.btnthoatt.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(786, 501);
            this.Controls.Add(this.btnthoatt);
            this.Controls.Add(this.btndnn);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txtdn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDangNhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdn;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Button btndnn;
        private System.Windows.Forms.Button btnthoatt;
    }
}