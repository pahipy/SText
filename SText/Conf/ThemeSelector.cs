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
        private static ColorSchema[] colors = new ColorSchema[]
        {
            new ColorSchema()
            {   //Light theme
                ThemeName= "Light",
                StatusBarColor = Color.FromArgb(240, 240, 240),
                StatusBarFontColor = Color.FromArgb(0, 0, 0),
                ControlColor = Color.FromArgb(255, 255, 255),
                ControlFontColor = Color.Black,
                MenuColor = Color.FromArgb(240, 240, 240),
                MenuFontColor = Color.Black,
                MenuSeparatorColor = System.Windows.Media.Color.FromRgb(205, 205, 205),
                MenuItemSelectedColor = Color.FromArgb(145, 201, 247),
                MenuItemSelectedFontColor = Color.Black,
                ToolPanelColor = Color.FromArgb(228, 244, 255),
                ToolPanelFontColor = Color.Black,
                ButtonColor = Color.FromArgb(44, 67, 156),
                ButtonFontColor = Color.White,
                TextFieldColor = Color.White,
                TextFieldFontColor = Color.Black,
                ScrollBarThumbColor = System.Windows.Media.Color.FromRgb(205, 205, 205),
                ScrollBarBackgroundColor = System.Windows.Media.Color.FromRgb(240, 240, 240),
                ScrollBarGlyphColor = System.Windows.Media.Color.FromRgb(96, 96, 96)
            },
            new ColorSchema()
            {   //Dark theme
                ThemeName = "Dark",
                StatusBarColor = Color.FromArgb(40,40, 40),
                StatusBarFontColor = Color.FromArgb(255, 255, 255),
                ControlColor = Color.FromArgb(40, 40, 40),
                ControlFontColor = Color.FromArgb(235, 235, 235),
                MenuColor = Color.FromArgb(40, 40, 40),
                MenuFontColor= Color.White,
                MenuSeparatorColor = System.Windows.Media.Color.FromRgb(150, 150, 150),
                MenuItemSelectedColor = Color.FromArgb(70, 70, 70),
                MenuItemSelectedFontColor = Color.White,
                ToolPanelColor = Color.FromArgb(30, 30, 30),
                ToolPanelFontColor = Color.FromArgb(235, 235, 235),
                ButtonColor = Color.FromArgb(70, 70, 70),
                ButtonFontColor = Color.White,
                TextFieldColor = Color.FromArgb(30, 30, 30),
                TextFieldFontColor = Color.FromArgb(220, 220, 220),
                ScrollBarThumbColor = System.Windows.Media.Color.FromRgb(70, 70, 70),
                ScrollBarBackgroundColor = System.Windows.Media.Color.FromRgb(40, 40, 40),
                ScrollBarGlyphColor = System.Windows.Media.Color.FromRgb(203, 203, 203)
            }
        };

        public static ColorSchema[] ColorCollection { get => colors; }
        public static ColorSchema CurrentColorSchema { get => colors[(int)CurrentTheme]; }
    }

    public struct ColorSchema
    {
        public string ThemeName;
        public Color StatusBarColor;
        public Color StatusBarFontColor;
        public Color ControlColor;
        public Color ControlFontColor;
        public Color MenuColor;
        public Color MenuFontColor;
        public System.Windows.Media.Color MenuSeparatorColor;
        public Color MenuItemSelectedColor;
        public Color MenuItemSelectedFontColor;
        public Color ToolPanelColor;
        public Color ToolPanelFontColor;
        public Color ButtonColor;
        public Color ButtonFontColor;
        public Color TextFieldColor;
        public Color TextFieldFontColor;
        public System.Windows.Media.Color ScrollBarThumbColor;
        public System.Windows.Media.Color ScrollBarBackgroundColor;
        public System.Windows.Media.Color ScrollBarGlyphColor;
    };

    public enum Theme
    {
        Light = 0,
        Dark = 1
    }
}
