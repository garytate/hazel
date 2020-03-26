using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hazel_V2
{
    public partial class frm_SplashScreen : Form
    {
        public frm_SplashScreen()
        {
            InitializeComponent();
            this.BackColor = Color.Blue;
            this.TransparencyKey = this.BackColor;

            // We can initialize anything prior to moving onto the actual application.
            // E.g. Pre-load data.
            timer1.Start();
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }

        private void TimerTick(object sender, EventArgs e)
        {
            if (blueProgressBar1.Value != 100)
            {
                blueProgressBar1.Value += 5;
            }
            else
            {
                timer1.Stop();
                frm_Main Main = new frm_Main();
                this.Hide();
                Main.ShowDialog();
                this.Close();
            }

        }
    }
}
