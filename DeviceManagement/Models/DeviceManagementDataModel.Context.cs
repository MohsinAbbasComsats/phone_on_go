﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeviceManagementDBContext : DbContext
    {
        public DeviceManagementDBContext()
            : base("name=DeviceManagementDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<calllogs> calllogs { get; set; }
        public virtual DbSet<calllogtype> calllogtypes { get; set; }
        public virtual DbSet<device> devices { get; set; }
        public virtual DbSet<sms> sms { get; set; }
        public virtual DbSet<smstype> smstypes { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<services> services { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
    }
}