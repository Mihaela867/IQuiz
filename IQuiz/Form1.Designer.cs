namespace IQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Info_button = new System.Windows.Forms.PictureBox();
            this.music_button = new System.Windows.Forms.PictureBox();
            this.sound_button = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Info_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.music_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sound_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).BeginInit();
            this.SuspendLayout();
            // 
            // Info_button
            // 
            this.Info_button.BackColor = System.Drawing.Color.Transparent;
            this.Info_button.BackgroundImage = global::IQuiz.Properties.Resources.info_icon;
            this.Info_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Info_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Info_button.Location = new System.Drawing.Point(12, 12);
            this.Info_button.Name = "Info_button";
            this.Info_button.Size = new System.Drawing.Size(70, 70);
            this.Info_button.TabIndex = 2;
            this.Info_button.TabStop = false;
            this.Info_button.Click += new System.EventHandler(this.Info_button_Click);
            // 
            // music_button
            // 
            this.music_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.music_button.BackColor = System.Drawing.Color.Transparent;
            this.music_button.BackgroundImage = global::IQuiz.Properties.Resources.music_icon;
            this.music_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.music_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.music_button.Location = new System.Drawing.Point(1102, 12);
            this.music_button.MaximumSize = new System.Drawing.Size(70, 70);
            this.music_button.MinimumSize = new System.Drawing.Size(50, 50);
            this.music_button.Name = "music_button";
            this.music_button.Size = new System.Drawing.Size(70, 70);
            this.music_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.music_button.TabIndex = 3;
            this.music_button.TabStop = false;
            this.music_button.Click += new System.EventHandler(this.music_button_Click);
            // 
            // sound_button
            // 
            this.sound_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sound_button.BackColor = System.Drawing.Color.Transparent;
            this.sound_button.BackgroundImage = global::IQuiz.Properties.Resources.sound_icon;
            this.sound_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sound_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sound_button.Location = new System.Drawing.Point(1026, 12);
            this.sound_button.MaximumSize = new System.Drawing.Size(70, 70);
            this.sound_button.MinimumSize = new System.Drawing.Size(50, 50);
            this.sound_button.Name = "sound_button";
            this.sound_button.Size = new System.Drawing.Size(70, 70);
            this.sound_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sound_button.TabIndex = 4;
            this.sound_button.TabStop = false;
            this.sound_button.Click += new System.EventHandler(this.sound_button_Click);
            // 
            // start_button
            // 
            this.start_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.start_button.BackColor = System.Drawing.Color.Transparent;
            this.start_button.BackgroundImage = global::IQuiz.Properties.Resources.buton_start;
            this.start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.Location = new System.Drawing.Point(316, 277);
            this.start_button.MaximumSize = new System.Drawing.Size(241, 74);
            this.start_button.MinimumSize = new System.Drawing.Size(150, 50);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(207, 58);
            this.start_button.TabIndex = 6;
            this.start_button.TabStop = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::IQuiz.Properties.Resources.fundal_pagina_start;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.sound_button);
            this.Controls.Add(this.music_button);
            this.Controls.Add(this.Info_button);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Modern No. 20", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQuiz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Info_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.music_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sound_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Info_button;
        private System.Windows.Forms.PictureBox sound_button;
        private System.Windows.Forms.PictureBox start_button;
        private System.Windows.Forms.PictureBox music_button;
    }
}

