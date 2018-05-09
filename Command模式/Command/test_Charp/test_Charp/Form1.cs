using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMSkin.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Xml;
using test_Charp.CommandMode;

namespace test_Charp
{
    public partial class Form1 : Form
    {
        Stack<Command> undoStack = new Stack<Command>();
        Stack<Command> redoStack = new Stack<Command>();

        String oldStr;
        Boolean flag = true;

         public Form1()
         {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
         }    
         
         private void button1_Click(object sender, EventArgs e) //撤销
         {
             if (undoStack.Count == 0)
                 return;

             flag = false;

             Command com = undoStack.Pop();
             com.undo();
             redoStack.Push(com);
         }

         private void button2_Click(object sender, EventArgs e) //恢复
         {
             if (redoStack.Count == 0)
                 return;

             flag = false;

             Command com = redoStack.Pop();
             com.execute();

             undoStack.Push(com);
         }

         private void textBox1_TextChanged(object sender, EventArgs e)
         {
             if (flag)
             {
                 TextChangedCommand com = new TextChangedCommand((TextBox)textBox1, ((TextBox)textBox1).Text, oldStr);
                 undoStack.Push(com);
                 oldStr = ((TextBox)textBox1).Text;
             }             

             flag = true;
         }

         private void Form1_Load(object sender, EventArgs e)
         {

         }        
    }
}
