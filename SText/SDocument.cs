using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;

namespace SText.Editor
{
    public class SDocument
    {

        private EndOfLineType endOfLineType = EndOfLineType.LF;
        public EndOfLineType EndOfLineType
        {
            get => endOfLineType;
            set
            {
                if (oldEndOfLineType != value || TextWasChanged())
                {
                    endOfLineType = value;
                    SDocumentEventArgs e = new();
                    OnTextChanged(e);
                }
                else
                {
                    isChanged = false;
                }
            }
        }

        private EndOfLineType oldEndOfLineType = EndOfLineType.LF;

        private bool isChanged;
        public bool IsChanged => isChanged;

        public string CurrentFullText
        {
            get => string.Join(endOfLineType == EndOfLineType.LF ? "\n" : "\r\n", currentDocument);
        }

        public SDocument(string text)
        {
            InitContent(text);
        }

        public string this[int i]
        {
            get => currentDocument[i];
            set
            {
                if (!currentDocument[i].Equals(value))
                {
                    currentDocument[i] = value.ReplaceLineEndings("");
                    SDocumentEventArgs e = new();
                    e.Line = i;
                    OnTextChanged(e);
                }
            }
        }

        private static List<string> origDocument = new ();
        private static List<string> currentDocument = new ();

        private void InitContent(string text)
        {
            origDocument = new();
            currentDocument = new();
            oldEndOfLineType = text.Contains("\r\n") ? EndOfLineType.CRLF : EndOfLineType.LF;
            endOfLineType = oldEndOfLineType;
            origDocument = GetListFromString(text);
            currentDocument.AddRange(origDocument);
        }

        private List<string> GetListFromString(string text)
        {
            List<string> list = new List<string>();
            list.AddRange(text.ReplaceLineEndings("\n").Split('\n'));
            return list;
        }

        public void SetText(string text)
        {
            //very bad code, temporary solution, need to remove in the future
            List<string> buff = GetListFromString(text);
            bool noEqual = false;
            if (buff.Count == origDocument.Count)
            {
                for (int i = 0, j = buff.Count - 1; i <= j; i++, j--)
                    if (!buff[i].Equals(origDocument[i]) || !buff[j].Equals(origDocument[j]))
                    {
                        noEqual = true;
                        break;
                    }
            }
            else
            {
                noEqual = true;
            }

            if (!noEqual)
            {
                OnTextCommited(EventArgs.Empty);
                return;
            }
            currentDocument = buff;
            SDocumentEventArgs e = new();
            e.WholeTextWasChanged = true;
            OnTextChanged(e);
        }

        private bool TextWasChanged()
        {
            if (currentDocument.Count == origDocument.Count)
            {
                for (int i = 0, j = currentDocument.Count - 1; i <= j; i++, j--)
                    if (!currentDocument[i].Equals(origDocument[i]) || !currentDocument[j].Equals(origDocument[j]))
                    {
                        return true;
                    }

                return false;
            }

            return true;
        }

        public void Commit()
        {
            origDocument.Clear();
            origDocument.AddRange(currentDocument);
            oldEndOfLineType = endOfLineType;
            OnTextCommited(EventArgs.Empty);
        }

        public event EventHandler? TextChanged;
        public event EventHandler? TextCommited;
        
        protected virtual void OnTextChanged(SDocumentEventArgs e)
        {
            isChanged = true;
            TextChanged?.Invoke(this, e);
        }

        protected virtual void OnTextCommited(EventArgs e)
        {
            isChanged = false;
            TextCommited?.Invoke(this, e);
        }

    }

    public class SDocumentEventArgs : EventArgs
    {
        public int Line = -1;
        public bool WholeTextWasChanged = false;
        public bool SomethingWasChanged = true;
    }
}
