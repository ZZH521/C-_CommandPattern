﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_Charp.CommandMode
{
    interface Command
    {
        void execute();
        void undo();
    }
}
