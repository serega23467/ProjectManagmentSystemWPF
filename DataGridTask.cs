using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class DataGridTask : ProjectTask
    {
        public string Employees { get; set; }
        public string PriorityString { get; set; }
        public string ProjectName { get; set; }
        public char IsCompleted { set; get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID " + base.Id + ";");
            sb.Append("Project " + ProjectName + ";");
            sb.Append("Name " + base.Name + ";");
            sb.Append("Priority " + PriorityString + ";");
            sb.Append("Info " + base.Info + ";");
            sb.Append("Deadline " + base.Deadline + ";");
            sb.Append("Completed " + IsCompleted + ";");
            sb.Append("Employees " + Employees + ";");
            return sb.ToString();
        }
    }
}
