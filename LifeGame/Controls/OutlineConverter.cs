using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeGame
{
    /// <summary>OutlineLine 层级计算与树排序工具</summary>
    public static class OutlineConverter
    {
        #region 层级计算

        /// <summary>重新计算所有行的 Level</summary>
        public static void ComputeLevels(List<OutlineLine> lines)
        {
            // 使用字典缓存每个节点的 Level
            var levelCache = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                line.Level = GetLevel(line, lines, levelCache);
            }
        }

        private static int GetLevel(OutlineLine line, List<OutlineLine> allLines, Dictionary<string, int> cache)
        {
            if (cache.ContainsKey(line.GUID))
                return cache[line.GUID];

            if (string.IsNullOrEmpty(line.ParentGUID))
            {
                cache[line.GUID] = 0;
                return 0;
            }

            var parent = allLines.Find(l => l.GUID == line.ParentGUID);
            if (parent == null)
            {
                cache[line.GUID] = 0;
                return 0;
            }

            int level = GetLevel(parent, allLines, cache) + 1;
            cache[line.GUID] = level;
            return level;
        }

        /// <summary>按树结构深度优先排序</summary>
        public static List<OutlineLine> OrderByTree(List<OutlineLine> lines)
        {
            var result = new List<OutlineLine>();
            var roots = lines.Where(l => string.IsNullOrEmpty(l.ParentGUID)
                || !lines.Any(x => x.GUID == l.ParentGUID))
                .OrderBy(l => l.Ordering).ToList();

            foreach (var root in roots)
                AddChildren(root, lines, result);

            return result;
        }

        private static void AddChildren(OutlineLine parent, List<OutlineLine> allLines, List<OutlineLine> result)
        {
            result.Add(parent);
            var children = allLines.Where(l => l.ParentGUID == parent.GUID)
                .OrderBy(l => l.Ordering).ToList();
            foreach (var child in children)
                AddChildren(child, allLines, result);
        }

        #endregion
    }
}
