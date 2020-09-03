namespace HondaDisplay
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
            this.Image0 = new System.Windows.Forms.WebBrowser();
            this.partNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Image0
            // 
            this.Image0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Image0.Location = new System.Drawing.Point(6, 8);
            this.Image0.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Image0.MinimumSize = new System.Drawing.Size(13, 13);
            this.Image0.Name = "Image0";
            this.Image0.Size = new System.Drawing.Size(669, 350);
            this.Image0.TabIndex = 0;
            this.Image0.Url = new System.Uri("C:\\ProgramData\\Cognex\\In-Sight\\Emulators\\5.9.2\\Image000.svg", System.UriKind.Absolute);
            // 
            // partNumber
            // 
            this.partNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partNumber.AutoSize = true;
            this.partNumber.Location = new System.Drawing.Point(316, 360);
            this.partNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.partNumber.Name = "partNumber";
            this.partNumber.Size = new System.Drawing.Size(0, 17);
            this.partNumber.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 474);
            this.Controls.Add(this.partNumber);
            this.Controls.Add(this.Image0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Image Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser Image0;
        private System.Windows.Forms.Label partNumber;
    }
}

