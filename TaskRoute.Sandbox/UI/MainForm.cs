using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libWyvernzora.Utilities;
using TaskRoute.Sandbox.Algorithm;
using System.Diagnostics;

namespace TaskRoute.Sandbox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRunAlg_Click(object sender, EventArgs e)
        {
            try
            {
                var algorithm = new BasicCbroAlgorithm(visualizerSurface1.Tasks, (int) nudColonySize.Value)
                {
                    Alpha = (double) nudAlpha.Value,
                    Beta = (double) nudBeta.Value,
                    Rho = (double) nudRho.Value,
                    Q = (double) nudQ.Value
                };


                algorithm.Run();

                visualizerSurface1.Path =  (from t in algorithm.BestSolution select t.Data).ToList();
                visualizerSurface1.UpdateSurface();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            visualizerSurface1.Tasks.Clear();
            visualizerSurface1.Path.Clear();
            visualizerSurface1.SelectedTask = null;

            visualizerSurface1.UpdateSurface();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }
    }
}
