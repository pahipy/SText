using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace SText.Editor
{
    public sealed class CustomLinkElementGeneratorColor : VisualLineElementGenerator
    {

        public CustomLinkElementGeneratorColor(Color color)
        {
            LinkBrush = new SolidColorBrush(color);
        }

        public CustomLinkElementGeneratorColor(Color color, FontFamily fontFamily, double fontSize) : this(color)
        {
            this.fontFamily = fontFamily;
            this.fontSize = fontSize;
        }

        private Brush LinkBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        private FontFamily fontFamily = new FontFamily("Consolas");
        private double fontSize = 14;

        public override int GetFirstInterestedOffset(int startOffset)
        {
            var text = CurrentContext.Document.Text;

            for (int i = startOffset; i < text.Length; i++)
            {
                if (text[i] == ':' &&
                    i + 2 < text.Length &&
                    text[i + 1] == '/' &&
                    text[i + 2] == '/')
                {
                    return FindLinkStart(text, i);
                }
            }

            return -1;
        }

        public override VisualLineElement ConstructElement(int offset)
        {
            var text = CurrentContext.Document.Text;
            int end = FindLinkEnd(text, offset);

            if (end <= offset)
                return null;

            string url = text.Substring(offset, end - offset);

            var textBlock = new TextBlock
            {
                Text = url,
                Foreground = LinkBrush,
                TextDecorations = TextDecorations.Underline,
                Cursor = System.Windows.Input.Cursors.Hand,
                FontFamily = fontFamily,
                FontSize = fontSize
            };

            textBlock.MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 1)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });

                    e.Handled = true;
                }
            };

            return new InlineObjectElement(end - offset, textBlock);
        }

        private static int FindLinkStart(string text, int colonPosition)
        {
            int start = colonPosition;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            return start;
        }

        private static int FindLinkEnd(string text, int start)
        {
            int end = start;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            return end;
        }
    }
}
