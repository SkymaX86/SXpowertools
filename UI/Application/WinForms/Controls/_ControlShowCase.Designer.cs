namespace SXpowertools.UI.Application.WinForms.Controls
{
    partial class _ControlShowCase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_ControlShowCase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBorderedLabel = new System.Windows.Forms.ComboBox();
            this.buttonBorderedLabelColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDigitalDisplayColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDigitalDisplayAlign = new System.Windows.Forms.ComboBox();
            this.timerDigitalDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxImageComboBoxDropDownStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonWatermarkColor = new System.Windows.Forms.Button();
            this.watermarkTextBox1 = new SXpowertools.UI.Application.WinForms.Controls.WatermarkTextBox();
            this.imageComboBox1 = new SXpowertools.UI.Application.WinForms.Controls.ImageComboBox();
            this.digitalDisplayControl1 = new SXpowertools.UI.Application.WinForms.Controls.DigitalDisplayControl();
            this.borderedLabel1 = new SXpowertools.UI.Application.WinForms.Controls.BorderedLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 715);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxBorderedLabel);
            this.groupBox1.Controls.Add(this.buttonBorderedLabelColor);
            this.groupBox1.Controls.Add(this.borderedLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bordered Label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Style wählen";
            // 
            // comboBoxBorderedLabel
            // 
            this.comboBoxBorderedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBorderedLabel.FormattingEnabled = true;
            this.comboBoxBorderedLabel.Location = new System.Drawing.Point(350, 39);
            this.comboBoxBorderedLabel.Name = "comboBoxBorderedLabel";
            this.comboBoxBorderedLabel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBorderedLabel.TabIndex = 4;
            this.comboBoxBorderedLabel.SelectedIndexChanged += new System.EventHandler(this.comboBoxBorderedLabel_SelectedIndexChanged);
            // 
            // buttonBorderedLabelColor
            // 
            this.buttonBorderedLabelColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorderedLabelColor.Location = new System.Drawing.Point(350, 66);
            this.buttonBorderedLabelColor.Name = "buttonBorderedLabelColor";
            this.buttonBorderedLabelColor.Size = new System.Drawing.Size(121, 23);
            this.buttonBorderedLabelColor.TabIndex = 3;
            this.buttonBorderedLabelColor.Text = "Farbe wählen";
            this.buttonBorderedLabelColor.UseVisualStyleBackColor = true;
            this.buttonBorderedLabelColor.Click += new System.EventHandler(this.buttonBorderedLabelColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxDigitalDisplayAlign);
            this.groupBox2.Controls.Add(this.buttonDigitalDisplayColor);
            this.groupBox2.Controls.Add(this.digitalDisplayControl1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Digital Display Control";
            // 
            // buttonDigitalDisplayColor
            // 
            this.buttonDigitalDisplayColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDigitalDisplayColor.Location = new System.Drawing.Point(350, 62);
            this.buttonDigitalDisplayColor.Name = "buttonDigitalDisplayColor";
            this.buttonDigitalDisplayColor.Size = new System.Drawing.Size(121, 23);
            this.buttonDigitalDisplayColor.TabIndex = 6;
            this.buttonDigitalDisplayColor.Text = "Farbe wählen";
            this.buttonDigitalDisplayColor.UseVisualStyleBackColor = true;
            this.buttonDigitalDisplayColor.Click += new System.EventHandler(this.buttonDigitalDisplayColor_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 57);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ausrichtung wählen";
            // 
            // comboBoxDigitalDisplayAlign
            // 
            this.comboBoxDigitalDisplayAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDigitalDisplayAlign.FormattingEnabled = true;
            this.comboBoxDigitalDisplayAlign.Location = new System.Drawing.Point(350, 35);
            this.comboBoxDigitalDisplayAlign.Name = "comboBoxDigitalDisplayAlign";
            this.comboBoxDigitalDisplayAlign.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDigitalDisplayAlign.TabIndex = 6;
            this.comboBoxDigitalDisplayAlign.SelectedIndexChanged += new System.EventHandler(this.comboBoxDigitalDisplayAlign_SelectedIndexChanged);
            // 
            // timerDigitalDisplay
            // 
            this.timerDigitalDisplay.Tick += new System.EventHandler(this.timerDigitalDisplay_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBoxImageComboBoxDropDownStyle);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.imageComboBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 148);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ImageComboBox";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(502, 69);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // comboBoxImageComboBoxDropDownStyle
            // 
            this.comboBoxImageComboBoxDropDownStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxImageComboBoxDropDownStyle.FormattingEnabled = true;
            this.comboBoxImageComboBoxDropDownStyle.Location = new System.Drawing.Point(350, 109);
            this.comboBoxImageComboBoxDropDownStyle.Name = "comboBoxImageComboBoxDropDownStyle";
            this.comboBoxImageComboBoxDropDownStyle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxImageComboBoxDropDownStyle.TabIndex = 9;
            this.comboBoxImageComboBoxDropDownStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxImageComboBoxDropDownStyle_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "DropDownStyle";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonWatermarkColor);
            this.groupBox4.Controls.Add(this.watermarkTextBox1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 424);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(526, 116);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Watermark Textbox";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(418, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hier kann ein Standarttext (WatermarkText) angegeben werden der als Erklärung die" +
    "nt.";
            // 
            // buttonWatermarkColor
            // 
            this.buttonWatermarkColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWatermarkColor.Location = new System.Drawing.Point(292, 46);
            this.buttonWatermarkColor.Name = "buttonWatermarkColor";
            this.buttonWatermarkColor.Size = new System.Drawing.Size(179, 23);
            this.buttonWatermarkColor.TabIndex = 7;
            this.buttonWatermarkColor.Text = "Watermark Farbe wählen";
            this.buttonWatermarkColor.UseVisualStyleBackColor = true;
            this.buttonWatermarkColor.Click += new System.EventHandler(this.buttonWatermarkColor_Click);
            // 
            // watermarkTextBox1
            // 
            this.watermarkTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watermarkTextBox1.ForeColor = System.Drawing.Color.Empty;
            this.watermarkTextBox1.Location = new System.Drawing.Point(9, 49);
            this.watermarkTextBox1.Name = "watermarkTextBox1";
            this.watermarkTextBox1.Size = new System.Drawing.Size(274, 20);
            this.watermarkTextBox1.TabIndex = 1;
            this.watermarkTextBox1.Watermark = "Dieser Text verschwindet beim Textbox_Enter";
            this.watermarkTextBox1.WatermarkColor = System.Drawing.Color.Silver;
            // 
            // imageComboBox1
            // 
            this.imageComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageComboBox1.FormattingEnabled = true;
            this.imageComboBox1.ImageList = this.imageList1;
            this.imageComboBox1.Location = new System.Drawing.Point(9, 109);
            this.imageComboBox1.Name = "imageComboBox1";
            this.imageComboBox1.Size = new System.Drawing.Size(174, 21);
            this.imageComboBox1.TabIndex = 0;
            // 
            // digitalDisplayControl1
            // 
            this.digitalDisplayControl1.BackColor = System.Drawing.Color.Transparent;
            this.digitalDisplayControl1.DigitColor = System.Drawing.Color.Black;
            this.digitalDisplayControl1.Location = new System.Drawing.Point(6, 89);
            this.digitalDisplayControl1.Name = "digitalDisplayControl1";
            this.digitalDisplayControl1.Size = new System.Drawing.Size(277, 46);
            this.digitalDisplayControl1.TabIndex = 0;
            // 
            // borderedLabel1
            // 
            this.borderedLabel1.BorderColor = System.Drawing.Color.Black;
            this.borderedLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderedLabel1.Location = new System.Drawing.Point(6, 22);
            this.borderedLabel1.Name = "borderedLabel1";
            this.borderedLabel1.Size = new System.Drawing.Size(280, 79);
            this.borderedLabel1.TabIndex = 0;
            this.borderedLabel1.Text = "Das ist ein normales Label mit einstellbarer\r\n\r\n- BorderFarbe\r\n- BorderStyle";
            // 
            // _ControlShowCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 720);
            this.Controls.Add(this.panel1);
            this.Name = "_ControlShowCase";
            this.Text = "_ControlShowCase";
            this.Load += new System.EventHandler(this._ControlShowCase_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBorderedLabelColor;
        private BorderedLabel borderedLabel1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBorderedLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDigitalDisplayColor;
        private DigitalDisplayControl digitalDisplayControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDigitalDisplayAlign;
        private System.Windows.Forms.Timer timerDigitalDisplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private ImageComboBox imageComboBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxImageComboBoxDropDownStyle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonWatermarkColor;
        private WatermarkTextBox watermarkTextBox1;
        private System.Windows.Forms.Label label6;
    }
}