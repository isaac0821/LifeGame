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
    public partial class frmCurrencyRate : Form
    {
        public frmCurrencyRate()
        {
            InitializeComponent();
        }

        List<string> CurrencyType = new List<string>();
        private void frmCurrencyRate_Load(object sender, EventArgs e)
        {
            foreach (CAccount account in G.glb.lstAccount)
            {
                if (!CurrencyType.Exists(o => o == account.Currency))
                {
                    CurrencyType.Add(account.Currency);
                }
            }
            foreach (string type in CurrencyType)
            {
                lsbCurrencyA.Items.Add(type);
                lsbCurrencyB.Items.Add(type);
            }
        }

        private void lsbCurrencyA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCurrencyA.SelectedItem != null)
            {
                lblCurrencyA.Text = lsbCurrencyA.SelectedItem.ToString();
            }
            else
            {
                lblCurrencyA.Text = "---";
            }
            if (lblCurrencyA.Text != "---" && lblCurrencyB.Text != "---")
            {
                if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == lblCurrencyA.Text && o.CurrencyB == lblCurrencyB.Text))
                {
                    txtRate.Text = G.glb.lstCurrencyRate.Find(o => o.CurrencyA == lblCurrencyA.Text && o.CurrencyB == lblCurrencyB.Text).Rate.ToString();
                }
                else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == lblCurrencyB.Text && o.CurrencyB == lblCurrencyA.Text))
                {
                    txtRate.Text = (1 / G.glb.lstCurrencyRate.Find(o => o.CurrencyA == lblCurrencyB.Text && o.CurrencyB == lblCurrencyA.Text).Rate).ToString();
                }
                else
                {
                    txtRate.Text = "???";
                }
            }
        }

        private void lsbCurrencyB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCurrencyB.SelectedItem != null)
            {
                lblCurrencyB.Text = lsbCurrencyB.SelectedItem.ToString();
            }
            else
            {
                lblCurrencyB.Text = "---";
            }
            if (lblCurrencyA.Text != "---" && lblCurrencyB.Text != "---")
            {
                if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == lblCurrencyA.Text && o.CurrencyB == lblCurrencyB.Text))
                {
                    txtRate.Text = G.glb.lstCurrencyRate.Find(o => o.CurrencyA == lblCurrencyA.Text && o.CurrencyB == lblCurrencyB.Text).Rate.ToString();
                }
                else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == lblCurrencyB.Text && o.CurrencyB == lblCurrencyA.Text))
                {
                    txtRate.Text = (1 / G.glb.lstCurrencyRate.Find(o => o.CurrencyA == lblCurrencyB.Text && o.CurrencyB == lblCurrencyA.Text).Rate).ToString();
                }
                else
                {
                    txtRate.Text = "???";
                }
            }
        }

        private void SaveCurrencyRate(string CurrencyA, string CurrencyB, double Rate)
        {
            if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == CurrencyA && o.CurrencyB == CurrencyB))
            {
                G.glb.lstCurrencyRate.Find(o => o.CurrencyA == CurrencyA && o.CurrencyB == CurrencyB).Rate = Convert.ToDouble(txtRate.Text);
            }
            else if (G.glb.lstCurrencyRate.Exists(o => o.CurrencyA == CurrencyB && o.CurrencyB == CurrencyA))
            {
                G.glb.lstCurrencyRate.Find(o => o.CurrencyA == CurrencyB && o.CurrencyB == CurrencyA).Rate = 1 / (Convert.ToDouble(txtRate.Text));
            }
            else
            {
                RCurrencyRate newCurrencyRate = new RCurrencyRate();
                newCurrencyRate.CurrencyA = CurrencyA;
                newCurrencyRate.CurrencyB = CurrencyB;
                newCurrencyRate.Rate = Rate;
                G.glb.lstCurrencyRate.Add(newCurrencyRate);
            }
        }

        private void frmCurrencyRate_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveCurrencyRate(lblCurrencyA.Text, lblCurrencyB.Text, Convert.ToDouble(txtRate.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Input valid exchange rate");
            }

        }
    }
}
