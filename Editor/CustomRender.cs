using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SText.Editor
{
    class CustomRender : System.Windows.Forms.ToolStripProfessionalRenderer
    {

        public CustomRender() : base(new ColorsForMenu()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {

            //e.ToolStrip.ForeColor = ThemeSelector.CurrentTheme == Theme.Default ? Color.Black : Color.White;
            e.TextColor = ThemeSelector.CurrentTheme == Theme.Default ? Color.Black : Color.White;
            if (e.Item.Selected || e.ToolStrip.Focused)
                e.TextColor = Color.White;

            base.OnRenderItemText(e);
        }

        /* protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
         {
             //e.Graphics.Clear(Color.FromArgb(52, 52, 52));
             //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), e.Item.ContentRectangle);

             base.OnRenderMenuItemBackground(e);
         }

         protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
         {
             e.Graphics.Clear(Color.FromArgb(52, 52, 52));
             base.OnRenderToolStripBackground(e);
         }*/
    }

    public class ColorsForMenu : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get => Color.FromArgb(25, 59, 181);
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get => Color.FromArgb(25, 59, 181);
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get => Color.FromArgb(25, 59, 181);
        }

        public override Color MenuItemBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color MenuBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                Color req = Color.White;
                switch (ThemeSelector.CurrentTheme)
                {
                    case Theme.Default: req = Color.FromArgb(240, 240, 240); break;
                    case Theme.Dark: req = Color.FromArgb(52, 52, 52); break;
                    case Theme.Blue: req = Color.FromArgb(35, 139, 255); break;
                }
                return req;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get => Color.FromArgb(25, 59, 181);
        }

        public override Color MenuItemPressedGradientEnd
        {
            get => Color.FromArgb(25, 59, 181);
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                Color req = Color.White;
                switch (ThemeSelector.CurrentTheme)
                {
                    case Theme.Default: req = Color.FromArgb(240, 240, 240); break;
                    case Theme.Dark: req = Color.FromArgb(52, 52, 52); break;
                    case Theme.Blue: req = Color.FromArgb(35, 139, 255); break;
                }
                return req;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                Color req = Color.White;
                switch (ThemeSelector.CurrentTheme)
                {
                    case Theme.Default: req = Color.FromArgb(240, 240, 240); break;
                    case Theme.Dark: req = Color.FromArgb(52, 52, 52); break;
                    case Theme.Blue: req = Color.FromArgb(35, 139, 255); break;
                }
                return req;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                Color req = Color.White;
                switch (ThemeSelector.CurrentTheme)
                {
                    case Theme.Default: req = Color.FromArgb(240, 240, 240); break;
                    case Theme.Dark: req = Color.FromArgb(52, 52, 52); break;
                    case Theme.Blue: req = Color.FromArgb(35, 139, 255); break;
                }
                return req;
            }
        }

    }
}
