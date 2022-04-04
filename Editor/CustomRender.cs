using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SText.Conf;

namespace SText.Editor
{
    class CustomRender : System.Windows.Forms.ToolStripProfessionalRenderer
    {

        public CustomRender() : base(new ColorsForMenu()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ThemeSelector.CurrentTheme == Theme.Default ? Color.Black : Color.White;
            if (e.Item.Selected || e.ToolStrip.Focused)
                e.TextColor = Color.White;

            base.OnRenderItemText(e);
        }
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
            get => ThemeSelector.CurrentColorSchema.ControlColor;
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
            get => ThemeSelector.CurrentColorSchema.ControlColor;
        }

        public override Color ImageMarginGradientMiddle
        {
            get => ThemeSelector.CurrentColorSchema.ControlColor;
        }

        public override Color ImageMarginGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.ControlColor;
        }

    }
}
