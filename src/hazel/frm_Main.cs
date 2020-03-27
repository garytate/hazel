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
using System.Globalization;

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
            List<TreeNode> years = new List<TreeNode>();

            foreach (string log in logs)
            {
                string file = Path.GetFileNameWithoutExtension(Path.GetFileName(log));
                DateTime date = DateTime.ParseExact(file, "dd-mm-yyyy", CultureInfo.InvariantCulture);

                if (!years.Any(node => Int32.Parse(node.Text) == date.Year))
                {
                    years.Add(new TreeNode(date.Year.ToString()));
                    logList.Nodes.Add(years.Last());
                }

            }
            foreach (TreeNode node in logList.Nodes)
            {
                Debug.WriteLine(node);
            }

        }
    }
}
