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
    }
}
