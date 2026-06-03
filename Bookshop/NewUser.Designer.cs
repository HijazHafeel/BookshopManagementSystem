namespace Bookshop_Management_System.Bookshop
{
    partial class NewUser
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUname = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(313, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 569);
            this.panel2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bookshop_Management_System.Properties.Resources.WhatsApp_Image_2026_05_08_at_8_56_47_PM;
            this.pictureBox1.Location = new System.Drawing.Point(48, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(257, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 79);
            this.panel1.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(524, 291);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(380, 22);
            this.txtPass.TabIndex = 15;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(524, 193);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(380, 22);
            this.txtUname.TabIndex = 14;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(334, 291);
            this.lblPass.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(128, 29);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Password";
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUname.Location = new System.Drawing.Point(334, 193);
            this.lblUname.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(132, 29);
            this.lblUname.TabIndex = 12;
            this.lblUname.Text = "Username";
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUname);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUname);
            this.Controls.Add(this.panel3);
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.Load += new System.EventHandler(this.NewUser_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUname;
    }
}