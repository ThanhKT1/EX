﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBthanh.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WEBTHANHEntities2 : DbContext
    {
        public WEBTHANHEntities2()
            : base("name=WEBTHANHEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaiViett> BaiVietts { get; set; }
        public virtual DbSet<HinhAnhPhoto> HinhAnhPhotos { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VideosPhoto> VideosPhotos { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<TrichhDoan> TrichhDoans { get; set; }
        public virtual DbSet<NGUOIDUNGAD> NGUOIDUNGADs { get; set; }
    }
}
