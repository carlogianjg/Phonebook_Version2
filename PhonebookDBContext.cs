using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OJT_012022_Activity1_Ver2
{
    public partial class PhonebookDBContext : DbContext
    {
        public PhonebookDBContext()
        {
        }


        public  DbSet<ListOfContacts> ListOfContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhonebookDB;");
            }
        }

        
    }
}
