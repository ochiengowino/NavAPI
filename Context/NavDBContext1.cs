using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
//using API.Models;

namespace API.Context
{
    public class NavDBContext1 : DbContext
    {
        public NavDBContext1(DbContextOptions<NavDBContext1> options) : base(options) { }
        //public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}