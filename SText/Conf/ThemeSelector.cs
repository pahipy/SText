using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SText.Conf
{
    public static class ThemeSelector
    {
        public static Theme CurrentTheme = Theme.Light;

        
    }

    public enum Theme
    {
        Light = 0,
        Dark = 1
    }
}
