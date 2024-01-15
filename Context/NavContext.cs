using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using API.Models;

namespace API.Context
{
    public class NavContext: DbContext
    {
        public NavContext(DbContextOptions<NavContext> options) : base(options) { }
       // public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}