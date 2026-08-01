using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LifeGame
{
    public static class M
    {
        public static TempMemory mem = new TempMemory();
        // 单例模式的窗口
        public static List<Form> notesOpened = new List<Form>();
        public static List<string> shownLits = new List<string>();
        public static List<string> tempLitsA = new List<string>();
        public static List<string> tempLitsB = new List<string>();

        /// <summary>从 notesOpened 中查找匹配 GUID 的窗口</summary>
        public static Form FindNoteForm(string guid)
        {
            foreach (var f in notesOpened)
            {
                if (f is frmInfoNoteV2 v && v.GUID == guid) return v;
            }
            return null;
        }

        /// <summary>检查 GUID 对应的 Note 窗口是否已打开</summary>
        public static bool NoteExists(string guid) => FindNoteForm(guid) != null;

        /// <summary>从 Form 提取 GUID</summary>
        public static string GetNoteFormGUID(Form f)
        {
            if (f is frmInfoNoteV2 v) return v.GUID;
            return null;
        }

        /// <summary>移除指定 GUID 的窗口</summary>
        public static void RemoveNoteForm(string guid) =>
            notesOpened.RemoveAll(o => GetNoteFormGUID(o) == guid);
    }

    public class TempMemory
    {
        public List<copiedNodeStruct> copiedNodes = new List<copiedNodeStruct>();
    }

    public struct copiedNodeStruct
    {
        public string nodeText;
        public string nodeGUID;
        public string nodeParentGUID;

        public copiedNodeStruct(string nodeText, string nodeGUID, string nodeParentGUID)
        {
            this.nodeText = nodeText;
            this.nodeGUID = nodeGUID;
            this.nodeParentGUID = nodeParentGUID;
        }
    }

}
