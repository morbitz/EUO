namespace RuOSIParser
{
    partial class MainForm
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
            this.buttonImportar = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelClassCount = new System.Windows.Forms.Label();
            this.listBoxClasses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonImportar
            // 
            this.buttonImportar.Location = new System.Drawing.Point(419, 10);
            this.buttonImportar.Name = "buttonImportar";
            this.buttonImportar.Size = new System.Drawing.Size(75, 23);
            this.buttonImportar.TabIndex = 0;
            this.buttonImportar.Text = "Importar";
            this.buttonImportar.UseVisualStyleBackColor = true;
            this.buttonImportar.Click += new System.EventHandler(this.buttonImportar_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 12);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(401, 20);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.Text = "http://ruosi.org/packetguide/index.xml";
            // 
            // labelClassCount
            // 
            this.labelClassCount.Location = new System.Drawing.Point(12, 35);
            this.labelClassCount.Name = "labelClassCount";
            this.labelClassCount.Size = new System.Drawing.Size(482, 13);
            this.labelClassCount.TabIndex = 2;
            // 
            // listBoxClasses
            // 
            this.listBoxClasses.FormattingEnabled = true;
            this.listBoxClasses.Location = new System.Drawing.Point(12, 51);
            this.listBoxClasses.Name = "listBoxClasses";
            this.listBoxClasses.Size = new System.Drawing.Size(482, 173);
            this.listBoxClasses.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 239);
            this.Controls.Add(this.listBoxClasses);
            this.Controls.Add(this.labelClassCount);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.buttonImportar);
            this.Name = "MainForm";
            this.Text = "RuOSI Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImportar;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelClassCount;
        private System.Windows.Forms.ListBox listBoxClasses;
    }
}

