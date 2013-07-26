using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

                BasicCbroAlgorithm algorithm = new BasicCbroAlgorithm(visualizerSurface1.Tasks, (int) nudColonySize.Value);
                algorithm.Alpha = (double) nudAlpha.Value;
                algorithm.Beta = (double) nudBeta.Value;
                algorithm.Rho = (double) nudRho.Value;
                algorithm.Q = (double) nudQ.Value;

                algorithm.Run();

                visualizerSurface1.Path = algorithm.BestSolution;
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
