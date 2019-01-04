using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class CalAndFind
    {
        /// <summary>
        /// 寻找一项task的所有子节点
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <returns></returns>
        public List<string> FindAllBottomTask(string TaskName, List<RSubTask> rSubTasks)
        {
            List<string> ret = new List<string>();
            ret.Add(TaskName);
            bool IsExpandFinish = true;
            do
            {
                // 全部展开Flag置为完成
                IsExpandFinish = true;
                // 临时存放展开中间状态
                List<string> tmp = new List<string>();
                // 每次循环遍历ret现有元素是否都已经被展开完毕
                for (int i = 0; i < ret.Count; i++)
                {
                    // 如果某个元素未被展开
                    if (rSubTasks.Exists(o => o.Task == ret[i]))
                    {
                        // 索引出所有该task的subTask，代替该元素存入tmp
                        List<RSubTask> subs = rSubTasks.FindAll(o => o.Task == ret[i]).ToList();
                        subs = subs.OrderBy(o => o.index).ToList();
                        foreach (RSubTask subTask in subs)
                        {
                            tmp.Add(subTask.SubTask);
                        }
                        // 全部展开完毕的flag置为false
                        IsExpandFinish = false;
                    }
                    // 如果某个元素已经被展开，保留进入tmp中间状态
                    else
                    {
                        tmp.Add(ret[i]);
                    }
                }
                // 如果不是全部都展开完了，用tmp替代ret
                if (!IsExpandFinish)
                {
                    ret = tmp.ToList();
                }
            } while (!IsExpandFinish);
            return ret;
        }

        /// <summary>
        /// 返回task累计花费时间
        /// </summary>
        /// <param name="TaskName">任务名</param>
        /// <param name="rSubTasks">任务关系列表</param>
        /// <param name="logs">日志列表</param>
        /// <returns></returns>
        public double CalTimeSpentInTask(string TaskName, List<RSubTask> rSubTasks, List<CLog> logs)
        {
            List<string> subTasks = FindAllBottomTask(TaskName, rSubTasks);
            double ret = 0;
            foreach (string subTask in subTasks)
            {
                List<CLog> logForSubTask = logs.FindAll(o => o.ContributionToTask == subTask).ToList();
                foreach (CLog log in logForSubTask)
                {
                    TimeSpan timeSpan = log.EndTime - log.StartTime;
                    ret += timeSpan.TotalHours;
                }
            }
            return ret;
        }

        public DateTime FindNextTimeMarker(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            DateTime ret = new DateTime(2019, 1, 1);
            
            return ret;
        }
    }
}
