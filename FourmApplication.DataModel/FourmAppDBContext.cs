using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.DataModel
{
    public class FourmAppDBContext : DbContext  
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }   
        public DbSet<Questions> Questions { get; set; } 
        public DbSet<Answers> Answers { get; set; } 
        public DbSet<Votes> Votes { get; set; }
    }
}
