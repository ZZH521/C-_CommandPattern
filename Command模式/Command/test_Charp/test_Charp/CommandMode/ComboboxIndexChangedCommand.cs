using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test_Charp.CommandMode
{
    public class ComboboxIndexChangedCommand: Command
    {
        private ComboBox ctrl;
        private int newIndex;
        private int oldIndex;
        EventHandler eventhandler;

        public ComboboxIndexChangedCommand(ComboBox ctrl, int newIndex, int oldIndex, EventHandler eventhandler)
        {
            this.ctrl = ctrl;
            this.newIndex = newIndex;
            this.oldIndex = oldIndex;
            this.eventhandler = eventhandler;
        }

        public void execute()
        {
            ctrl.SelectedIndexChanged -= eventhandler;
            this.ctrl.SelectedIndex = newIndex;
            ctrl.SelectedIndexChanged += eventhandler;
        }

        public void undo()
        {
            ctrl.SelectedIndexChanged -= eventhandler;
            this.ctrl.SelectedIndex = oldIndex;
            ctrl.SelectedIndexChanged += eventhandler;
        }
    }
}
