using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class TaskEmployer
    {
        [Key]
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int TaskId { get; set; }
    }
}
