using System;
using System.Collections.Generic;

namespace LifeGame
{
    /// <summary>Node metadata type</summary>
    public enum NodeMetaType
    {
        None,
        Link,        // $LINK$>
        Literature,  // $LITR$>
        NoteRef,     // $NOTE$>
        Jump,        // $JUMP$>
        Schedule,    // $SCHL$>
        Task,        // $TASK$>
        Deadline,    // $DDLI$> / Date: / date:
        Progress,    // [XX%]
        FuncRef,     // $FUNC$>
        LiteratureTag, // $LTAG$>
        LiteratureReview, // $LREV$>,
    }

    /// <summary>A single row of data in the outline editor</summary>

    public class OutlineLine
    {
        /// <summary>Indentation level (0 = root node)</summary>
        public int Level;

        /// <summary>Plain text content (without prefix markers)</summary>
        public string Text;

        /// <summary>Unique identifier</summary>
        public string GUID;

        /// <summary>Parent node GUID</summary>
        public string ParentGUID;

        /// <summary>Whether child nodes are expanded</summary>
        public bool Expanded;

        /// <summary>Node metadata type</summary>
        public NodeMetaType MetaType;

        /// <summary>Metadata value (link URL / literature title / Note reference / DDL date)</summary>
        public string MetaValue;

        /// <summary>Label keywords list, e.g. ["Red", "Important"]</summary>
        public List<string> LabelKeywords = new List<string>();

        /// <summary>Progress percentage (0-100), 0 means no progress</summary>
        public int ProgressPercent;

        /// <summary>Sort order</summary>
        public int Ordering;

        /// <summary>Marked as Meta node (cannot be moved/deleted, not persisted to body)</summary>
        public bool IsMetaNode;

        /// <summary>Whether this is a Meta section header node (e.g. Label color / Publisher / Authorship), not editable</summary>
        public bool IsMetaSectionHeader;

        /// <summary>Whether adding child nodes is allowed (only some Meta header nodes allow this)</summary>
        public bool AllowAddChild;

        /// <summary>Format constraint regex (used for child node edit validation), e.g. @"^.+:.+$"</summary>
        public string EditFormatRegex;

        /// <summary>Format constraint description, e.g. "Format: TagName: ColorName"</summary>
        public string EditFormatHint;

        public OutlineLine()
        {
            GUID = Guid.NewGuid().ToString();
            Expanded = true;
        }

        public OutlineLine Clone()
        {
            return new OutlineLine
            {
                Level = this.Level,
                Text = this.Text,
                GUID = this.GUID,
                ParentGUID = this.ParentGUID,
                Expanded = this.Expanded,
                MetaType = this.MetaType,
                MetaValue = this.MetaValue,
                LabelKeywords = new List<string>(this.LabelKeywords ?? new List<string>()),
                ProgressPercent = this.ProgressPercent,
                Ordering = this.Ordering,
                IsMetaNode = this.IsMetaNode,
                IsMetaSectionHeader = this.IsMetaSectionHeader,
                AllowAddChild = this.AllowAddChild,
                EditFormatRegex = this.EditFormatRegex,
                EditFormatHint = this.EditFormatHint
            };
        }
    }
}
