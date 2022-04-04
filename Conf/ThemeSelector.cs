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
        public static Theme CurrentTheme = Theme.Default;
        private static ColorSchema[] colors = new ColorSchema[]
        {
            new ColorSchema()
            {   //Default theme
                StatusBarColor = Color.FromArgb(240, 240, 240),
                StatusBarFontColor = Color.FromArgb(0, 0, 0),
                ControlColor = Color.FromArgb(240, 240, 240),
                ControlFontColor = Color.Black,
                ToolPanelColor = Color.FromArgb(228, 244, 255),
                ToolPanelFontColor = Color.Black,
                ButtonColor = Color.FromArgb(118, 163, 230),
                ButtonFontColor = Color.Black,
                TextFieldColor = Color.White,
                TextFieldFontColor = Color.Black
            },
            new ColorSchema()
            {   //Dark theme
                StatusBarColor = Color.FromArgb(25, 60, 149),
                StatusBarFontColor = Color.FromArgb(255, 255, 255),
                ControlColor = Color.FromArgb(52, 52, 52),
                ControlFontColor = Color.White,
                ToolPanelColor = Color.FromArgb(38, 35, 54),
                ToolPanelFontColor = Color.FromArgb(235, 235, 235),
                ButtonColor = Color.FromArgb(44, 67, 156),
                ButtonFontColor = Color.White,
                TextFieldColor = Color.FromArgb(66, 66, 66),
                TextFieldFontColor = Color.FromArgb(213, 213, 213)
            },
            new ColorSchema()
            {   //Blue theme
                StatusBarColor = Color.FromArgb(179, 208, 255),
                StatusBarFontColor = Color.FromArgb(0, 0, 0),
                ControlColor = Color.FromArgb(35, 139, 255),
                ControlFontColor = Color.White,
                ToolPanelColor = Color.FromArgb(228, 244, 255),
                ToolPanelFontColor = Color.Black,
                ButtonColor = Color.FromArgb(118, 163, 230),
                ButtonFontColor = Color.Black,
                TextFieldColor = Color.FromArgb(231, 236, 255),
                TextFieldFontColor = Color.FromArgb(0, 0, 0)
            }
        };

        public static ColorSchema[] ColorCollection { get => colors; }
        public static ColorSchema CurrentColorSchema { get => colors[(int)CurrentTheme]; }
    }

    public struct ColorSchema
    {
        public Color StatusBarColor;
        public Color StatusBarFontColor;
        public Color ControlColor;
        public Color ControlFontColor;
        public Color ToolPanelColor;
        public Color ToolPanelFontColor;
        public Color ButtonColor;
        public Color ButtonFontColor;
        public Color TextFieldColor;
        public Color TextFieldFontColor;
    };

    public enum Theme
    {
        Default = 0,
        Dark = 1,
        Blue = 2
    }
}
