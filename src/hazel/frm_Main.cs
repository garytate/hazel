using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Hazel
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            List<string> logs = fileManager.GetAllLogs(Directory.GetCurrentDirectory());

            foreach (string log in logs)
            {
                logList.Nodes.Add(Path.ChangeExtension(Path.GetFileName(log), null));
            }
        }
    }
}
