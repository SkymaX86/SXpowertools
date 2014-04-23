namespace SXpowertools.UI.Application.WinForms
{
    partial class WaitForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Caption = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_Message = new System.Windows.Forms.Label();
            this.panelBg = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SXpowertools.Properties.Resources.animatedCircle;
            this.pictureBox1.InitialImage = global::SXpowertools.Properties.Resources.turningIndicator;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_Caption
            // 
            this.label_Caption.AutoSize = true;
            this.label_Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Caption.Location = new System.Drawing.Point(70, 12);
            this.label_Caption.Name = "label_Caption";
            this.label_Caption.Size = new System.Drawing.Size(84, 13);
            this.label_Caption.TabIndex = 1;
            this.label_Caption.Text = "label_Caption";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(291, 70);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Abbruch";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(70, 41);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(296, 23);
            this.progressBar.TabIndex = 3;
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(70, 25);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(78, 13);
            this.label_Message.TabIndex = 4;
            this.label_Message.Text = "label_Message";
            // 
            // panelBg
            // 
            this.panelBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBg.Location = new System.Drawing.Point(4, 3);
            this.panelBg.Name = "panelBg";
            this.panelBg.Size = new System.Drawing.Size(373, 100);
            this.panelBg.TabIndex = 5;
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 106);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label_Caption);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelBg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitForm";
            this.Load += new System.EventHandler(this.WaitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Caption;
        private System.Windows.Forms.Button button_Cancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Panel panelBg;
    }
}