namespace Lab5App
{
    partial class FormMain
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.labelNoOfImages = new System.Windows.Forms.Label();
            this.labelURL = new System.Windows.Forms.Label();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelFoundImages = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.Location = new System.Drawing.Point(15, 27);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(657, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // listBoxImages
            // 
            this.listBoxImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.Location = new System.Drawing.Point(15, 86);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(773, 381);
            this.listBoxImages.TabIndex = 1;
            // 
            // labelNoOfImages
            // 
            this.labelNoOfImages.AutoSize = true;
            this.labelNoOfImages.Location = new System.Drawing.Point(12, 70);
            this.labelNoOfImages.Name = "labelNoOfImages";
            this.labelNoOfImages.Size = new System.Drawing.Size(13, 13);
            this.labelNoOfImages.TabIndex = 2;
            this.labelNoOfImages.Text = "0";
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(12, 9);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(150, 13);
            this.labelURL.TabIndex = 3;
            this.labelURL.Text = "Enter a URL to find its images:";
            // 
            // buttonExtract
            // 
            this.buttonExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExtract.Location = new System.Drawing.Point(691, 27);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(97, 23);
            this.buttonExtract.TabIndex = 1;
            this.buttonExtract.Text = "Extract";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(691, 479);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save images";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelFoundImages
            // 
            this.labelFoundImages.AutoSize = true;
            this.labelFoundImages.Location = new System.Drawing.Point(43, 70);
            this.labelFoundImages.Name = "labelFoundImages";
            this.labelFoundImages.Size = new System.Drawing.Size(73, 13);
            this.labelFoundImages.TabIndex = 6;
            this.labelFoundImages.Text = "found images:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(15, 479);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(657, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonExtract;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelFoundImages);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.labelNoOfImages);
            this.Controls.Add(this.listBoxImages);
            this.Controls.Add(this.textBoxURL);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "ImageScraper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.ListBox listBoxImages;
        private System.Windows.Forms.Label labelNoOfImages;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelFoundImages;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

