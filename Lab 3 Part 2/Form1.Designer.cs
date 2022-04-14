
namespace Lab_3_Part_2
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
            this.Transparency = new System.Windows.Forms.Button();
            this.BackgroundColor = new System.Windows.Forms.Button();
            this.HelloWorld = new System.Windows.Forms.Button();
            this.SuperButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Transparency
            // 
            this.Transparency.Location = new System.Drawing.Point(12, 21);
            this.Transparency.Name = "Transparency";
            this.Transparency.Size = new System.Drawing.Size(96, 35);
            this.Transparency.TabIndex = 0;
            this.Transparency.Text = "Прозорість";
            this.Transparency.UseVisualStyleBackColor = true;
            this.Transparency.Click += new System.EventHandler(this.Transparency_Click);
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.Location = new System.Drawing.Point(141, 21);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(116, 35);
            this.BackgroundColor.TabIndex = 1;
            this.BackgroundColor.Text = "Колір тла";
            this.BackgroundColor.UseVisualStyleBackColor = true;
            this.BackgroundColor.Click += new System.EventHandler(this.BackgroundColor_Click);
            // 
            // HelloWorld
            // 
            this.HelloWorld.Location = new System.Drawing.Point(287, 21);
            this.HelloWorld.Name = "HelloWorld";
            this.HelloWorld.Size = new System.Drawing.Size(111, 35);
            this.HelloWorld.TabIndex = 2;
            this.HelloWorld.Text = "Hello world";
            this.HelloWorld.UseVisualStyleBackColor = true;
            this.HelloWorld.Click += new System.EventHandler(this.HelloWorld_Click);
            // 
            // SuperButton
            // 
            this.SuperButton.Location = new System.Drawing.Point(12, 68);
            this.SuperButton.Name = "SuperButton";
            this.SuperButton.Size = new System.Drawing.Size(386, 38);
            this.SuperButton.TabIndex = 3;
            this.SuperButton.Text = "Супермегакнопка";
            this.SuperButton.UseVisualStyleBackColor = true;
            this.SuperButton.Click += new System.EventHandler(this.SuperButton_Click);
            this.SuperButton.MouseCaptureChanged += new System.EventHandler(this.SuperButton_MouseCaptureChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 112);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(307, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "\"Супермегакнопка\" поглинає \"Прозорість\"";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 139);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(297, 21);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "\"Супермегакнопка\" поглинає \"Колір тла\"";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(13, 166);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(307, 21);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "\"Супермегакнопка\" поглинає \"Hello World\"";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 381);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SuperButton);
            this.Controls.Add(this.HelloWorld);
            this.Controls.Add(this.BackgroundColor);
            this.Controls.Add(this.Transparency);
            this.Name = "Form1";
            this.Text = "Лабораторна 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Transparency;
        private System.Windows.Forms.Button BackgroundColor;
        private System.Windows.Forms.Button HelloWorld;
        private System.Windows.Forms.Button SuperButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

