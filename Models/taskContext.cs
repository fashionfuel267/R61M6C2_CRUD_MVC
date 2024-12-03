using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R61M6C2_w01.Models
{
    public class TaskContext:DbContext
    {
       
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}