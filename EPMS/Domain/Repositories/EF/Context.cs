using EPMS.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EPMS.Domain.Repositories.EF
{
    public class Context : DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }

        public Context(string connectionString): base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
