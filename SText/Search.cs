using ICSharpCode.AvalonEdit.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Controls;

namespace SText.Editor
{
    public partial class MainWindow : FluentWindow
    {
        private int FindNext(int startPosition = 0, string pattern = "")
        {
            int end = 0;

            for (int i = startPosition; i < Content.Length; i++)
                if (i + pattern.Length >= Content.Length - 1)
                {
                    ContentViewer.CaretOffset = 0;
                    FindNext(ContentViewer.CaretOffset, pattern);
                    return ContentViewer.CaretOffset;
                }
                else
                if (pattern == Content.Substring(i, pattern.Length))
                {
                    ContentViewer.Select(i, pattern.Length);
                    ContentViewer.TextArea.Caret.BringCaretToView();
                    end = pattern.Length + i - 1;
                    break;
                }

            return end;
        }

        private int FindPrevious(int startPosition = 0, string pattern = "")
        {
            int end = 0;

            for (int i = startPosition - 1; i > 0; i--)
                if (i - pattern.Length < pattern.Length)
                {
                    ContentViewer.CaretOffset = Content.Length - 1;
                    FindPrevious(ContentViewer.CaretOffset, pattern);
                    return ContentViewer.CaretOffset;
                }
                else
                if (pattern == Content.Substring(i - pattern.Length, pattern.Length))
                {
                    ContentViewer.Select(i - pattern.Length, pattern.Length);
                    ContentViewer.TextArea.Caret.BringCaretToView();
                    end = i - pattern.Length;
                    break;
                }

            return end;
        }

        private int FindCount(int start, int end, string str, string pattern)
        {
            int count = 0;

            for (int i = start; i < end; i++)
            {
                count = pattern == str.Substring(i, str.Length - i) ? count++ : count;
            }

            return count;
        }

        private void FindNextButton_Click(object sender, RoutedEventArgs e)
        {
            string pattern = SearchTextInput.Text;

            FindNext(ContentViewer.CaretOffset, pattern);
            
        }

        private void FindPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            string pattern = SearchTextInput.Text;

            FindPrevious(ContentViewer.CaretOffset, pattern);

        }

    }
}
