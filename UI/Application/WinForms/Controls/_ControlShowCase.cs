using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SXpowertools.Extensions;

namespace SXpowertools.UI.Application.WinForms.Controls
{
    public partial class _ControlShowCase : Form
    {
        public _ControlShowCase()
        {
            InitializeComponent();
        }

        private void _ControlShowCase_Load(object sender, EventArgs e)
        {
            #region Bordered Label
            comboBoxBorderedLabel.Items.AddRange(EnumExtensions.GetEnumNameValues<LabelBorderStyle>().Select(t => t.Value.ToString()).ToArray());
            comboBoxBorderedLabel.SelectedItem = "Solid";
            #endregion

            #region Digital Display Control
            comboBoxDigitalDisplayAlign.Items.AddRange(EnumExtensions.GetEnumNameValues<DigitTextAlign>().Select(t => t.Value.ToString()).ToArray());
            comboBoxDigitalDisplayAlign.SelectedItem = "Center";
            timerDigitalDisplay.Start();
            #endregion

            #region Image ComboBox

            comboBoxImageComboBoxDropDownStyle.Items.AddRange(EnumExtensions.GetEnumNameValues<ComboBoxStyle>().Select(t => t.Value.ToString()).ToArray());
            comboBoxImageComboBoxDropDownStyle.SelectedItem = "DropDownList";

            #region DummyImages in ImageList schreiben

            System.Drawing.Bitmap flag = new System.Drawing.Bitmap(16, 16);

            for (int x = 0; x < flag.Height; ++x)
                for (int y = 0; y < flag.Width; ++y)
                    flag.SetPixel(x, y, Color.Red);

            System.Drawing.Bitmap flag1 = new System.Drawing.Bitmap(16, 16);

            for (int x = 0; x < flag1.Height; ++x)
                for (int y = 0; y < flag1.Width; ++y)
                    flag1.SetPixel(x, y, Color.Green);

            System.Drawing.Bitmap flag2 = new System.Drawing.Bitmap(16, 16);

            for (int x = 0; x < flag2.Height; ++x)
                for (int y = 0; y < flag2.Width; ++y)
                    flag2.SetPixel(x, y, Color.Blue);

            imageList1.Images.Add(flag);
            imageList1.Images.Add(flag1);
            imageList1.Images.Add(flag2);

            #endregion

            //Das ImageComboBoxItem verfügt über die Parameter Text, ImageIndex und Tag(object)
            imageComboBox1.Items.Add(new ImageComboBoxItem("Zeile 1", 0));
            imageComboBox1.Items.Add(new ImageComboBoxItem("Zeile 2", 1));
            imageComboBox1.Items.Add(new ImageComboBoxItem("Zeile 3", 2));

            imageComboBox1.SelectedIndex = 0;
            #endregion
        }

        #region Bordered Label
        private void comboBoxBorderedLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            borderedLabel1.LabelBorderStyle = EnumExtensions.Parse<LabelBorderStyle>(comboBoxBorderedLabel.SelectedItem.ToString());
        }

        private void buttonBorderedLabelColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                borderedLabel1.BorderColor = colorDialog.Color;
        }
        #endregion

        #region Digital Display Control
        private void buttonDigitalDisplayColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                digitalDisplayControl1.DigitColor = colorDialog.Color;
        }

        private void comboBoxDigitalDisplayAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            digitalDisplayControl1.DigitTextAlign = EnumExtensions.Parse<DigitTextAlign>(comboBoxDigitalDisplayAlign.SelectedItem.ToString());
        }

        private void timerDigitalDisplay_Tick(object sender, EventArgs e)
        {
            digitalDisplayControl1.DigitText = DateTime.Now.ToString("hh:mm:ss");
        }
        #endregion

        #region Image ComboBox
        private void comboBoxImageComboBoxDropDownStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageComboBox1.DropDownStyle = EnumExtensions.Parse<ComboBoxStyle>(comboBoxImageComboBoxDropDownStyle.SelectedItem.ToString());
        }
        #endregion

        #region Watermark Textbox
        private void buttonWatermarkColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                watermarkTextBox1.WatermarkColor = colorDialog.Color;
        }
        #endregion
    }
}
