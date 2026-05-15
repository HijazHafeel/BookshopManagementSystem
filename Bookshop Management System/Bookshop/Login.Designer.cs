namespace Bookshop_Management_System.Bookshop
{
    partial class Login
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
            this.lblUname = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.llblFPd = new System.Windows.Forms.LinkLabel();
            this.llblReg = new System.Windows.Forms.LinkLabel();
            this.lblDisp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUname.Location = new System.Drawing.Point(125, 79);
            this.lblUname.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(132, 29);
            this.lblUname.TabIndex = 0;
            this.lblUname.Text = "Username";
            this.lblUname.Click += new System.EventHandler(this.lblUname_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(125, 177);
            this.lblPass.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(128, 29);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Password";
            this.lblPass.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(226, 370);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(174, 44);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(454, 79);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(100, 34);
            this.txtUname.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(454, 177);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 34);
            this.txtPass.TabIndex = 6;
            this.txtPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // llblFPd
            // 
            this.llblFPd.AutoSize = true;
            this.llblFPd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblFPd.Location = new System.Drawing.Point(319, 298);
            this.llblFPd.Name = "llblFPd";
            this.llblFPd.Size = new System.Drawing.Size(180, 25);
            this.llblFPd.TabIndex = 7;
            this.llblFPd.TabStop = true;
            this.llblFPd.Text = "Forgot_Password";
            this.llblFPd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFPd_LinkClicked);
            // 
            // llblReg
            // 
            this.llblReg.AutoSize = true;
            this.llblReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblReg.Location = new System.Drawing.Point(162, 298);
            this.llblReg.Name = "llblReg";
            this.llblReg.Size = new System.Drawing.Size(91, 25);
            this.llblReg.TabIndex = 8;
            this.llblReg.TabStop = true;
            this.llblReg.Text = "Register";
            // 
            // lblDisp
            // 
            this.lblDisp.AutoSize = true;
            this.lblDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisp.Location = new System.Drawing.Point(222, 240);
            this.lblDisp.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDisp.Name = "lblDisp";
            this.lblDisp.Size = new System.Drawing.Size(210, 20);
            this.lblDisp.TabIndex = 9;
            this.lblDisp.Text = "Enter Username Password";
            this.lblDisp.Click += new System.EventHandler(this.lblDisp_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(705, 469);
            this.Controls.Add(this.lblDisp);
            this.Controls.Add(this.llblReg);
            this.Controls.Add(this.llblFPd);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUname);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.LinkLabel llblFPd;
        private System.Windows.Forms.LinkLabel llblReg;
        private System.Windows.Forms.Label lblDisp;
    }
}