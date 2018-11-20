using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetMeetup.Blazor.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meetup> Meetups { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>().HasKey(x => new { x.MeetupId, x.UserId });
        }
    }
}