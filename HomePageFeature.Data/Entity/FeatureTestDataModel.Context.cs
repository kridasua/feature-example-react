﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomePageFeature.Data.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FeatureTestEntities : DbContext
    {
        public FeatureTestEntities()
            : base("name=FeatureTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Panel> Panels { get; set; }
        public virtual DbSet<PanelElement> PanelElements { get; set; }
    }
}
