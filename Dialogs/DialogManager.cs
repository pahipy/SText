using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SText.Conf;

namespace SText.Dialogs
{
    public class DialogManager
    {
        public static void ItCantDoItShow()
        {
            MessageBox.Show($"{ProgramSets.ProgramName} can't do it!", ProgramSets.ProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowDialogWithText(string text)
        {
            MessageBox.Show(text, ProgramSets.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarningDialogWithText(string text)
        {
            MessageBox.Show(text, ProgramSets.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
