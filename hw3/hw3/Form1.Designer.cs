namespace hw3
{
    partial class Form1
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
            this.encryption_btn = new System.Windows.Forms.Button();
            this.text_txtbx = new System.Windows.Forms.TextBox();
            this.key_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decryption_btn = new System.Windows.Forms.Button();
            this.result_txtbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // encryption_btn
            // 
            this.encryption_btn.Location = new System.Drawing.Point(12, 146);
            this.encryption_btn.Name = "encryption_btn";
            this.encryption_btn.Size = new System.Drawing.Size(112, 23);
            this.encryption_btn.TabIndex = 0;
            this.encryption_btn.Text = "encryption";
            this.encryption_btn.UseVisualStyleBackColor = true;
            this.encryption_btn.Click += new System.EventHandler(this.encryption_btn_Click);
            // 
            // text_txtbx
            // 
            this.text_txtbx.Location = new System.Drawing.Point(12, 28);
            this.text_txtbx.Name = "text_txtbx";
            this.text_txtbx.Size = new System.Drawing.Size(260, 20);
            this.text_txtbx.TabIndex = 1;
            // 
            // key_txtbx
            // 
            this.key_txtbx.Location = new System.Drawing.Point(12, 70);
            this.key_txtbx.Name = "key_txtbx";
            this.key_txtbx.Size = new System.Drawing.Size(260, 20);
            this.key_txtbx.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plaintext Or Ciphertext";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result:";
            // 
            // decryption_btn
            // 
            this.decryption_btn.Location = new System.Drawing.Point(131, 146);
            this.decryption_btn.Name = "decryption_btn";
            this.decryption_btn.Size = new System.Drawing.Size(141, 23);
            this.decryption_btn.TabIndex = 9;
            this.decryption_btn.Text = "decryption";
            this.decryption_btn.UseVisualStyleBackColor = true;
            this.decryption_btn.Click += new System.EventHandler(this.decryption_btn_Click);
            // 
            // result_txtbx
            // 
            this.result_txtbx.Location = new System.Drawing.Point(16, 117);
            this.result_txtbx.Name = "result_txtbx";
            this.result_txtbx.Size = new System.Drawing.Size(256, 20);
            this.result_txtbx.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.result_txtbx);
            this.Controls.Add(this.decryption_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key_txtbx);
            this.Controls.Add(this.text_txtbx);
            this.Controls.Add(this.encryption_btn);
            this.Name = "Form1";
            this.Text = "Do the thing!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryption_btn;
        private System.Windows.Forms.TextBox text_txtbx;
        private System.Windows.Forms.TextBox key_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button decryption_btn;
        private System.Windows.Forms.TextBox result_txtbx;
    }
}

