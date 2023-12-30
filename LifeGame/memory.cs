using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public static class M
    {
        public static TempMemory mem = new TempMemory();
        public static List<frmInfoNote> notesOpened = new List<frmInfoNote>();
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
