using System.Drawing;

namespace MakeSquare
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.Sequential = new System.Windows.Forms.Button();
            this.Parallel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartLabel = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Sequential
            // 
            this.Sequential.BackColor = System.Drawing.Color.Linen;
            this.Sequential.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sequential.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.Sequential.FlatAppearance.BorderSize = 2;
            this.Sequential.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Sequential.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Sequential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sequential.Font = new System.Drawing.Font("Mistral", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sequential.ForeColor = System.Drawing.Color.Teal;
            this.Sequential.Location = new System.Drawing.Point(54, 400);
            this.Sequential.Name = "Sequential";
            this.Sequential.Size = new System.Drawing.Size(139, 53);
            this.Sequential.TabIndex = 0;
            this.Sequential.Text = "Sequential";
            this.Sequential.UseVisualStyleBackColor = false;
            this.Sequential.Click += new System.EventHandler(this.button1_Click);
            // 
            // Parallel
            // 
            this.Parallel.BackColor = System.Drawing.Color.Linen;
            this.Parallel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.Parallel.FlatAppearance.BorderSize = 3;
            this.Parallel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Khaki;
            this.Parallel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Parallel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Parallel.Font = new System.Drawing.Font("Mistral", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parallel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.Parallel.Location = new System.Drawing.Point(428, 400);
            this.Parallel.Name = "Parallel";
            this.Parallel.Size = new System.Drawing.Size(148, 53);
            this.Parallel.TabIndex = 1;
            this.Parallel.Text = "Parallel";
            this.Parallel.UseVisualStyleBackColor = false;
            this.Parallel.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(228, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 255);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Font = new System.Drawing.Font("Mistral", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabel.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.StartLabel.Location = new System.Drawing.Point(100, 30);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(418, 76);
            this.StartLabel.TabIndex = 3;
            this.StartLabel.Text = "* Make A Square *";
            // 
            // line
            // 
            this.line.ForeColor = System.Drawing.Color.White;
            this.line.Location = new System.Drawing.Point(110, 100);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(500, 76);
            this.line.TabIndex = 0;
            this.line.Text = " __________________________________________________________________";
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "input/input1/input2/input3";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(203, 522);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(184, 20);
            this.input.TabIndex = 5;
            this.input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(653, 569);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.line);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Parallel);
            this.Controls.Add(this.Sequential);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Coral;
            this.Name = "StartForm";
            this.Text = "Start Your Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sequential;
        private System.Windows.Forms.Button Parallel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input;
    }
}