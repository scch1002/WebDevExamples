using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.Generics
{
    public class TaskList<T> : List<T> where T : IProcessTask
    {
        public bool PerformListTasks()
        {
            foreach (var task in this)
            {
                try
                {
                    if (!task.ProcessTask())
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            } 
            
            return true;
        }        
    }
}