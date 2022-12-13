using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SText.Conf
{
    public class FormEvents
    {
        private static FormEvents events = new FormEvents();
        public static FormEvents Events
        {
            get => events;
        }

        public delegate void FromTitleEventHandler(string title);

        public event FromTitleEventHandler FormTitleChanged;

        protected virtual void OnFormTitleChanged(string title)
        {
            FromTitleEventHandler handler = FormTitleChanged;
            handler?.Invoke(title);
        }

        public void NotifyFormTitleChanged(string title)
        {
            OnFormTitleChanged(title);
        }

        public delegate void FormPositionEventHandler(int x, int y);

        public event FormPositionEventHandler FormPositionChanged;

        protected virtual void OnFormPositionChanged(int x, int y)
        {
            FormPositionEventHandler handler = FormPositionChanged;
            handler?.Invoke(x, y);
        }

        public void NotifyFormPositionChanged(int x, int y)
        {
            OnFormPositionChanged(x, y);
        }

        public delegate void FormSizeEventHandler(int width, int height);

        public event FormSizeEventHandler FormSizeChanged;

        protected virtual void OnFormSizeChanged(int width, int height)
        {
            FormSizeEventHandler handler = FormSizeChanged;
            handler?.Invoke(width, height);
        }

        public void NotifyFormSizeChanged(int width, int height)
        {
            OnFormSizeChanged(width, height);
        }

        public delegate void FormClosingFromWPFEventHandler(object sender, System.ComponentModel.CancelEventArgs e);

        public event FormClosingFromWPFEventHandler FormClosingFromWPF;

        protected virtual void OnFormClosingFromWPF(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FormClosingFromWPFEventHandler handler = FormClosingFromWPF;
            handler?.Invoke(sender, e);
        }

        public void NotifyFormClosingFromWPF(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnFormClosingFromWPF(sender, e);
        }
    }
}
