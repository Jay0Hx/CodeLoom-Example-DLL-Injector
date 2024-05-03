namespace CodeLoom___Example_DLL_Injector
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
            this.processList = new System.Windows.Forms.ComboBox();
            this.injectButton = new System.Windows.Forms.Button();
            this.dllPathTEST = new System.Windows.Forms.TextBox();
            this.dllSelector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(13, 223);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(294, 21);
            this.processList.Sorted = true;
            this.processList.TabIndex = 0;
            // 
            // injectButton
            // 
            this.injectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.injectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.injectButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.injectButton.Location = new System.Drawing.Point(232, 250);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(75, 23);
            this.injectButton.TabIndex = 1;
            this.injectButton.Text = "Inject";
            this.injectButton.UseVisualStyleBackColor = true;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click_1);
            // 
            // dllPathTEST
            // 
            this.dllPathTEST.Location = new System.Drawing.Point(13, 158);
            this.dllPathTEST.Name = "dllPathTEST";
            this.dllPathTEST.Size = new System.Drawing.Size(295, 20);
            this.dllPathTEST.TabIndex = 2;
            // 
            // dllSelector
            // 
            this.dllSelector.Location = new System.Drawing.Point(233, 184);
            this.dllSelector.Name = "dllSelector";
            this.dllSelector.Size = new System.Drawing.Size(75, 23);
            this.dllSelector.TabIndex = 3;
            this.dllSelector.Text = "Select DLL";
            this.dllSelector.UseVisualStyleBackColor = true;
            this.dllSelector.Click += new System.EventHandler(this.dllSelector_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Process:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(88, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 281);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dllSelector);
            this.Controls.Add(this.dllPathTEST);
            this.Controls.Add(this.injectButton);
            this.Controls.Add(this.processList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox processList;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.TextBox dllPathTEST;
        private System.Windows.Forms.Button dllSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

