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
            visualizerSurface1.SelectionChanged += (@s, e) =>
            {
                var dp = visualizerSurface1.SelectedTask;
                if (dp == null)
                {
                    lblId.Text = "N/A";
                    lblValue.Text = "N/A";
                }
                else
                {
                    lblId.Text = visualizerSurface1.Path.Count == 0 ? "N/A" : dp.Id.ToString();
                    lblValue.Text = Math.Round(dp.Profit, 4).ToString();
                }
            };
        }

        #region Utility Methods

        private void ClearData()
        {
            visualizerSurface1.Tasks.Clear();
            visualizerSurface1.Path.Clear();
            visualizerSurface1.SelectedTask = null;

            visualizerSurface1.UpdateSurface();
        }

        #endregion

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

                var sw = new Stopwatch();
                using (new ActionLock(sw.Start, sw.Stop))
                {
                    algorithm.Run();
                }

                visualizerSurface1.Path =  (from t in algorithm.BestSolution select t.Data).ToList();
                visualizerSurface1.UpdateSurface();

                lblTime.Text = String.Format("{0}ms", sw.ElapsedMilliseconds);
                lblCost.Text = Math.Round(algorithm.BestCost, 4).ToString();
                lblProfit.Text = Math.Round(algorithm.BestProfit, 4).ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void createRandomDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData();
            var rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                DataPoint dp = new DataPoint()
                {
                    Profit = 1.0,
                    Location = new Location(rand.NextDouble(), rand.NextDouble())
                };
                visualizerSurface1.Tasks.Add(dp);
            }

            visualizerSurface1.UpdateSurface();
        }
    }
}
