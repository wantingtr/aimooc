using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using aimooc.Domain;

namespace aimooc.Data
{
    public class AIMoocDataContext : DbContext
    {
        public DbSet<CourseType> CourseTypes {get;set;}
        public DbSet<Course> Courses {get;set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
			  .UseMySql(@"Server=cdb-0neq2m83.gz.tencentcdb.com;database=aimooc;port=10074;uid=root;pwd=xchedu@2018;");


		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(p => p.CourseTypeInfo)
                .WithMany(b => b.CourseList);
        }


		public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception db)
            {
				Console.WriteLine(db.ToString());

                throw;  // You can also choose to handle the exception here...
            }


        }

    }
}