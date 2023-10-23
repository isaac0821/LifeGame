using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class frmCountDown : Form
    {
        public frmCountDown()
        {
            InitializeComponent();
        }

        int totalMins = 0;
        double remainMins = 0;
        Timer countDown = new Timer();

        private void frmMain_Load(object sender, EventArgs e)
        {
            countDown.Interval = 1000 * 15;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            txtTime.Text = "60";
            countDown.Tick += RefreshClock;
        }

        private void RefreshClock(object sender, EventArgs e)
        {
            remainMins -= 0.25;
            picBox.Controls.Clear();
            DrawClock(totalMins, remainMins);
        }

        private void DrawClock(int totalTime, double remainTime)
        {
            //this.TopMost = true;
            if (remainTime < 0)
            {
                countDown.Stop();
                txtTime.Enabled = true;
                btnStart.Enabled = true;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                totalMins = Convert.ToInt32(txtTime.Text);
                remainMins = Convert.ToInt32(txtTime.Text);
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Time's up!!");
            }
            else
            {

                // 先来个36 x 22的矩阵
                List<List<int>> m = new List<List<int>>();
                for (int i = 0; i < 36; i++)
                {
                    List<int> k = new List<int>();
                    for (int j = 0; j < 22; j++)
                    {
                        k.Add(0);
                    }
                    m.Add(k);
                }
                int numBlock = (int)(((double)remainTime / totalTime) * 36 * 22);

                // 双数组法
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                List<Tuple<int, int>> ints = new List<Tuple<int, int>>();
                for (int i = 0; i < 36; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                        ints.Add(new Tuple<int, int>(i, j));
                    }
                }
                for (int i = 0; i < numBlock; i++)
                {
                    int idx = rnd.Next(ints.Count);
                    Tuple<int, int> colored = ints[idx];
                    ints.RemoveAt(idx);
                    m[colored.Item1][colored.Item2] = 1;
                }

                for (int i = 0; i < m.Count; i++)
                {
                    for (int j = 0; j < m[i].Count; j++)
                    {
                        if (m[i][j] == 1)
                        {
                            PictureBox pixel = new PictureBox();
                            pixel.Width = 10;
                            pixel.Height = 10;
                            pixel.Left = i * 10;
                            pixel.Top = j * 10;
                            pixel.BackColor = Color.Blue;
                            picBox.Controls.Add(pixel);
                        }
                    }
                }

                lblRemain.Text = (Math.Ceiling(remainTime)).ToString() + " out of " + totalTime.ToString() + " mins left.";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblRemain.Text = remainMins.ToString() + " out of " + totalMins.ToString() + " mins left.";
            txtTime.Enabled = false;
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            countDown.Start();
            if (remainMins == totalMins)
            {
                for (int i = 0; i < 36; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                        PictureBox pixel = new PictureBox();
                        pixel.Width = 10;
                        pixel.Height = 10;
                        pixel.Left = i * 10;
                        pixel.Top = j * 10;
                        pixel.BackColor = Color.Blue;
                        picBox.Controls.Add(pixel);
                    }
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = true;
            countDown.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            txtTime.Enabled = true;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            txtTime.Text = "60";
            totalMins = Convert.ToInt32(txtTime.Text);
            remainMins = Convert.ToInt32(txtTime.Text);
            countDown.Stop();
            DrawClock(totalMins, remainMins);
            picBox.Controls.Clear();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            totalMins = Convert.ToInt32(txtTime.Text);
            remainMins = Convert.ToInt32(txtTime.Text);
            picBox.Controls.Clear();
        }
    }
}
