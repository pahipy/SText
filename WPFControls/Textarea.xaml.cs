using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Textarea : UserControl
    {
        public Textarea()
        {
            InitializeComponent();
        }


        public string Text
        {
            get => this.TextViewer.Text;
            set => this.TextViewer.Text = value;
        }

        public Brush Backcolor
        {
            get => this.TextViewer.Background;
            set
            {
                this.Background= value;
                this.TextViewer.Background = value;
            }
        }

        public Brush Textcolor
        {
            get => this.TextViewer.Foreground;
            set => this.TextViewer.Foreground = value;
        }

        public int SelectionStart
        {
            get => this.TextViewer.SelectionStart;
            set => this.TextViewer.SelectionStart = value;
        }

        public int SelectionLength
        {
            get => this.TextViewer.SelectionLength;
            set => this.TextViewer.SelectionLength = value;
        }

        public bool WordWrap
        {
            get => this.TextViewer.TextWrapping == TextWrapping.Wrap ? true : false;
            set
            {
                if (value)
                    this.TextViewer.TextWrapping = TextWrapping.Wrap;
                else
                    this.TextViewer.TextWrapping = TextWrapping.NoWrap;
            }
        }

        public TextBox Inner
        {
            get => this.TextViewer;
        }

        public SolidColorBrush MenuItemColorOnMouseHover
        {
            get => (SolidColorBrush)this.Resources["MenuItemColorOnMouseHover"];
            set => this.Resources["MenuItemColorOnMouseHover"] = value;
        }
        
        public SolidColorBrush MenuItemColorOnMousePressed
        {
            get => (SolidColorBrush)this.Resources["MenuItemColorOnMousePressed"];
            set => this.Resources["MenuItemColorOnMousePressed"] = value;
        }
        
        public SolidColorBrush ContextMenuBackground
        {
            get => (SolidColorBrush)this.Resources["ContextMenuBackground"];
            set => this.Resources["ContextMenuBackground"] = value;
        }
        
        public SolidColorBrush ContextMenuForeground
        {
            get => (SolidColorBrush)this.Resources["ContextMenuForeground"];
            set => this.Resources["ContextMenuForeground"] = value;
        }
        
        public SolidColorBrush MenuSeparatorColor
        {
            get => (SolidColorBrush)this.Resources["MenuSeparatorColor"];
            set => this.Resources["MenuSeparatorColor"] = value;
        }

        public FontFamily FontFamilyForContextMenu
        {
            get => (FontFamily)this.Resources["FontFamilyForContextMenu"];
            set => this.Resources["FontFamilyForContextMenu"] = value;
        }

        public Color ScrollBarThumbColor
        {
            get => (Color)this.Resources["ControlColor"];
            set => this.Resources["ControlColor"] = value;
        }

        public SolidColorBrush BackgroundScrollBarColor
        {
            get => (SolidColorBrush)this.Resources["BackgroundScrollBar"];
            set => this.Resources["BackgroundScrollBar"] = value;
        }

        public Color ScrollBarGlyphColor
        {
            get => (Color)this.Resources["GlyphColor"];
            set => this.Resources["GlyphColor"] = value;
        }


        private System.Drawing.FontStyle FontStyleWinFroms
        {
            get
            {
                System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;

                if (this.TextViewer.FontWeight == FontWeights.Bold)
                    style |= System.Drawing.FontStyle.Bold;
                if (this.TextViewer.FontStyle == FontStyles.Italic || this.TextViewer.FontStyle == FontStyles.Oblique)
                    style |= System.Drawing.FontStyle.Italic;

                if (TextViewer.TextDecorations.Contains(TextDecorations.Underline[0]))
                    style |= System.Drawing.FontStyle.Underline;
                if (TextViewer.TextDecorations.Contains(TextDecorations.Strikethrough[0]))
                    style |= System.Drawing.FontStyle.Strikeout;
                   return style;

            }
        }

        private float fontSizePt = 14;
        public System.Drawing.Font Font
        {
            get => new System.Drawing.Font(TextViewer.FontFamily.Source, fontSizePt, FontStyleWinFroms);
            set
            {
                TextViewer.FontFamily = new FontFamily(value.FontFamily.Name);
                fontSizePt = value.Size;
                TextViewer.FontSize = (97d / 72d) * fontSizePt;

                if (value.Bold)
                    TextViewer.FontWeight = FontWeights.Bold;
                else
                    TextViewer.FontWeight = FontWeights.Normal;
                if (value.Style == System.Drawing.FontStyle.Italic)
                    TextViewer.FontStyle = FontStyles.Italic;
                else
                    TextViewer.FontStyle = FontStyles.Normal;
                if (value.Style == System.Drawing.FontStyle.Regular)
                    TextViewer.FontStyle = FontStyles.Normal;

                if (value.Style == (System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold))
                {
                    TextViewer.FontStyle = FontStyles.Italic;
                    TextViewer.FontWeight = FontWeights.Bold;
                }
                else
                {
                    if (value.Style != System.Drawing.FontStyle.Italic)
                        TextViewer.FontStyle = FontStyles.Normal;
                    if (!value.Bold)
                        TextViewer.FontWeight = FontWeights.Normal;
                }

                TextDecorationCollection res;

                if (value.Underline)
                {
                    if (!TextViewer.TextDecorations.Contains(TextDecorations.Underline[0]))
                        TextViewer.TextDecorations.Add(TextDecorations.Underline);
                }  
                else
                {
                    if (TextViewer.TextDecorations.TryRemove(TextDecorations.Underline, out res))
                        TextViewer.TextDecorations = res;
                }

                if (value.Strikeout)
                {
                    if (!TextViewer.TextDecorations.Contains(TextDecorations.Strikethrough[0]))
                        TextViewer.TextDecorations.Add(TextDecorations.Strikethrough);
                }          
                else
                {
                    if (TextViewer.TextDecorations.TryRemove(TextDecorations.Strikethrough, out res))
                        TextViewer.TextDecorations = res;
                }
            }
        }

        public void Cut()
        {
            TextViewer.Cut();
        }

        public void Copy()
        {
            TextViewer.Copy();
        }

        public void Paste()
        {
            TextViewer.Paste();
        }

        public bool Undo()
        {
            return TextViewer.Undo();
        }

        public bool Redo()
        {
            return TextViewer.Redo();
        }

        public void Select(int start, int length)
        {
            TextViewer.Select(start, length);
        }

        public void SelectAll()
        {
            TextViewer.SelectAll();
        }

        private void UndoItem_Click(object sender, RoutedEventArgs e)
        {
            TextViewer.Undo();
        }

        private void CutItem_Click(object sender, RoutedEventArgs e)
        {
            TextViewer.Cut();
        }

        private void CopyItem_Click(object sender, RoutedEventArgs e)
        {
            TextViewer.Copy();
        }

        private void PasteItem_Click(object sender, RoutedEventArgs e)
        {
            TextViewer.Paste();
        }

        private void SelectAllItem_Click(object sender, RoutedEventArgs e)
        {
            TextViewer.SelectAll();
        }

    }
}