using ICSharpCode.AvalonEdit.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace SText.Editor
{
    public partial class MainWindow : FluentWindow
    {

        private int lastFoundPosition = 0;
        private bool ReplaceActivated
        {
            get => ReplaceCatGrid.Visibility == Visibility.Visible;
            set
            {
                ReplaceCatGrid.Visibility = value ? ReplaceCatGrid.Visibility = Visibility.Visible : ReplaceCatGrid.Visibility = Visibility.Collapsed;
                SearchBox.Height = value ? 90d : 45d;
            }
        }

        private int FindNext(int startPosition = 0, string pattern = "", bool dontCallItself = false)
        {
            int end = 0;

            for (int i = startPosition; i < ContentViewer.Text.Length; i++)
                if (i + pattern.Length >= ContentViewer.Text.Length - 1)
                {
                    ContentViewer.CaretOffset = 0;
                    if (!dontCallItself)
                        return FindNext(ContentViewer.CaretOffset, pattern, true);
                    return ContentViewer.CaretOffset;
                }
                else
                if (pattern == ContentViewer.Text.Substring(i, pattern.Length))
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
                    ContentViewer.CaretOffset = ContentViewer.Text.Length - 1;
                    if (!dontCallItself)
                        return FindPrevious(ContentViewer.CaretOffset, pattern, true);
                    return ContentViewer.CaretOffset;
                }
                else
                if (pattern == ContentViewer.Text.Substring(i - pattern.Length, pattern.Length))
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
            CallFindNext();
        }

        private void FindPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CallFindPrevious();
        }

        private void CallFindNext()
        {
            string pattern = SearchTextInput.Text;

            lastFoundPosition = FindNext(ContentViewer.CaretOffset, pattern);
        }

        private void CallFindPrevious()
        {
            string pattern = SearchTextInput.Text;

            lastFoundPosition = FindPrevious(ContentViewer.CaretOffset, pattern);
        }
        private void ToggleReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            ReplaceActivated = !ReplaceActivated;
        }

        private void CallReplace()
        {
            string findPattern = SearchTextInput.Text,
                   replacePattern = ReplaceTextInput.Text;

            int caret = ContentViewer.CaretOffset;

            if (ContentViewer.SelectionLength == 0 || ContentViewer.SelectedText != findPattern)
                lastFoundPosition = FindNext(ContentViewer.CaretOffset, findPattern);
            else
            {
                int selStart = ContentViewer.SelectionStart;
                Content = ContentViewer.Text.Remove(selStart, ContentViewer.SelectionLength).Insert(selStart, replacePattern);
                ContentViewer.CaretOffset = caret;
            }
        }

        private void CallReplaceAll()
        {
            Content = ContentViewer.Text.Replace(SearchTextInput.Text, ReplaceTextInput.Text);
        }

        private void ReplaceEnterButton_Click(object sender, RoutedEventArgs e)
        {
            CallReplace();
        }

        private void ReplaceAllButton_Click(object sender, RoutedEventArgs e)
        {
            CallReplaceAll();
        }

        private void SearchTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            int lps = 0;
            if (ContentViewer.SelectionLength > 0)
            {
                int c = ContentViewer.CaretOffset - ContentViewer.SelectionLength;
                lps = c < 0 ? ContentViewer.CaretOffset : c;
            }
            else
            {
                lps = lastFoundPosition;
            }

                int caret = FindNext(lps, SearchTextInput.Text);

            if (caret >= 0)
              ContentViewer.CaretOffset = caret;
        }

        private void FindNextCommand(object sender, ExecutedRoutedEventArgs e)
        {
            CallFindNext();
        }

        private void FindPreviousCommand(object sender, ExecutedRoutedEventArgs e)
        {
            CallFindPrevious();
        }

        private void ReplaceCommand(object sender, ExecutedRoutedEventArgs e)
        {
            CallReplace();
        }

        private void ReplaceAllCommand(object sender, ExecutedRoutedEventArgs e)
        {
            CallReplaceAll();
        }

        private void CloseFindButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Visibility = Visibility.Hidden;
        }
    }
}
