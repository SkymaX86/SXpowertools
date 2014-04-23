using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SXpowertools.UI.Application.WinForms
{
    public enum WaitWindowProgressIndicator
    {
        AnimatedCircle,
        AnimatedElipse,
        AnimatedTrapezoids,
        Indicator,
        LoopingCircle,
        SimpleRing,
        Spiral,
        TurningArrows,
        TurningCircle,
        TurningGear,
        TurningIndicator
    }

    public struct WaitWindowUserState
    {
        public string Caption { get; set; }
        public string Message { get; set; }
    }

    public partial class WaitForm : Form
    {
        object parameter = null;
        string cancelText = "Abbruch";
        bool centerToParent = true;

        public WaitForm()
        {
            InitializeComponent();
        }

        
        #region With Progressbar

        public WaitForm(string caption, string message, DoWorkEventHandler work)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            HideProgressIndicator();
            HideCancelButton();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, string cancelText, DoWorkEventHandler work)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.cancelText = cancelText;

            HideProgressIndicator();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, DoWorkEventHandler work, object parameter)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.parameter = parameter;

            HideProgressIndicator();
            HideCancelButton();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, string cancelText, DoWorkEventHandler work, object parameter)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.cancelText = cancelText;
            this.parameter = parameter;

            HideProgressIndicator();

            backgroundWorker.DoWork += work;
        }
        
        #endregion

        #region With ProgressIndicator

        public WaitForm(string caption, string message, WaitWindowProgressIndicator progressIndicator, DoWorkEventHandler work)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            SetIndicatorImage(progressIndicator);

            HideProgressBar();
            HideCancelButton();

            CenterToParent();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, string cancelText, WaitWindowProgressIndicator progressIndicator, DoWorkEventHandler work)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.cancelText = cancelText;

            SetIndicatorImage(progressIndicator);

            HideProgressBar();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, WaitWindowProgressIndicator progressIndicator, DoWorkEventHandler work, object parameter)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.parameter = parameter;

            SetIndicatorImage(progressIndicator);

            HideProgressBar();
            HideCancelButton();

            CenterToParent();

            backgroundWorker.DoWork += work;
        }

        public WaitForm(string caption, string message, string cancelText, WaitWindowProgressIndicator progressIndicator, DoWorkEventHandler work, object parameter)
        {
            InitializeComponent();

            label_Caption.Text = caption;
            label_Message.Text = message;

            this.cancelText = cancelText;
            this.parameter = parameter;

            SetIndicatorImage(progressIndicator);

            HideProgressBar();
            HideCancelButton();

            backgroundWorker.DoWork += work;
        }
        
        #endregion

        
        private void WaitForm_Load(object sender, EventArgs e)
        {
            if(parameter != null)
                backgroundWorker.RunWorkerAsync(parameter);
            else
                backgroundWorker.RunWorkerAsync();

            if(centerToParent)
                CenterToParent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            label_Caption.Text = cancelText;
            backgroundWorker.CancelAsync();

            button_Cancel.Enabled = false;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WaitWindowUserState currentState = (WaitWindowUserState)e.UserState;
            progressBar.Value = e.ProgressPercentage;

            label_Caption.Text = currentState.Caption;
            label_Message.Text = currentState.Message;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        
        private void SetIndicatorImage(WaitWindowProgressIndicator progressIndicator)
        {
            switch (progressIndicator)
            {
                case WaitWindowProgressIndicator.AnimatedCircle:
                    pictureBox1.Image = SXpowertools.Properties.Resources.animatedCircle;
                    break;
                case WaitWindowProgressIndicator.AnimatedElipse:
                    pictureBox1.Image = SXpowertools.Properties.Resources.animatedEllipse;
                    break;
                case WaitWindowProgressIndicator.AnimatedTrapezoids:
                    pictureBox1.Image = SXpowertools.Properties.Resources.animatedTrapezoids;
                    break;
                case WaitWindowProgressIndicator.Indicator:
                    pictureBox1.Image = SXpowertools.Properties.Resources.indicator;
                    break;
                case WaitWindowProgressIndicator.LoopingCircle:
                    pictureBox1.Image = SXpowertools.Properties.Resources.loopingCircle;
                    break;
                case WaitWindowProgressIndicator.SimpleRing:
                    pictureBox1.Image = SXpowertools.Properties.Resources.simpleRing;
                    break;
                case WaitWindowProgressIndicator.Spiral:
                    pictureBox1.Image = SXpowertools.Properties.Resources.spiral;
                    break;
                case WaitWindowProgressIndicator.TurningArrows:
                    pictureBox1.Image = SXpowertools.Properties.Resources.turningArrows;
                    break;
                case WaitWindowProgressIndicator.TurningCircle:
                    pictureBox1.Image = SXpowertools.Properties.Resources.turningCircle;
                    break;
                case WaitWindowProgressIndicator.TurningGear:
                    pictureBox1.Image = SXpowertools.Properties.Resources.turningGear;
                    break;
                case WaitWindowProgressIndicator.TurningIndicator:
                    pictureBox1.Image = SXpowertools.Properties.Resources.turningIndicator;
                    break;
                default:
                    pictureBox1.Image = SXpowertools.Properties.Resources.animatedCircle;
                    break;
            }
        }

        private void HideProgressIndicator()
        {
            label_Caption.Left = pictureBox1.Left;
            label_Message.Left = pictureBox1.Left;

            int left = progressBar.Left - pictureBox1.Left;

            button_Cancel.Left = button_Cancel.Left - left;

            progressBar.Left = pictureBox1.Left;

            pictureBox1.Visible = false;

            this.Width = this.Width - left;
            panelBg.Width = panelBg.Width - left;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.MaximumSize = new Size(this.Width, this.Height);
            
        }

        private void HideProgressBar()
        {
            progressBar.Visible = false;

            label_Caption.Top = label_Caption.Top + label_Caption.Height;
            label_Message.Top = progressBar.Top;
        }

        private void HideCancelButton()
        {
            button_Cancel.Visible = false;
            
            this.Height = this.Height - button_Cancel.Height;
            panelBg.Height = panelBg.Height - button_Cancel.Height;
        }
    }
}
