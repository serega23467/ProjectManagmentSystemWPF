using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class DataGridUser
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Password { get; set; }
    }
}
