namespace CustomVisionObjectDetectionClient
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelMain = new System.Windows.Forms.Panel();
            this.webCameraControl1 = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelButtonBar = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelLoadingImage = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonCamera = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFile = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelButtonBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.webCameraControl1);
            this.panelMain.Controls.Add(this.pictureBox);
            this.panelMain.Controls.Add(this.panelButtonBar);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1276, 880);
            this.panelMain.TabIndex = 4;
            // 
            // webCameraControl1
            // 
            this.webCameraControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webCameraControl1.Location = new System.Drawing.Point(0, 67);
            this.webCameraControl1.Name = "webCameraControl1";
            this.webCameraControl1.Size = new System.Drawing.Size(1276, 813);
            this.webCameraControl1.TabIndex = 5;
            this.webCameraControl1.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(0, 67);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1276, 813);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // panelButtonBar
            // 
            this.panelButtonBar.Controls.Add(this.panel4);
            this.panelButtonBar.Controls.Add(this.panel8);
            this.panelButtonBar.Controls.Add(this.panel2);
            this.panelButtonBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonBar.Location = new System.Drawing.Point(0, 0);
            this.panelButtonBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtonBar.Name = "panelButtonBar";
            this.panelButtonBar.Size = new System.Drawing.Size(1276, 67);
            this.panelButtonBar.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.labelLoadingImage);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(400, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(876, 67);
            this.panel4.TabIndex = 5;
            // 
            // labelLoadingImage
            // 
            this.labelLoadingImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoadingImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLoadingImage.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadingImage.Location = new System.Drawing.Point(0, 0);
            this.labelLoadingImage.Name = "labelLoadingImage";
            this.labelLoadingImage.Size = new System.Drawing.Size(876, 67);
            this.labelLoadingImage.TabIndex = 3;
            this.labelLoadingImage.Text = "Loading.";
            this.labelLoadingImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoadingImage.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.buttonCamera);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(200, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 67);
            this.panel8.TabIndex = 6;
            // 
            // buttonCamera
            // 
            this.buttonCamera.BackColor = System.Drawing.Color.Gray;
            this.buttonCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCamera.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCamera.Location = new System.Drawing.Point(0, 0);
            this.buttonCamera.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCamera.Name = "buttonCamera";
            this.buttonCamera.Size = new System.Drawing.Size(200, 67);
            this.buttonCamera.TabIndex = 7;
            this.buttonCamera.Text = "Camera";
            this.buttonCamera.UseVisualStyleBackColor = false;
            this.buttonCamera.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.buttonFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 67);
            this.panel2.TabIndex = 4;
            // 
            // buttonFile
            // 
            this.buttonFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFile.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFile.Location = new System.Drawing.Point(0, 0);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(200, 67);
            this.buttonFile.TabIndex = 4;
            this.buttonFile.Text = "File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 880);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Object Detection";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelButtonBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelButtonBar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelLoadingImage;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button buttonCamera;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonFile;
        private WebEye.Controls.WinForms.WebCameraControl.WebCameraControl webCameraControl1;
    }
}

