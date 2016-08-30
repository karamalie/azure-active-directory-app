using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DdacAssignment.Models;

namespace DdacAssignment.DAL
{
    public class RoleClaimContext : DbContext
    {
        public RoleClaimContext() : base("RoleClaimContext") { }

        public DbSet<Task> Tasks { get; set; }
    }
}