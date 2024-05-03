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
            this.processList = new System.Windows.Forms.ComboBox();
            this.injectButton = new System.Windows.Forms.Button();
            this.dllPathTEST = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(32, 224);
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
            this.injectButton.Location = new System.Drawing.Point(251, 251);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(75, 23);
            this.injectButton.TabIndex = 1;
            this.injectButton.Text = "Inject";
            this.injectButton.UseVisualStyleBackColor = true;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click_1);
            // 
            // dllPathTEST
            // 
            this.dllPathTEST.Location = new System.Drawing.Point(13, 48);
            this.dllPathTEST.Name = "dllPathTEST";
            this.dllPathTEST.Size = new System.Drawing.Size(313, 20);
            this.dllPathTEST.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 305);
            this.Controls.Add(this.dllPathTEST);
            this.Controls.Add(this.injectButton);
            this.Controls.Add(this.processList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox processList;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.TextBox dllPathTEST;
    }
}

