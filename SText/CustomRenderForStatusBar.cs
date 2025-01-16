using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SText.Conf;

namespace SText.Editor
{
    class CustomRenderForStatusBar : System.Windows.Forms.ToolStripProfessionalRenderer
    {
        public CustomRenderForStatusBar() : base(new ColorsForStatusBar())
        {
            this.RoundedEdges = false;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ThemeSelector.CurrentColorSchema.StatusBarFontColor;

            if (e.Item.Selected || e.ToolStrip.Focused)
                e.TextColor = ThemeSelector.CurrentColorSchema.MenuItemSelectedFontColor;

            base.OnRenderItemText(e);
        }

    }

    public class ColorsForStatusBar : ProfessionalColorTable
    {

        public override Color ToolStripGradientBegin
        {
            get => ThemeSelector.CurrentColorSchema.StatusBarColor;
        }

        public override Color ToolStripGradientMiddle
        {
            get => ThemeSelector.CurrentColorSchema.StatusBarColor;
        }

        public override Color ToolStripGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.StatusBarColor;
        }

        public override Color ToolStripBorder
        {
            get => ThemeSelector.CurrentColorSchema.StatusBarColor;
        }

        public override Color ButtonSelectedBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color ButtonSelectedGradientBegin
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color ButtonSelectedGradientMiddle
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
        }

        public override Color ButtonSelectedGradientEnd
        {
            get => ThemeSelector.CurrentColorSchema.MenuItemSelectedColor;
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

        public override Color MenuItemBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }

        public override Color MenuBorder
        {
            get => Color.FromArgb(0, 0, 0, 0);
        }
    }

}
