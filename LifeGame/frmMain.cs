using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeGame
{
    public partial class frmMain : Form
    {
        private DateTime SelectedDate;
        private DateTime SelectedMonday;
        private DateTime SelectedTuesday;
        private DateTime SelectedWednesday;
        private DateTime SelectedThursday;
        private DateTime SelectedFriday;
        private DateTime SelectedSaturday;
        private DateTime SelectedSunday;

        private void SerializeNow()
        {
            FileStream f = new FileStream("data.dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, G.glb);
            f.Close();
        }
        private void Deserialize()
        {
            FileStream f = new FileStream("data.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            G.glb.lstTask.Clear();
            G.glb = b.Deserialize(f) as Mem;
            f.Close();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Deserialize();
            SelectedDate = DateTime.Today.Date;
            dtpDate.Value = SelectedDate;
            DrawLog();

            G.glb.lstEvent.Clear();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            DrawLog();
        }

        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Wanna save?", "Saving", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    SerializeNow();
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = false;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void taskTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTask frmTask = new frmTask();
            frmTask.Show();
        }

        private void moneyMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDate = dtpDate.Value.Date;
            switch (SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    SelectedMonday = SelectedDate.Date.AddDays(-6);
                    SelectedTuesday = SelectedDate.Date.AddDays(-5);
                    SelectedWednesday = SelectedDate.Date.AddDays(-4);
                    SelectedThursday = SelectedDate.Date.AddDays(-3);
                    SelectedFriday = SelectedDate.Date.AddDays(-2);
                    SelectedSaturday = SelectedDate.Date.AddDays(-1);
                    SelectedSunday = SelectedDate.Date.AddDays(0);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Monday:
                    SelectedMonday = SelectedDate.Date.AddDays(0);
                    SelectedTuesday = SelectedDate.Date.AddDays(1);
                    SelectedWednesday = SelectedDate.Date.AddDays(2);
                    SelectedThursday = SelectedDate.Date.AddDays(3);
                    SelectedFriday = SelectedDate.Date.AddDays(4);
                    SelectedSaturday = SelectedDate.Date.AddDays(5);
                    SelectedSunday = SelectedDate.Date.AddDays(6);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Tuesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-1);
                    SelectedTuesday = SelectedDate.Date.AddDays(0);
                    SelectedWednesday = SelectedDate.Date.AddDays(1);
                    SelectedThursday = SelectedDate.Date.AddDays(2);
                    SelectedFriday = SelectedDate.Date.AddDays(3);
                    SelectedSaturday = SelectedDate.Date.AddDays(4);
                    SelectedSunday = SelectedDate.Date.AddDays(5);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Wednesday:
                    SelectedMonday = SelectedDate.Date.AddDays(-2);
                    SelectedTuesday = SelectedDate.Date.AddDays(-1);
                    SelectedWednesday = SelectedDate.Date.AddDays(0);
                    SelectedThursday = SelectedDate.Date.AddDays(1);
                    SelectedFriday = SelectedDate.Date.AddDays(2);
                    SelectedSaturday = SelectedDate.Date.AddDays(3);
                    SelectedSunday = SelectedDate.Date.AddDays(4);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Thursday:
                    SelectedMonday = SelectedDate.Date.AddDays(-3);
                    SelectedTuesday = SelectedDate.Date.AddDays(-2);
                    SelectedWednesday = SelectedDate.Date.AddDays(-1);
                    SelectedThursday = SelectedDate.Date.AddDays(0);
                    SelectedFriday = SelectedDate.Date.AddDays(1);
                    SelectedSaturday = SelectedDate.Date.AddDays(2);
                    SelectedSunday = SelectedDate.Date.AddDays(3);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Friday:
                    SelectedMonday = SelectedDate.Date.AddDays(-4);
                    SelectedTuesday = SelectedDate.Date.AddDays(-3);
                    SelectedWednesday = SelectedDate.Date.AddDays(-2);
                    SelectedThursday = SelectedDate.Date.AddDays(-1);
                    SelectedFriday = SelectedDate.Date.AddDays(0);
                    SelectedSaturday = SelectedDate.Date.AddDays(1);
                    SelectedSunday = SelectedDate.Date.AddDays(2);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                case DayOfWeek.Saturday:
                    SelectedMonday = SelectedDate.Date.AddDays(-5);
                    SelectedTuesday = SelectedDate.Date.AddDays(-4);
                    SelectedWednesday = SelectedDate.Date.AddDays(-3);
                    SelectedThursday = SelectedDate.Date.AddDays(-2);
                    SelectedFriday = SelectedDate.Date.AddDays(-1);
                    SelectedSaturday = SelectedDate.Date.AddDays(0);
                    SelectedSunday = SelectedDate.Date.AddDays(1);
                    lblMonday.Text = SelectedMonday.ToLongDateString();
                    lblTuesday.Text = SelectedTuesday.ToLongDateString();
                    lblWednesday.Text = SelectedWednesday.ToLongDateString();
                    lblThursday.Text = SelectedThursday.ToLongDateString();
                    lblFriday.Text = SelectedFriday.ToLongDateString();
                    lblSaturday.Text = SelectedSaturday.ToLongDateString();
                    lblSunday.Text = SelectedSunday.ToLongDateString();
                    break;
                default:
                    break;
            }
            DrawLog();
        }
        private void btnPreDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-7);
        }
        private void btnNextDate_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(7);
        }

        private string SelectedPicName = "";
        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            SelectedPicName = (sender as ContextMenuStrip).SourceControl.Name;
            // MessageBox.Show(SelectedPicName);
        }
        private void tsmAddSleepSchedule_Click(object sender, EventArgs e)
        {
            frmAddSleepSchedule frmAddScheduleSleep = new frmAddSleepSchedule();
            frmAddScheduleSleep.DrawLog += new frmAddSleepSchedule.DrawLogHandler(DrawLog);
            frmAddScheduleSleep.Show();
        }

        private void tsmAddSleepLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThr":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddSleepLog frmAddLogSleep = new frmAddSleepLog(sendToFrm);
            frmAddLogSleep.DrawLog += new frmAddSleepLog.DrawLogHandler(DrawLog);
            frmAddLogSleep.Show();
        }

        private void tsmAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.DrawLog += new frmAddSchedule.DrawLogHandler(DrawLog);
            frmAddSchedule.Show();
        }

        private void tsmAddLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThr":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmAddLog frmAddLog = new frmAddLog(sendToFrm);
            frmAddLog.DrawLog += new frmAddLog.DrawLogHandler(DrawLog);
            frmAddLog.Show();
        }

        private void tsmDeleteSchedule_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThr":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelLog frmDelLog = new frmDelLog(sendToFrm, false);
            frmDelLog.DrawLog += new frmDelLog.DrawLogHandler(DrawLog);
            frmDelLog.Show();
        }

        private void tsmDeleteLog_Click(object sender, EventArgs e)
        {
            DateTime sendToFrm = SelectedDate;
            switch (SelectedPicName)
            {
                case "picMon":
                    sendToFrm = SelectedMonday;
                    break;
                case "picTue":
                    sendToFrm = SelectedTuesday;
                    break;
                case "picWed":
                    sendToFrm = SelectedWednesday;
                    break;
                case "picThr":
                    sendToFrm = SelectedThursday;
                    break;
                case "picFri":
                    sendToFrm = SelectedFriday;
                    break;
                case "picSat":
                    sendToFrm = SelectedSaturday;
                    break;
                case "picSun":
                    sendToFrm = SelectedSunday;
                    break;
                default:
                    break;
            }
            frmDelLog frmDelLog = new frmDelLog(sendToFrm, true);
            frmDelLog.DrawLog += new frmDelLog.DrawLogHandler(DrawLog);
            frmDelLog.Show();
        }

        private void picMon_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedMonday;
            dtpDate.Value = SelectedDate;
        }
        private void picTue_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedTuesday;
            dtpDate.Value = SelectedDate;
        }
        private void picWed_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedWednesday;
            dtpDate.Value = SelectedDate;
        }
        private void picThu_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedThursday;
            dtpDate.Value = SelectedDate;
        }
        private void picFri_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedFriday;
            dtpDate.Value = SelectedDate;
        }
        private void picSat_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSaturday;
            dtpDate.Value = SelectedDate;
        }
        private void picSun_Click(object sender, EventArgs e)
        {
            SelectedDate = SelectedSunday;
            dtpDate.Value = SelectedDate;
        }

        private void LoadLblDaily(Label lbl, DateTime date)
        {
            lbl.Text = "";
            string whole = "";
            List<CTask> taskDeadline = G.glb.lstTask.FindAll(o => o.DeadLine.Date == date.Date).ToList();
            foreach (CTask task in taskDeadline)
            {
                whole += "Deadline: " + task.TaskName + "\n";
            }
            if (taskDeadline.Count > 0)
            {
                whole = whole.Substring(0, whole.Length - 1);
            }
            lbl.Text = whole;
        }

        private void DrawLog()
        {
            Draw Draw = new Draw();
            LoadLblDaily(lblDDLMon, SelectedMonday);
            LoadLblDaily(lblDDLTue, SelectedTuesday);
            LoadLblDaily(lblDDLWed, SelectedWednesday);
            LoadLblDaily(lblDDLThu, SelectedThursday);
            LoadLblDaily(lblDDLFri, SelectedFriday);
            LoadLblDaily(lblDDLSat, SelectedSaturday);
            LoadLblDaily(lblDDLSun, SelectedSunday);

            picMon.Controls.Clear();
            picTue.Controls.Clear();
            picWed.Controls.Clear();
            picThu.Controls.Clear();
            picFri.Controls.Clear();
            picSat.Controls.Clear();
            picSun.Controls.Clear();

            if (chkShowSchedule.Checked && chkShowLog.Checked & chkMoney.Checked)
            {
                DrawScheduleWithMode("leftWithSupp");
                DrawLogWithMode("rightWithSupp");
                DrawEvent();
            }
            else if (chkShowSchedule.Checked && chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawScheduleWithMode("left");
                DrawLogWithMode("right");
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & chkMoney.Checked)
            {
                DrawScheduleWithMode("allWithSupp");
                DrawEvent();
            }
            else if (chkShowSchedule.Checked && !chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawScheduleWithMode("all");
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & chkMoney.Checked)
            {
                DrawLogWithMode("allWithSupp");
                DrawEvent();
            }
            else if (!chkShowSchedule.Checked && chkShowLog.Checked & !chkMoney.Checked)
            {
                DrawLogWithMode("all");
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & chkMoney.Checked)
            {
                DrawEvent();
            }
            else if (!chkShowSchedule.Checked && !chkShowLog.Checked & !chkMoney.Checked)
            {

            }
        }

        private void DrawLogWithMode(string Mode)
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLogController(picMon, SelectedMonday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picTue, SelectedTuesday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picWed, SelectedWednesday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picThu, SelectedThursday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picFri, SelectedFriday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picSat, SelectedSaturday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
            Draw.DrawScheduleAndLogController(picSun, SelectedSunday, G.glb.lstLog, G.glb.lstSleepLog, Mode);
        }

        private void DrawScheduleWithMode(string Mode)
        {
            Draw Draw = new Draw();
            Draw.DrawScheduleAndLogController(picMon, SelectedMonday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picTue, SelectedTuesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picWed, SelectedWednesday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picThu, SelectedThursday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picFri, SelectedFriday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSat, SelectedSaturday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
            Draw.DrawScheduleAndLogController(picSun, SelectedSunday, G.glb.lstSchedule, G.glb.lstSleepSchedule, Mode);
        }

        private void DrawEvent()
        {
            Draw Draw = new Draw();
            Draw.DrawEventController(picMon, SelectedMonday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picTue, SelectedTuesday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picWed, SelectedWednesday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picThu, SelectedThursday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picFri, SelectedFriday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picSat, SelectedSaturday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
            Draw.DrawEventController(picSun, SelectedSunday, G.glb.lstEvent, G.glb.lstWorkOut, G.glb.lstLiteratureLog, G.glb.lstMedicine, G.glb.lstTransaction, G.glb.lstTransactionDue, G.glb.lstMeeting);
        }

        private void lblDDLMon_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLMon.Text);
        }
        private void lblDDLTue_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLTue.Text);
        }
        private void lblDDLWed_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLWed.Text);
        }
        private void lblDDLThu_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLThu.Text);
        }
        private void lblDDLFri_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLFri.Text);
        }
        private void lblDDLSat_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLSat.Text);
        }
        private void lblDDLSun_Click(object sender, EventArgs e)
        {
            Draw D = new Draw();
            D.CallDDLInfo(lblDDLSun.Text);
        }

        private void chkShowSchedule_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }
        private void chkShowLog_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }
        private void chkMoney_CheckedChanged(object sender, EventArgs e)
        {
            DrawLog();
        }

        private void literatureLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLiterature frmLiterature = new frmLiterature();
            frmLiterature.Show();
        }


    }
}
