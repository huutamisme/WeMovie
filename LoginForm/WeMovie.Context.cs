﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginForm
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeMovieEntities : DbContext
    {
        public WeMovieEntities()
            : base("name=WeMovieEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Film_Actor> Film_Actor { get; set; }
        public virtual DbSet<Film_Director> Film_Director { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Showtime> Showtimes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
    }
}
