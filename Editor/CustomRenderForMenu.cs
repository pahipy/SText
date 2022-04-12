using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SText.Conf;

namespace SText.Editor
{
    class CustomRenderForMenu : System.Windows.Forms.ToolStripProfessionalRenderer
    {

        public CustomRenderForMenu() : base(new ColorsForMenu())
        {
            this.RoundedEdges = false;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ThemeSelector.CurrentTheme == Theme.Default ? Color.Black : Color.White;
            if (e.Item.Selected || e.ToolStrip.Focused)
                e.TextColor = ThemeSelector.CurrentColorSchema.MenuItemSelectedFontColor;

            base.OnRenderItemText(e);
        }
        
    }

    public class ColorsForMenu : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color MenuItemBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color MenuBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color MenuItemPressedGradientBegin
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color MenuItemPressedGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color ToolStripDropDownBackground
        {
            get => ThemeSelector.CurrentColorSchema.MenuColor;
        }

        public override Color ImageMarginGradientBegin
        {
            get => ThemeSelector.CurrentColorSchema.MenuColor;
        }

        public override Color ImageMarginGradientMiddle
        {
            get => ThemeSelector.CurrentColorSchema.MenuColor;
        }

        public override Color ImageMarginGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.MenuColor;
        }

    }
}
