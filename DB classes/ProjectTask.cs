using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Deadline { get; set; }
        public bool Completed { get; set; }
    }
}
