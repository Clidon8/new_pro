﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Project_whriteEntities : DbContext
    {
        public Project_whriteEntities()
            : base("name=Project_whriteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
