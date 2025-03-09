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

        private bool ReplaceActivated
        {
            get => ReplaceCatGrid.Visibility == Visibility.Visible;
            set
            {
                ReplaceCatGrid.Visibility = value ? ReplaceCatGrid.Visibility = Visibility.Visible : ReplaceCatGrid.Visibility = Visibility.Collapsed;
                SearchBox.Height = value ? SearchBox.Height * 2 : SearchBox.Height / 2;
            }
        }

        private int FindNext(int startPosition = 0, string pattern = "", bool dontCallItself = false)
        {
            int end = 0;

            for (int i = startPosition; i < Content.Length; i++)
                if (i + pattern.Length >= Content.Length - 1)
                {
                    ContentViewer.CaretOffset = 0;
                    if (!dontCallItself)
                        FindNext(ContentViewer.CaretOffset, pattern, true);
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

        private int FindPrevious(int startPosition = 0, string pattern = "", bool dontCallItself = false)
        {
            int end = 0;

            for (int i = startPosition - 1; i > 0; i--)
                if (i - pattern.Length < pattern.Length)
                {
                    ContentViewer.CaretOffset = Content.Length - 1;
                    if (!dontCallItself)
                        FindPrevious(ContentViewer.CaretOffset, pattern, true);
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
        private void ToggleReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            ReplaceActivated = !ReplaceActivated;
        }

        int foundReplacementPosition = 0;
        private void ReplaceEnterButton_Click(object sender, RoutedEventArgs e)
        {
            string findPattern = SearchTextInput.Text,
                   replacePattern = ReplaceTextInput.Text;

            if (ContentViewer.SelectionLength == 0)
                foundReplacementPosition = FindNext(ContentViewer.CaretOffset, findPattern);
            else
            {
                Content = Content.Remove(foundReplacementPosition - findPattern.Length + 1, findPattern.Length);
                Content = Content.Insert(foundReplacementPosition - findPattern.Length + 1, replacePattern);
            }


        }

        private void ReplaceAllButton_Click(object sender, RoutedEventArgs e)
        {
            Content = Content.Replace(SearchTextInput.Text, ReplaceTextInput.Text);
        }

    }
}
