using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;

namespace SText.Editor
{
    public static class SDocument
    {


        private static EndOfLineType endOfLineType = EndOfLineType.LF;
        public static EndOfLineType EndOfLineType
        {
            get => endOfLineType;
            set => endOfLineType = value;
        }

        private static EndOfLineType oldEndOfLineType = EndOfLineType.LF;

        public static bool IsChanged
        {
            get
            {
                if (origDocument.Count == currentDocument.Count && endOfLineType == oldEndOfLineType)
                {
                    for (int i = 0, j = origDocument.Count() - 1;  i <= j && j > 0; i++, j--)
                    {
                        if (origDocument[i] != currentDocument[i] || origDocument[j] != currentDocument[j])
                            return true;
                    }
                    return false;
                }

                return true;
            }
        }


        private static List<DocumentLine> origDocument = new List<DocumentLine>();
        private static List<DocumentLine> currentDocument = new List<DocumentLine>();

        public static void SetDocument(ref TextEditor editor)
        {
            if (editor.Document.Lines.Count > 0)
            {
                endOfLineType = editor.Document.Lines[0].DelimiterLength > 1 ? EndOfLineType.CRLF : EndOfLineType.LF;
            }
            else
            {
                endOfLineType = EndOfLineType.LF;
            }

            oldEndOfLineType = endOfLineType;

            editor.Document = new TextDocument(string.Empty);
            origDocument.Clear();
            origDocument.AddRange(editor.Document.Lines);
            editor.Document.TextChanged += Document_TextChanged;
        }

        private static void Document_TextChanged(object? sender, EventArgs e)
        {
            currentDocument.Clear();
            currentDocument.AddRange(((TextDocument)sender).Lines);
        }
    }
}
