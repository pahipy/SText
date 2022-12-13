using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace SText.Conf
{
    public class ThemeEvents
    {

        public delegate void ThemeEventHandler(Theme theme);

        public event ThemeEventHandler ThemeChanged;

        protected virtual void OnThemeChanged(Theme theme)
        {
            ThemeEventHandler handler = ThemeChanged;
            handler?.Invoke(theme);
        }

        public void NotifyThemeChanged(Theme theme)
        {
            OnThemeChanged(theme);
        }

    }
}
