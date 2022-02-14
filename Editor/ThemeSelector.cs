using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SText.Editor
{
    static class ThemeSelector
    {
        public static Theme CurrentTheme = Theme.Default;
    }

    /*public struct Theme
    {
        public Color StatusBarColor;
        public Color StatusBarFontColor;
        public Color ControlColor;
        public Color ControlFontColor;
        public Color TextFieldColor;
        public Color TextFieldFontColor;
    }*/

    public enum Theme
    {
        Default = 0,
        Dark = 1,
        Blue = 2
    }
}
