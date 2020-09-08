
using FinalCaimanProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.DAL
{
    public class DbCaimanContext : DbContext
    {

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3ALO5CA\SQLEXPRESS01;Initial Catalog=DbCaiman;Integrated Security=True"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjetMember>()
                .HasKey(pm => new { pm.MemberId, pm.ProjetId });

            modelBuilder.Entity<ProjetMember>()
                .HasOne(m => m.Member)
                .WithMany(ma => ma.ProjetMembers)
                .HasForeignKey(m => m.MemberId);


            modelBuilder.Entity<ProjetMember>()
                 .HasOne(p => p.Projet)
                 .WithMany(ma => ma.ProjetMembers)
                 .HasForeignKey(p => p.ProjetId);



            modelBuilder.Entity<Specialite>()
                .HasMany(c => c.Members)
                .WithOne(e => e.SpecialiteMember);
            modelBuilder.Entity<Member>()
                .Ignore(x => x.SpecialiteMember);

            modelBuilder.Entity<Transport>()
                .HasMany(c => c.Members)
                .WithOne(e => e.TransportMember);
            modelBuilder.Entity<Member>()
                .Ignore(x => x.TransportMember);
        }
        public DbSet<Member> Members { get; set; }

        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Projet> Projets { get; set; }

        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProjetMember> ProjetMembers { get; set; }
        public DbSet<NoteP> NotePs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}