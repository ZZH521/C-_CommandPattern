using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test_Charp.CommandMode
{
    public class TextChangedCommand: Command
    {
        private TextBox ctrl;
        private String newStr;
        private String oldStr;

        public TextChangedCommand(TextBox ctrl, String newStr, String oldStr)
        {
            this.ctrl = ctrl;
            this.newStr = newStr;
            this.oldStr = oldStr;
        }

        public void execute()
        {
            this.ctrl.Text = newStr;
            this.ctrl.SelectionStart = this.ctrl.Text.Length;
        }

        public void undo()
        {
            this.ctrl.Text = oldStr;
            this.ctrl.SelectionStart = this.ctrl.Text.Length;
        }
    }
}
