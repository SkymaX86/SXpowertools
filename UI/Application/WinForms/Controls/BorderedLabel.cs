using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SXpowertools.UI.Application.WinForms.Controls
{
    public enum LabelBorderStyle
    {
        Dashed,
        Solid,
        Dotted,
        Inset,
        Outset,
    }

    public class BorderedLabel : Label
    {
        private Color _bordercolor = Color.Black;
        private LabelBorderStyle _borderStyle = LabelBorderStyle.Solid;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;

        [Browsable(true), DefaultValue("Color.Black")]
        public Color BorderColor
        {
            get
            {
                return _bordercolor;
            }
            set
            {
                this._bordercolor = value;
                Invalidate();
            }
        }

        [Browsable(true), DefaultValue(LabelBorderStyle.Solid)]
        public LabelBorderStyle LabelBorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                this._borderStyle = value;

                switch (_borderStyle)
                {
                    case LabelBorderStyle.Dashed:
                        _buttonBorderStyle = ButtonBorderStyle.Dashed;
                        break;
                    case LabelBorderStyle.Solid:
                        _buttonBorderStyle = ButtonBorderStyle.Solid;
                        break;
                    case LabelBorderStyle.Dotted:
                        _buttonBorderStyle = ButtonBorderStyle.Dotted;
                        break;
                    case LabelBorderStyle.Inset:
                        _buttonBorderStyle = ButtonBorderStyle.Inset;
                        break;
                    case LabelBorderStyle.Outset:
                        _buttonBorderStyle = ButtonBorderStyle.Outset;
                        break;
                }

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, _bordercolor, _buttonBorderStyle);
        }
    }
}
