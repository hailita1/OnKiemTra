﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDemo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using WebDemo.Models;
    
    public partial class QLBanVaLiEntities : DbContext
    {
        public QLBanVaLiEntities()
            : base("name=QLBanVaLiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tAnhSP> tAnhSPs { get; set; }
        public virtual DbSet<tChatLieu> tChatLieux { get; set; }
        public virtual DbSet<tDanhMucSP> tDanhMucSPs { get; set; }
        public virtual DbSet<tHangSX> tHangSXes { get; set; }
        public virtual DbSet<tKichThuoc> tKichThuocs { get; set; }
        public virtual DbSet<tLoaiDT> tLoaiDTs { get; set; }
        public virtual DbSet<tLoaiSP> tLoaiSPs { get; set; }
        public virtual DbSet<tQuocGia> tQuocGias { get; set; }
    }
}