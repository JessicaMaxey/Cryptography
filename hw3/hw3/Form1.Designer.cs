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
            this.go_btn = new System.Windows.Forms.Button();
            this.text_txtbx = new System.Windows.Forms.TextBox();
            this.key_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.result_1_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.result_2_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // go_btn
            // 
            this.go_btn.Location = new System.Drawing.Point(12, 197);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(260, 23);
            this.go_btn.TabIndex = 0;
            this.go_btn.Text = "Do the thing!";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.go_btn_Click);
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
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result 1:";
            // 
            // result_1_lbl
            // 
            this.result_1_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.result_1_lbl.Location = new System.Drawing.Point(13, 117);
            this.result_1_lbl.Name = "result_1_lbl";
            this.result_1_lbl.Size = new System.Drawing.Size(259, 21);
            this.result_1_lbl.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Result 2:";
            // 
            // result_2_lbl
            // 
            this.result_2_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.result_2_lbl.Location = new System.Drawing.Point(13, 162);
            this.result_2_lbl.Name = "result_2_lbl";
            this.result_2_lbl.Size = new System.Drawing.Size(259, 19);
            this.result_2_lbl.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.result_2_lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.result_1_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key_txtbx);
            this.Controls.Add(this.text_txtbx);
            this.Controls.Add(this.go_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button go_btn;
        private System.Windows.Forms.TextBox text_txtbx;
        private System.Windows.Forms.TextBox key_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label result_1_lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label result_2_lbl;
    }
}

