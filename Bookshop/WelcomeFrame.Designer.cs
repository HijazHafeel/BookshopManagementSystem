namespace Bookshop_Management_System.Bookshop
{
    partial class WelcomeFrame
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
            this.btnBook = new System.Windows.Forms.Button();
            this.btnstaff = new System.Windows.Forms.Button();
            this.btnpub = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 446);
            this.panel1.TabIndex = 0;
            // 
            // btnBook
            // 
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Location = new System.Drawing.Point(367, 108);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(206, 91);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnstaff
            // 
            this.btnstaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstaff.Location = new System.Drawing.Point(616, 108);
            this.btnstaff.Name = "btnstaff";
            this.btnstaff.Size = new System.Drawing.Size(206, 91);
            this.btnstaff.TabIndex = 2;
            this.btnstaff.Text = "Staff";
            this.btnstaff.UseVisualStyleBackColor = true;
            this.btnstaff.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnpub
            // 
            this.btnpub.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpub.Location = new System.Drawing.Point(841, 108);
            this.btnpub.Name = "btnpub";
            this.btnpub.Size = new System.Drawing.Size(206, 91);
            this.btnpub.TabIndex = 3;
            this.btnpub.Text = "Publisher";
            this.btnpub.UseVisualStyleBackColor = true;
            this.btnpub.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthor.Location = new System.Drawing.Point(485, 239);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(206, 91);
            this.btnAuthor.TabIndex = 4;
            this.btnAuthor.Text = "Author";
            this.btnAuthor.UseVisualStyleBackColor = true;
            this.btnAuthor.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.Location = new System.Drawing.Point(758, 239);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(206, 91);
            this.btnBilling.TabIndex = 5;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bookshop_Management_System.Properties.Resources.WhatsApp_Image_2026_05_08_at_8_56_47_PM;
            this.pictureBox1.Location = new System.Drawing.Point(64, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // WelcomeFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 450);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnpub);
            this.Controls.Add(this.btnstaff);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.panel1);
            this.Name = "WelcomeFrame";
            this.Text = "WelcomeFrame";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnstaff;
        private System.Windows.Forms.Button btnpub;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnBilling;
    }
}