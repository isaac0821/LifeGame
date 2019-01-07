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
        /// 寻找一项task的所有子节点 Done: 01/06/2019
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
        /// 寻找一项task的所有子孙Task，各层级都要 Done: 01/06/2019
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <returns></returns>
        public List<string> FindAllHeirTask(string TaskName, List<RSubTask> rSubTasks)
        {
            List<string> ret = new List<string>();
            ret.Add(TaskName);
            List<string> collect = new List<string>();
            collect.Add(TaskName);
            bool IsExpandFinish = true;
            do
            {
                // 全部展开Flag置为完成
                IsExpandFinish = true;
                // 临时存放展开中间状态
                List<string> tmp = new List<string>();
                // 每次循环遍历ret现有元素是否都已经被展开完毕
                for (int i = 0; i < collect.Count; i++)
                {
                    // 如果某个元素未被展开
                    if (rSubTasks.Exists(o => o.Task == collect[i]))
                    {
                        // 索引出所有该task的subTask，代替该元素存入tmp
                        List<RSubTask> subs = rSubTasks.FindAll(o => o.Task == collect[i]).ToList();
                        subs = subs.OrderBy(o => o.index).ToList();
                        foreach (RSubTask subTask in subs)
                        {
                            tmp.Add(subTask.SubTask);
                            ret.Add(subTask.SubTask);
                        }
                        // 全部展开完毕的flag置为false
                        IsExpandFinish = false;
                    }
                }
                // 如果不是全部都展开完了，用tmp替代ret
                if (!IsExpandFinish)
                {
                    collect = tmp.ToList();
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


        /// <summary>
        /// 找到所有heir中未完成且未被放弃的任务中deadline最小的
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public DateTime FindNextTimeMarker(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            DateTime ret = new DateTime(9999, 12, 31);
            List<string> heirTasks = FindAllHeirTask(TaskName, rSubTasks);
            foreach (string heir in heirTasks)
            {
                if (G.glb.lstTask.Find(o=>o.TaskName == heir).DeadLine < ret
                    && G.glb.lstTask.Find(o => o.TaskName == heir).IsAbort == false
                    && G.glb.lstTask.Find(o => o.TaskName == heir).IsFinished == false)
                {
                    ret = G.glb.lstTask.Find(o => o.TaskName == heir).DeadLine;
                }
            }
            return ret;
        }

        /// <summary>
        /// 删除task，只有task及subtask都没有log记录的task能够被删除
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public bool DeleteTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks, List<CLog> logs, List<CLog> schedules)
        {
            bool CanDeleteFlag = true;
            List<string> bottomTask = FindAllBottomTask(TaskName, rSubTasks);
            foreach (string bottom in bottomTask)
            {
                if (logs.Exists(o => o.ContributionToTask == bottom))
                {
                    CanDeleteFlag = false;
                    break;
                }
                if (schedules.Exists(o => o.ContributionToTask == bottom))
                {
                    CanDeleteFlag = false;
                    break;
                }
            }

            if (CanDeleteFlag)
            {
                List<string> heirTask = FindAllHeirTask(TaskName, rSubTasks);
                foreach (string heir in heirTask)
                {
                    G.glb.lstSubTask.RemoveAll(o => o.SubTask == heir);
                    G.glb.lstTask.RemoveAll(o => o.TaskName == heir);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Can not delete a task with data related to it.");
            }

            return CanDeleteFlag;
        }

        /// <summary>
        /// 将一个task放弃执行
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void AbortTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            if (tasks.Exists(o=>o.TaskName==TaskName))
            {
                tasks.Find(o => o.TaskName == TaskName).IsAbort = true;
            }
            if (rSubTasks.Exists(o=>o.Task==TaskName))
            {
                List<RSubTask> subOfThisTask = rSubTasks.FindAll(o => o.Task == TaskName).ToList();
                foreach (RSubTask sub in subOfThisTask)
                {
                    if (tasks.Exists(o=>o.TaskName==sub.SubTask))
                    {
                        tasks.Find(o => o.TaskName == sub.SubTask).IsAbort = true;
                    }
                }
            }
        }

        /// <summary>
        /// 重新执行某个task
        /// </summary>
        /// <param name="TaskName"></param>
        /// <param name="rSubTasks"></param>
        /// <param name="tasks"></param>
        public void ReAssignTask(string TaskName, List<RSubTask> rSubTasks, List<CTask> tasks)
        {
            if (rSubTasks.Exists(o=>o.SubTask == TaskName))
            {
                string UpperTask = rSubTasks.Find(o => o.SubTask == TaskName).Task;
                if (UpperTask == "(Root)")
                {
                    tasks.Find(o => o.TaskName == TaskName).IsAbort = false;
                }
                else if (tasks.Exists(o=>o.TaskName==UpperTask))
                {
                    if (tasks.Find(o=>o.TaskName==UpperTask).IsAbort==false)
                    {
                        tasks.Find(o => o.TaskName == TaskName).IsAbort = false;
                    }
                }
            }
            if (rSubTasks.Exists(o => o.Task == TaskName))
            {
                List<RSubTask> subOfThisTask = rSubTasks.FindAll(o => o.Task == TaskName).ToList();
                foreach (RSubTask sub in subOfThisTask)
                {
                    if (tasks.Exists(o => o.TaskName == sub.SubTask))
                    {
                        tasks.Find(o => o.TaskName == sub.SubTask).IsAbort = false;
                    }
                }
            }
        }
    }
}
