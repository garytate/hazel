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
        public frm_Main() => InitializeComponent();

        private void frm_Main_Load(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            Dictionary<string, DateTime> logs = fileManager.GetAllLogs(Directory.GetCurrentDirectory());
            PopulateTreeView(logs);
        }

        private void PopulateTreeView(Dictionary<string, DateTime> logs)
        {
            TreeView_LogList.BeginUpdate();
            // Firstly, we'll add the (years)
            foreach (var log in logs)
            {
                if (TreeView_LogList.Nodes.Find(log.Value.Year.ToString(), true).Length == 0)
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = log.Value.Year.ToString(); // The value displayed to the user.
                    rootNode.Name = log.Value.Year.ToString(); // What 'Find' will search for.
                    rootNode.Tag = log.Key; // The full file location, so we can grab data.
                    rootNode.Checked = true;
                    TreeView_LogList.Nodes.Add(rootNode);
                }                
            }

             // Secondly, we'll populate the months to the years.
            foreach (TreeNode node in TreeView_LogList.Nodes)
            {
                TreeNode test = new TreeNode();
                test.Text = "January"; // Of course we can use datetime or smth to work out the month names.
                node.Nodes.Add(test);
                foreach (var log in logs)
                {
                    test.Nodes.Add(log.Value.ToString());
                    
                    // You can add children/sub-children by grabbing a node
                    // and just doing node.Nodes.Add... 
                }

                /*
                Dictionary<string, DateTime> temp = logs;
                string file = Path.GetFileNameWithoutExtension(Path.GetFileName((string)node.Tag));
                DateTime nodeDate = DateTime.ParseExact(file, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                var test = temp.Where(d => d.Value.Year == nodeDate.Year && d.Value.Month == nodeDate.Month);

                foreach (var t in test)
                {
                    node.Nodes.Add(t.Value.ToString());
                }
                */
            }

            TreeView_LogList.ExpandAll();
            TreeView_LogList.EndUpdate();
        }
    }
}
