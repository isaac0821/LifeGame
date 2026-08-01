using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LifeGame
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 加载新格式数据
            try
            {
                DataStore.LoadGlobalData();
            }
            catch (Exception)
            {
                var result = MessageBox.Show(
                    "数据文件未找到，是否创建新的空白数据？",
                    "LifeGame", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    InitEmptyData();
                }
                else
                {
                    return;
                }
            }

            // 确保所有 SysNote 存在
            frmLauncher.EnsureSysNotesExist();

            // 启动 Launcher
            var launcher = new frmLauncher();
            Application.Run(launcher);
        }

        private static void InitEmptyData()
        {
            DataFileHelper.EnsureDirectories();

            G.glb.lstNote = new List<NoteDocument>();
            G.glb.lstLiterature = new List<LiteratureDocument>();
            G.glb.lstLiteratureReview = new List<LiteratureReviewDocument>();
            G.glb.lstDiary = new List<DiaryDocument>();
            G.glb.lstConfig = new List<CConfigEntry>();

            DataStore.SaveNoteIndex();
            DataStore.SaveLiteratureIndex();
            DataStore.SaveLiteratureReviewIndex();
            DataStore.SaveDiaryIndex();
        }
    }
}
