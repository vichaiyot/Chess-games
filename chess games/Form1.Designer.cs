namespace kk
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
            this.ggg = new System.Windows.Forms.Button();
            this.statbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ggg
            // 
            this.ggg.Enabled = false;
            this.ggg.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.ggg.Location = new System.Drawing.Point(1015, 332);
            this.ggg.Margin = new System.Windows.Forms.Padding(4);
            this.ggg.Name = "ggg";
            this.ggg.Size = new System.Drawing.Size(135, 53);
            this.ggg.TabIndex = 5;
            this.ggg.Text = "เริ่มเกม";
            this.ggg.UseVisualStyleBackColor = true;
            this.ggg.Click += new System.EventHandler(this.ggg_Click);
            // 
            // statbtn
            // 
            this.statbtn.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statbtn.Location = new System.Drawing.Point(1015, 231);
            this.statbtn.Margin = new System.Windows.Forms.Padding(4);
            this.statbtn.Name = "statbtn";
            this.statbtn.Size = new System.Drawing.Size(135, 55);
            this.statbtn.TabIndex = 4;
            this.statbtn.Text = "เข้าเกม";
            this.statbtn.UseVisualStyleBackColor = true;
            this.statbtn.Click += new System.EventHandler(this.statbtn_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1015, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 57);
            this.button1.TabIndex = 6;
            this.button1.Text = "เริ่มเกมใหม่";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe Print", 55F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(186, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 203);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome To";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe Print", 60F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(80, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(914, 201);
            this.label2.TabIndex = 8;
            this.label2.Text = "อดนอนหมากรุก";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1253, 780);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ggg);
            this.Controls.Add(this.statbtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "อดนอนหมากรุก";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ggg;
        private System.Windows.Forms.Button statbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

